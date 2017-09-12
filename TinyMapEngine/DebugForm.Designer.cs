namespace TinyMapEngine
{
    partial class DebugForm
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
            this.btnSideloadMap = new System.Windows.Forms.Button();
            this.txtScriptRun = new System.Windows.Forms.TextBox();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSideloadMap
            // 
            this.btnSideloadMap.Enabled = false;
            this.btnSideloadMap.Location = new System.Drawing.Point(12, 38);
            this.btnSideloadMap.Name = "btnSideloadMap";
            this.btnSideloadMap.Size = new System.Drawing.Size(412, 23);
            this.btnSideloadMap.TabIndex = 0;
            this.btnSideloadMap.Text = "Sideload Map";
            this.btnSideloadMap.UseVisualStyleBackColor = true;
            this.btnSideloadMap.Click += new System.EventHandler(this.btnSideloadMap_Click);
            // 
            // txtScriptRun
            // 
            this.txtScriptRun.Enabled = false;
            this.txtScriptRun.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptRun.Location = new System.Drawing.Point(12, 67);
            this.txtScriptRun.Multiline = true;
            this.txtScriptRun.Name = "txtScriptRun";
            this.txtScriptRun.Size = new System.Drawing.Size(412, 176);
            this.txtScriptRun.TabIndex = 1;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Enabled = false;
            this.btnRunScript.Location = new System.Drawing.Point(12, 249);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(412, 23);
            this.btnRunScript.TabIndex = 2;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(12, 15);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Host:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(50, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(287, 20);
            this.txtHost.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(343, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 284);
            this.ControlBox = false;
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.txtScriptRun);
            this.Controls.Add(this.btnSideloadMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebugForm";
            this.Text = "Debugger";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSideloadMap;
        private System.Windows.Forms.TextBox txtScriptRun;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnConnect;
    }
}