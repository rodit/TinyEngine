using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using TinyEngine.Assets;
using TinyEngine.Forms;

namespace TinyEngine
{
    public partial class TinyEngineForm : Form
    {
        public const string ENGINE_CONFIG = "engine.ini";

        public TinyEngineForm()
        {
            InitializeComponent();
        }

        private Dictionary<string, Form> forms = new Dictionary<string, Form>();

        private void TinyEngineForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("log"))
                Directory.CreateDirectory("log");
            if (!File.Exists(ENGINE_CONFIG))
                WriteDefaultConfig();
            TinyEngine.Config = new Config(ENGINE_CONFIG);
            string projectDir = TinyEngine.Config.Data["Project"]["path"];
            if (!Directory.Exists(projectDir))
            {
                TextInputDialog input = new TextInputDialog();
                input.Text = "Project Path";
                if (input.ShowDialog() == DialogResult.OK && Project.IsValid(input.Value))
                    projectDir = TinyEngine.Config.Data["Project"]["path"] = input.Value;
                else
                    Environment.Exit(1);
                TinyEngine.Config.Save();
            }
            string cpDir = TinyEngine.Config.Data["Project"]["bin"];
            if (!Directory.Exists(projectDir))
            {
                TextInputDialog input = new TextInputDialog();
                input.Text = "Project Bin";
                if (input.ShowDialog() == DialogResult.OK && Directory.Exists(input.Value))
                    projectDir = TinyEngine.Config.Data["Project"]["bin"] = input.Value;
                else
                    Environment.Exit(1);
                TinyEngine.Config.Save();
            }
            TinyEngine.Project = new Project(projectDir);

            InitializeFormConfig(this);
            InitializeFormConfig(new LogForm());
            InitializeFormConfig(new ScriptEditor());
            InitializeFormConfig(new AssetManager());

            foreach (Form form in forms.Values)
            {
                if (form == this)
                    continue;
                ToolStripItem item = formsToolStripMenuItem.DropDownItems.Add(form.Text, null, formOpenCloseEvent);
                item.Tag = form;
            }
            Log.Info("TinyEngine", "Forms initialized.");
        }

        private void WriteDefaultConfig()
        {
            IniData data = new IniData();
            data["Forms"]["TinyEngineForm"] = "true,0,0,800,600";
            data["Forms"]["LogForm"] = "false,0,0,400,300";
            FileIniDataParser parser = new FileIniDataParser();
            parser.WriteFile(ENGINE_CONFIG, data);
        }

        private void InitializeFormConfig(Form form)
        {
            forms[form.Name] = form;
            form.StartPosition = FormStartPosition.Manual;
            form.Move += Form_Move;
            form.ResizeEnd += Form_ResizeEnd;
            if (form != this)
                form.FormClosing += Form_FormClosing;
            ReadFormData(form);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideInternalWindow((Form)sender);
            }
        }

        private void Form_Move(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            WriteFormData(form);
        }

        private void Form_ResizeEnd(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            WriteFormData(form);
        }

        private void ReadFormData(Form form)
        {
            string value = TinyEngine.Config.Data["Forms"][form.Name];
            if(value == null)
                value = (form == this ? form.WindowState == FormWindowState.Maximized : form.Visible) + "," + form.Left + "," + form.Top + "," + form.Width + "," + form.Height;
            string[] parts = value.Split(',');
            bool part0 = bool.Parse(parts[0]);
            int x = int.Parse(parts[1]);
            int y = int.Parse(parts[2]);
            int w = int.Parse(parts[3]);
            int h = int.Parse(parts[4]);
            if (form is TinyEngineForm)
                form.WindowState = part0 ? FormWindowState.Maximized : FormWindowState.Normal;
            else
            {
                if (part0)
                    ShowInternalWindow(form);
                else
                    HideInternalWindow(form);
            }
            form.SetBounds(x, y, w, h);
        }

        private void WriteFormData(Form form)
        {
            TinyEngine.Config.Data["Forms"][form.Name] = (form == this ? form.WindowState == FormWindowState.Maximized : form.Visible) + "," + form.Left + "," + form.Top + "," + form.Width + "," + form.Height;
            TinyEngine.Config.Save();
        }

        public void ShowInternalWindow(Form form)
        {
            WriteFormData(form);
            form.MdiParent = this;
            form.Show();
        }

        public void HideInternalWindow(Form form)
        {
            WriteFormData(form);
            form.Hide();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextInputDialog input = new TextInputDialog();
            input.Text = "Open Project";
            if(input.ShowDialog() == DialogResult.OK)
            {
                string value = input.Value;
                if (Project.IsValid(value))
                {
                    TinyEngine.Config.Data["Project"]["path"] = value;
                    TinyEngine.Config.Save();
                    Application.Restart();
                }
                else
                    MessageBox.Show("Invalid project directory.", "TinyEngine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void formOpenCloseEvent(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            Form form = (Form)item.Tag;
            if (form == this)
                return;
            ShowInternalWindow(form);
            form.BringToFront();
        }
    }
}
