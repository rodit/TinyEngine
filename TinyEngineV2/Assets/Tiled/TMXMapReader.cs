using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;

namespace TinyEngine.Assets.Tiled
{
    public class TMXMapReader
    {
        private string path;

        public TMXMapReader()
        {
        }

        public Map ReadMap(string file)
        {
            Stream read = new FileStream(file, FileMode.Open);
            if (file.EndsWith(".gz"))
                read = new GZipStream(read, CompressionMode.Decompress);
            Map m = ReadMap(read, Path.GetDirectoryName(file));
            read.Close();
            return m;
        }

        public Map ReadMap(Stream input, string baseDir)
        {
            path = baseDir;
            XmlDocument doc = new XmlDocument();
            doc.Load(input);

            XmlElement element = doc.DocumentElement;
            if (element.Name != "map")
                throw new IOException("Invalid tiled map file.");

            int mapWidth = 0;
            GetInt(element, "width", out mapWidth);
            int mapHeight = 0;
            GetInt(element, "height", out mapHeight);

            Map map = new Map(mapWidth, mapHeight, element.GetAttribute("orientation"));
            int tileWidth = 0;
            GetInt(element, "tilewidth", out tileWidth);
            map.TileWidth = tileWidth;

            int tileHeight = 0;
            GetInt(element, "tileheight", out tileHeight);
            map.TileHeight = tileHeight;

            ReadProperties(element.ChildNodes, map.Properties);

            foreach (XmlNode tsNode in element.GetElementsByTagName("tileset"))
            {
                map.Tilesets.Add(LoadTileset(map, (XmlElement)tsNode));
            }

            foreach (XmlNode layerNode in element.GetElementsByTagName("layer"))
            {
                TileLayer layer = ReadTileLayer((XmlElement)layerNode, map);
                if (layer != null)
                    map.Layers.Add(layer);
            }

            foreach (XmlNode objectGroupNode in element.GetElementsByTagName("objectgroup"))
            {
                ObjectLayer layer = ReadObjectLayer((XmlElement)objectGroupNode, map);
                if (layer != null)
                    map.Layers.Add(layer);
            }
            return map;
        }

        private MapObject ReadMapObject(XmlElement element, Map map)
        {
            MapObject obj = new MapObject();
            obj.Name = element.GetAttribute("name");
            obj.Type = element.GetAttribute("type");
            if (element.HasAttribute("gid"))
            {
                int gid = 0;
                GetInt(element, "gid", out gid, false);
                obj.ObjectTile = GetTileByGID(map, gid);
            }
            float x = 0;
            GetFloat(element, "x", out x, false);
            float y = 0;
            GetFloat(element, "y", out y, false);
            float width = 0;
            GetFloat(element, "width", out width, false);
            float height = 0;
            GetFloat(element, "height", out height, false);
            obj.X = x;
            obj.Y = y;
            obj.Width = width;
            obj.Height = height;
            ReadProperties(element.ChildNodes, obj.Properties);
            return obj;
        }

        private ObjectLayer ReadObjectLayer(XmlElement element, Map map)
        {
            int offsetX = 0;
            GetInt(element, "x", out offsetX, false);
            int offsetY = 0;
            GetInt(element, "y", out offsetY, false);

            ObjectLayer layer = new ObjectLayer(offsetX, offsetY);
            layer.Name = element.GetAttribute("name");
            foreach(XmlNode objectNode in element.GetElementsByTagName("object"))
            {
                XmlElement e = (XmlElement)objectNode;
                layer.Objects.Add(ReadMapObject(e, map));
            }

            ReadProperties(element.ChildNodes, layer.Properties);

            return layer;
        }

        private TileLayer ReadTileLayer(XmlElement element, Map map)
        {
            int layerWidth = 0;
            GetInt(element, "width", out layerWidth, false);
            int layerHeight = 0;
            GetInt(element, "height", out layerHeight, false);
            if (layerWidth <= 0 || layerHeight <= 0)
                return null;

            TileLayer layer = new TileLayer(layerWidth, layerHeight);
            int offsetX = 0;
            GetInt(element, "x", out offsetX, false);
            int offsetY = 0;
            GetInt(element, "y", out offsetY, false);
            int visible = 1;
            GetInt(element, "visible", out visible, false);
            layer.Visible = visible == 1;

            layer.Name = element.GetAttribute("name");

            float opacity = 1f;
            GetFloat(element, "opacity", out opacity, false);

            ReadProperties(element.ChildNodes, layer.Properties);

            foreach(XmlNode dataNode in element.GetElementsByTagName("data"))
            {
                XmlElement e = (XmlElement)dataNode;
                string encoding = e.GetAttribute("encoding");
                string compression = e.GetAttribute("compression");
                string data = e.InnerText.Trim();
                if (encoding == "base64")
                {
                    byte[] dec = Convert.FromBase64String(data);
                    Stream stream = new MemoryStream(dec);
                    if (compression == "gzip")
                        stream = new GZipStream(stream, CompressionMode.Decompress);
                    else if (compression != null && !string.IsNullOrWhiteSpace(compression))
                        Error("Unsupported compression method (" + compression + ").");
                    for (int y = 0; y < layerHeight; y++)
                    {
                        for (int x = 0; x < layerWidth; x++)
                        {
                            int tileId = 0;
                            tileId |= stream.ReadByte();
                            tileId |= stream.ReadByte() << 8;
                            tileId |= stream.ReadByte() << 16;
                            tileId |= stream.ReadByte() << 24;

                            layer.SetTile(x, y, GetTileByGID(map, tileId));
                        }
                    }
                }
                else if (encoding == "csv")
                {
                    string[] tiles = Regex.Split(data, @"[\s+]*,[\\s]*");
                    if (tiles.Length != layerWidth * layerHeight)
                        Error("Tile count does not match layer size.");
                    for (int y = 0; y < layerHeight; y++)
                    {
                        for (int x = 0; x < layerWidth; x++)
                        {
                            string tile = tiles[x + y * layerWidth];
                            int tileId = int.Parse(tile);
                            layer.SetTile(x, y, GetTileByGID(map, tileId));
                        }
                    }
                }
                break;
            }

            layer.Bounds = new Rectangle(offsetX, offsetY, layerWidth, layerHeight);

            return layer;
        }

        private Tile GetTileByGID(Map map, int gid)
        {
            if (gid <= 0)
                return null;
            Tile tile = null;
            Tileset tileset = map.Tilesets[0];
            foreach (Tileset ts in map.Tilesets)
            {
                if (ts.FirstGid > gid)
                    break;
                tileset = ts;
            }
            if (tileset != null)
            {
                if (gid == 1)
                {
                    return tileset.Tiles[0];
                }
                tile = tileset.Tiles[gid - tileset.FirstGid];
            }
            return tile;
        }

        private Tileset LoadTileset(Map map, XmlElement element)
        {
            int firstGid = 1;
            GetInt(element, "firstgid", out firstGid);

            Tileset tileset = new Tileset();
            tileset.Base = path;

            int tileWidth = 0;
            GetInt(element, "tilewidth", out tileWidth, false);
            if (tileWidth == 0)
                tileWidth = map.TileWidth;

            int tileHeight = 0;
            GetInt(element, "tileheight", out tileHeight, false);
            if (tileHeight == 0)
                tileHeight = map.TileHeight;

            int spacing = 0;
            GetInt(element, "spacing", out spacing, false);

            int margin = 0;
            GetInt(element, "margin", out margin, false);

            tileset.Name = element.GetAttribute("name");
            tileset.FirstGid = firstGid;
            
            foreach(XmlNode imageNode in element.GetElementsByTagName("image"))
            {
                XmlElement e = (XmlElement)imageNode;
                string source = e.GetAttribute("source");

                if (e.HasAttribute("trans"))
                    tileset.Transparent = Color.FromArgb(int.Parse(e.GetAttribute("trans").Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                tileset.LoadFromImage(Path.Combine(path, source), new BasicTileCutter(tileWidth, tileHeight, spacing, margin));
                break;
            }

            return tileset;
        }

        private void ReadProperties(XmlNodeList nodes, Dictionary<string, string> properties)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "property")
                {
                    XmlElement element = (XmlElement)node;
                    properties[element.GetAttribute("name")] = element.GetAttribute("value");
                }
                else if (node.Name == "properties")
                    ReadProperties(node.ChildNodes, properties);
            }
        }

        private void GetFloat(XmlElement element, string attribute, out float f, bool fatal = true)
        {
            if (!float.TryParse(element.GetAttribute(attribute), out f) && fatal)
                Error("Invalid " + attribute + " attribute.");
        }

        private void GetInt(XmlElement element, string attribute, out int i, bool fatal = true)
        {
            if (!int.TryParse(element.GetAttribute(attribute), out i) && fatal)
                Error("Invalid " + attribute + " attribute.");
        }

        private void Error(string text)
        {
            throw new IOException(text);
        }
    }
}
