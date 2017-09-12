namespace TinyEngine.Forms
{
    partial class ScriptEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabsScriptEditors = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabsScriptEditors
            // 
            this.tabsScriptEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsScriptEditors.Location = new System.Drawing.Point(0, 0);
            this.tabsScriptEditors.Name = "tabsScriptEditors";
            this.tabsScriptEditors.SelectedIndex = 0;
            this.tabsScriptEditors.Size = new System.Drawing.Size(630, 473);
            this.tabsScriptEditors.TabIndex = 2;
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 473);
            this.Controls.Add(this.tabsScriptEditors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ScriptEditor";
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsScriptEditors;
    }
}