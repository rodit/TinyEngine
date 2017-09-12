namespace TinyMapEngine
{
    partial class CommandStackViewer
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
            this.lbCommandStack = new System.Windows.Forms.ListBox();
            this.btnClearStack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCommandStack
            // 
            this.lbCommandStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCommandStack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCommandStack.FormattingEnabled = true;
            this.lbCommandStack.Location = new System.Drawing.Point(0, 0);
            this.lbCommandStack.Name = "lbCommandStack";
            this.lbCommandStack.Size = new System.Drawing.Size(268, 234);
            this.lbCommandStack.TabIndex = 0;
            // 
            // btnClearStack
            // 
            this.btnClearStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearStack.Location = new System.Drawing.Point(0, 231);
            this.btnClearStack.Name = "btnClearStack";
            this.btnClearStack.Size = new System.Drawing.Size(268, 23);
            this.btnClearStack.TabIndex = 1;
            this.btnClearStack.Text = "Clear Stack";
            this.btnClearStack.UseVisualStyleBackColor = true;
            this.btnClearStack.Click += new System.EventHandler(this.btnClearStack_Click);
            // 
            // CommandStackViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(268, 254);
            this.ControlBox = false;
            this.Controls.Add(this.btnClearStack);
            this.Controls.Add(this.lbCommandStack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CommandStackViewer";
            this.Text = "Command Stack";
            this.Load += new System.EventHandler(this.CommandStackViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCommandStack;
        private System.Windows.Forms.Button btnClearStack;
    }
}