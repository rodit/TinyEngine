namespace TinyMapEngine
{
    partial class OpenMapForm
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
            this.lbMapList = new System.Windows.Forms.ListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMapList
            // 
            this.lbMapList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMapList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbMapList.FormattingEnabled = true;
            this.lbMapList.Location = new System.Drawing.Point(0, 0);
            this.lbMapList.Name = "lbMapList";
            this.lbMapList.Size = new System.Drawing.Size(381, 273);
            this.lbMapList.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.Location = new System.Drawing.Point(0, 279);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(381, 13);
            this.txtFilter.TabIndex = 1;
            // 
            // OpenMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 300);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lbMapList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "OpenMapForm";
            this.Text = "Open Map";
            this.Load += new System.EventHandler(this.OpenMapForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMapList;
        private System.Windows.Forms.TextBox txtFilter;
    }
}