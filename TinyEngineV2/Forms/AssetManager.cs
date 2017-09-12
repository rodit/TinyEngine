using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TinyEngine.Assets;

namespace TinyEngine.Forms
{
    public partial class AssetManager : Form
    {
        public AssetManager()
        {
            InitializeComponent();
        }

        private void AssetManager_Load(object sender, EventArgs e)
        {
            foreach (string dir in Directory.GetDirectories(TinyEngine.Project.GetAsset("")))
            {
                assetsTree.Nodes.Add(CreateDirectoryNode(new DirectoryInfo(dir)));
            }
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                bool shouldSelect;
                TreeNode node = CreateAssetRefNode(file, out shouldSelect);
                if (node != null)
                    directoryNode.Nodes.Add(node);
            }
            return directoryNode;
        }

        private TreeNode CreateAssetRefNode(FileInfo fileinfo, out bool shouldSelect)
        {
            shouldSelect = false;
            string path = TinyEngine.Project.GetAsset("");
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;
            string asset = fileinfo.FullName.Substring(path.Length);
            AssetRef file = new AssetRef(asset);
            TreeNode node = new TreeNode(Path.GetFileName(file.Name));
            node.Tag = file;
            return node;
        }
    }
}
