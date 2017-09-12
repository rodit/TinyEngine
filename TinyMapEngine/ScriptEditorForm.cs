using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TinyMapEngine
{
    public partial class ScriptEditorForm : Form
    {
        public ScriptEditorForm()
        {
            InitializeComponent();
        }

        private void ScriptEditorForm_Load(object sender, EventArgs e)
        {
            FormClosing += ScriptEditorForm_FormClosing;
            tabsScripts.MouseClick += TabsScripts_MouseClick;
        }

        private void TabsScripts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabsScripts.TabCount; i++)
                {
                    Rectangle r = tabsScripts.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        ScriptEditorTab tab = (ScriptEditorTab)tabsScripts.TabPages[i];
                        if (tab.TryClose())
                            tabsScripts.TabPages.Remove(tab);
                    }
                }
            }
        }

        private void ScriptEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public ScriptEditorTab FindTab(string script)
        {
            foreach (TabPage page in tabsScripts.TabPages)
            {
                ScriptEditorTab tab = (ScriptEditorTab)page;
                if (tab.Script == script)
                    return tab;
            }
            return null;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = DialogStringInput.GetInput("Script Name");
            if (name == null || string.IsNullOrWhiteSpace(name))
                return;
            else
            {
                string fullPath = Path.Combine(Tiny.Root, "assets", "script", name);
                if (File.Exists(fullPath))
                    MessageBox.Show("Script file already exists.");
                else
                {
                    File.WriteAllText(fullPath, "");
                    ScriptEditorTab tab = new ScriptEditorTab("script/" + name);
                    tabsScripts.TabPages.Add(tab);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ScriptSelectorForm ssf = new ScriptSelectorForm())
            {
                ssf.ShowDialog();
                if(ssf.SelectedScript != null && !string.IsNullOrWhiteSpace(ssf.SelectedScript))
                {
                    Open(ssf.SelectedScript);
                }
            }
        }

        public void Open(string script)
        {
            ScriptEditorTab tab = FindTab(script);
            if (tab != null)
                tabsScripts.SelectedTab = tab;
            else
            {
                tab = new ScriptEditorTab(script);
                tabsScripts.TabPages.Add(tab);
                tabsScripts.SelectedTab = tab;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabsScripts.SelectedTab != null)
            {
                ScriptEditorTab tab = (ScriptEditorTab)tabsScripts.SelectedTab;
                if (!tab.IsSaved)
                {
                    tab.Save();
                    tab.Text = Path.GetFileName(tab.Script);
                }
            }
        }
    }
}
