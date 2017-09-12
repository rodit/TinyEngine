namespace TinyEngine.Forms
{
    partial class LogForm
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
            this.components = new System.ComponentModel.Container();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.cxtMenuLbLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cxClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMenuLbLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLogs
            // 
            this.lbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLogs.ContextMenuStrip = this.cxtMenuLbLogs;
            this.lbLogs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 15;
            this.lbLogs.Location = new System.Drawing.Point(0, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(590, 315);
            this.lbLogs.TabIndex = 2;
            // 
            // cxtMenuLbLogs
            // 
            this.cxtMenuLbLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxClearLog});
            this.cxtMenuLbLogs.Name = "cxtMenuLbLogs";
            this.cxtMenuLbLogs.Size = new System.Drawing.Size(102, 26);
            // 
            // cxClearLog
            // 
            this.cxClearLog.Name = "cxClearLog";
            this.cxClearLog.Size = new System.Drawing.Size(101, 22);
            this.cxClearLog.Text = "Clear";
            this.cxClearLog.Click += new System.EventHandler(this.cxClearLog_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 319);
            this.Controls.Add(this.lbLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LogForm";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.cxtMenuLbLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.ContextMenuStrip cxtMenuLbLogs;
        private System.Windows.Forms.ToolStripMenuItem cxClearLog;
    }
}