using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TinyEngine.TinyRPG;

namespace TinyEngine
{
    public class SpriteSheetLoader : IDisposable
    {
        public class SpriteSheetPB : Control
        {
            private SpriteSheetLoader _sprite;
            public SpriteSheetLoader SpriteSheet
            {
                get { return _sprite; }
                set
                {
                    _sprite = value;
                    w = -1;
                    h = -1;
                    Invalidate();
                }
            }

            public SpriteSheetPB() : base()
            {
                DoubleBuffered = true;
            }

            int w = -1;
            public int GetWidth()
            {
                return w == -1 ? w = SpriteSheet.frames[MovementState.Idle][Direction.Down][0].Width : w;
            }

            int h = -1;
            public int GetHeight()
            {
                return h == -1 ? h = SpriteSheet.frames[MovementState.Idle][Direction.Down][0].Height : h;
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                if (SpriteSheet != null)
                {
                    Graphics g = pe.Graphics;
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Moving, Direction.Down), 0, 0);
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Moving, Direction.Left), 0, GetHeight());
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Moving, Direction.Right), 0, GetHeight() * 2);
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Moving, Direction.Up), 0, GetHeight() * 3);
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Idle, Direction.Down), GetWidth(), 0);
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Idle, Direction.Left), GetWidth(), GetHeight());
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Idle, Direction.Right), GetWidth(), GetHeight() * 2);
                    g.DrawImage(SpriteSheet.GetFrame(MovementState.Idle, Direction.Up), GetWidth(), GetHeight() * 3);
                    //Invalidate();
                }
            }
        }

        public enum MovementState
        {
            Idle,
            Moving
        }

        public enum Direction
        {
            Down,
            Left,
            Right,
            Up
        }

        public const int DELAY = 106;

        private Dictionary<MovementState, Dictionary<Direction, Bitmap[]>> frames;

        public SpriteSheetLoader() { }

        public void Load(string file)
        {
            Bitmap sheet = Util.LoadImage(Project.Current.GetBitmap(file));
            Bitmap[] parts = new Bitmap[12];
            int w = sheet.Width / 3;
            int h = sheet.Height / 4;
            int k = 0;
            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 4; r++)
                {
                    Bitmap b = new Bitmap(w, h);
                    Graphics g = Graphics.FromImage(b);
                    g.DrawImage(sheet, new Rectangle(0, 0, w, h), new Rectangle(c * w, r * h, w, h), GraphicsUnit.Pixel);
                    g.Dispose();
                    parts[k++] = b;
                }
            }
            frames = new Dictionary<MovementState, Dictionary<Direction, Bitmap[]>>();
            frames[MovementState.Idle] = new Dictionary<Direction, Bitmap[]>();
            frames[MovementState.Idle][Direction.Down] = new Bitmap[] { parts[1] };
            frames[MovementState.Idle][Direction.Left] = new Bitmap[] { parts[4] };
            frames[MovementState.Idle][Direction.Right] = new Bitmap[] { parts[7] };
            frames[MovementState.Idle][Direction.Up] = new Bitmap[] { parts[10] };
            frames[MovementState.Moving] = new Dictionary<Direction, Bitmap[]>();
            frames[MovementState.Moving][Direction.Down] = new Bitmap[] { parts[0], parts[1], parts[2], parts[1] };
            frames[MovementState.Moving][Direction.Left] = new Bitmap[] { parts[3], parts[4], parts[5], parts[4] };
            frames[MovementState.Moving][Direction.Right] = new Bitmap[] { parts[6], parts[7], parts[8], parts[7] };
            frames[MovementState.Moving][Direction.Up] = new Bitmap[] { parts[9], parts[10], parts[11], parts[10] };
        }

        public Bitmap GetFrame(MovementState state, Direction direction)
        {
            Bitmap[] frames = this.frames[state][direction];
            long time = DateTime.UtcNow.Millisecond;
            if (frames.Length == 1)
                return frames[0];
            int frameNumber = (int)(time / DELAY);
            frameNumber = frameNumber % frames.Length;
            return frames[Math.Abs(frameNumber)];
        }

        public void Dispose()
        {
            if(frames != null)
            {
                foreach(Dictionary<Direction, Bitmap[]> dict in frames.Values)
                {
                    foreach(Bitmap[] bmps in dict.Values)
                    {
                        bmps[0].Save("cache/test.png");
                        bmps.AsParallel().ForAll(x => x.Dispose());
                    }
                }
                frames.Clear();
            }
        }
    }

    public class AnimationLoader : IDisposable
    {
        private string _sheet;

        public long Delay { get; set; }
        public List<Bitmap> Frames { get; set; }

        public AnimationLoader() { }

        public void Load(string file)
        {
            int rows = 0;
            int columns = 0;
            int start = 0;
            int length = 0;
            foreach (string line in File.ReadAllText(Project.Current.GetBitmap(file)).Split(';'))
            {
                string[] parts = line.Replace(";", "").Trim().Split(':');
                if (parts.Length == 1)
                    continue;
                if (parts[0] == "sheet")
                    _sheet = parts[1];
                else if (parts[0] == "rows")
                    rows = int.Parse(parts[1]);
                else if (parts[0] == "columns")
                    columns = int.Parse(parts[1]);
                else if (parts[0] == "start")
                    start = int.Parse(parts[1]);
                else if (parts[0] == "length")
                    length = int.Parse(parts[1]);
                else if (parts[0] == "delay")
                    Delay = long.Parse(parts[1]);
            }
            if (_sheet == null)
                return;
            Frames = new List<Bitmap>(length);
            Bitmap sheet = Util.LoadImage(Project.Current.GetBitmap(_sheet));
            int w = sheet.Width / columns;
            int h = sheet.Height / rows;
            int k = 0;
            for(int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (k >= start && k < start + length)
                    {
                        Bitmap bmp = new Bitmap(w, h);
                        Graphics g = Graphics.FromImage(bmp);
                        g.DrawImage(sheet, new Rectangle(0, 0, w, h), new Rectangle(c * w, r * h, w, h), GraphicsUnit.Pixel);
                        g.Dispose();
                        Frames.Add(bmp);
                    }
                    k++;
                }
            }
        }

        public void Dispose()
        {
            if (Frames != null)
            {
                foreach (Bitmap frame in Frames)
                    frame.Dispose();
                Frames.Clear();
            }
        }
    }
}
