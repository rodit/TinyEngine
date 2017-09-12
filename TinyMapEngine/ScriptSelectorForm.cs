using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Design;

namespace TinyMapEngine
{
    public partial class ScriptSelectorForm : Form
    {
        public string SelectedScript { get; set; }
        public bool CanCreate { get; set; } = false;

        private TreeNode selectMe = null;

        public ScriptSelectorForm()
        {
            InitializeComponent();
        }

        private void ScriptSelectorForm_Load(object sender, EventArgs e)
        {
            if (!CanCreate)
            {
                btnCreate.Visible = false;
                btnEdit.Visible = false;
            }
            RefreshScripts();
            scriptsTree.NodeMouseDoubleClick += ScriptsTree_NodeMouseDoubleClick;
        }

        private void ScriptsTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node != null && e.Node.Tag != null)
            {
                TreeNode selected = e.Node;
                SelectedScript = (string)e.Node.Tag;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void RefreshScripts()
        {
            scriptsTree.Nodes.Clear();
            foreach (string dir in Directory.GetDirectories(Path.Combine(Tiny.Root, "assets", "script")))
            {
                scriptsTree.Nodes.Add(CreateDirectoryNode(new DirectoryInfo(dir)));
            }
            scriptsTree.SelectedNode = selectMe;
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(CreateScriptFileNode(file));
            return directoryNode;
        }

        private TreeNode CreateScriptFileNode(FileInfo fileinfo)
        {
            string path = Path.Combine(Tiny.Root, "assets", "script");
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;
            string script = fileinfo.FullName.Substring(path.Length);
            TreeNode node = new TreeNode(Path.GetFileName(script));
            node.Tag = script = "script/" + script.Replace("\\", "/");
            if (script == SelectedScript)
                selectMe = node;
            return node;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string scriptName = DialogStringInput.GetInput("Script Name");
            if (scriptName == null || string.IsNullOrWhiteSpace(scriptName))
                return;
            string file = "script/" + scriptName;
            string fullPath = Path.Combine(Tiny.Root, "assets", file);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            File.WriteAllText(fullPath, "");
            SelectedScript = scriptName;
            DialogResult = DialogResult.OK;
            Close();
            System.Threading.Timer t = new System.Threading.Timer((object o) =>
            {
                MainForm.scriptEditor.Invoke(new Action(() =>
                {
                    MainForm.scriptEditor.Show();
                    MainForm.scriptEditor.BringToFront();
                    MainForm.scriptEditor.Open(file);
                }));
            }, null, 250, Timeout.Infinite);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(scriptsTree.SelectedNode != null)
            {
                string script = (string)scriptsTree.SelectedNode.Tag;
                SelectedScript = script;
                DialogResult = DialogResult.OK;
                Close();
                System.Threading.Timer t = new System.Threading.Timer((object o) =>
                {
                    MainForm.scriptEditor.Invoke(new Action(() =>
                    {
                        MainForm.scriptEditor.Show();
                        MainForm.scriptEditor.BringToFront();
                        MainForm.scriptEditor.Open(script);
                    }));
                }, null, 250, Timeout.Infinite);
            }
        }
    }

    public class ScriptChooserEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (ScriptSelectorForm ssf = new ScriptSelectorForm())
            {
                ssf.SelectedScript = (string)value;
                ssf.CanCreate = true;
                ssf.ShowDialog();
                return ssf.SelectedScript;
            }
        }
    }
}
