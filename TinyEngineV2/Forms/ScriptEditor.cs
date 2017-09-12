using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser.Model;
using TinyEngine.Assets;

namespace TinyEngine.Forms
{
    public partial class ScriptEditor : Form
    {
        public ScriptEditor()
        {
            InitializeComponent();
        }

        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            tabsScriptEditors.MouseUp += TabsScriptEditors_MouseUp;

            string scriptLoad = TinyEngine.Config.Data["Scripts"]["loaded"];
            if (scriptLoad != null)
            {
                string[] files = scriptLoad.Split(',');
                foreach (string file in files)
                {
                    if (!string.IsNullOrWhiteSpace(file.Trim()))
                    {
                        ScriptFile script = new ScriptFile(file);
                        OpenScript(script);
                    }
                }
            }
        }

        private void TabsScriptEditors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabsScriptEditors.TabCount; i++)
                {
                    Rectangle r = tabsScriptEditors.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        ScriptEditorTab tab = (ScriptEditorTab)tabsScriptEditors.TabPages[i];
                        if (tab.TryClose())
                            tabsScriptEditors.TabPages.Remove(tab);
                    }
                }
            }
        }

        public void WriteOpenConfig()
        {
            string scriptLoad = "";
            foreach (TabPage tab in tabsScriptEditors.TabPages)
            {
                ScriptEditorTab s = (ScriptEditorTab)tab;
                scriptLoad += s.Script.Name + ",";
            }
            TinyEngine.Config.Data["Scripts"]["loaded"] = scriptLoad;
            TinyEngine.Config.Save();
        }

        public void OpenScript(ScriptFile file)
        {
            ScriptEditorTab tab = null;
            foreach (TabPage page in tabsScriptEditors.TabPages)
            {
                ScriptEditorTab tp = (ScriptEditorTab)page;
                if (tp.Script == file)
                {
                    tab = tp;
                    break;
                }
            }
            if (tab == null)
            {
                tab = new ScriptEditorTab(file);
                tabsScriptEditors.TabPages.Add(tab);
            }
            tabsScriptEditors.SelectedTab = tab;
        }
    }
}
