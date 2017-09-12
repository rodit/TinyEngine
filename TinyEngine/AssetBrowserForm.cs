using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TinyEngine.TinyRPG;
using System.Drawing.Design;

namespace TinyEngine
{
    public partial class AssetBrowserForm : Form
    {
        public AssetRef Asset { get; set; }
        public AssetRef.AssetType Filter { get; set; }

        private AssetPreviewer preview = new AssetPreviewer();

        public AssetBrowserForm() : this(null, AssetRef.AssetType.None) { }

        public AssetBrowserForm(AssetRef asset, AssetRef.AssetType filter)
        {
            Asset = asset;
            Filter = filter;
            InitializeComponent();
        }

        private TreeNode select;
        private void AssetBrowserForm_Load(object sender, EventArgs e)
        {
            Move += AssetBrowserForm_Move;
            FormClosing += AssetBrowserForm_FormClosing;
            preview.Show();
            assetsTree.NodeMouseDoubleClick += AssetsTree_NodeMouseDoubleClick;
            foreach (string dir in Directory.GetDirectories(Project.Current.GetAsset("")))
            {
                assetsTree.Nodes.Add(CreateDirectoryNode(new DirectoryInfo(dir)));
            }
            if (select != null)
                assetsTree.SelectedNode = select;
        }

        private void AssetBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            preview.Close();
        }

        private void AssetBrowserForm_Move(object sender, EventArgs e)
        {
            preview.Left = Right + 4;
            preview.Top = Top;
            preview.BringToFront();
        }

        private void AssetsTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AssetRef asset = (AssetRef)e.Node.Tag;
            if (asset != null)
            {
                Asset = asset;
                preview.Close();
                Close();
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
                if (shouldSelect)
                    select = node;
            }
            return directoryNode;
        }

        private TreeNode CreateAssetRefNode(FileInfo fileinfo, out bool shouldSelect)
        {
            shouldSelect = false;
            AssetRef.AssetType type = AssetRef.GetAssetType(fileinfo.Extension);
            if (!Filter.HasFlag(type) || (type == AssetRef.AssetType.None && Filter != AssetRef.AssetType.None))
                return null;
            string path = Project.Current.GetAsset("");
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;
            string asset = fileinfo.FullName.Substring(path.Length);
            AssetRef file = new AssetRef(asset);
            TreeNode node = new TreeNode(Path.GetFileName(file.Name));
            if (Asset.Name == asset || Asset.Name.Replace("/", "\\") == asset)
                shouldSelect = true;
            node.Tag = file;
            return node;
        }

        private void assetsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AssetRef asset = (AssetRef)e.Node.Tag;
            if (asset != null && asset != preview.Asset)
            {
                preview.Asset = asset;
                if (!preview.Visible)
                    preview.Show();
                preview.Left = Right + 4;
                preview.Top = Top;
                assetsTree.Focus();
            }
        }
    }

    public class AssetRefEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            AssetRef val = (AssetRef)value;
            AssetBrowserForm form = new AssetBrowserForm(val, val.Type);
            form.ShowDialog();
            return new AssetRef(form.Asset.Name.Replace("\\", "/"), form.Asset.Type);
        }
    }
}
