namespace TinyMapEngine
{
    partial class EditEntityStatsForm
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
			this.statsProp = new System.Windows.Forms.PropertyGrid();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// statsProp
			// 
			this.statsProp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statsProp.HelpVisible = false;
			this.statsProp.Location = new System.Drawing.Point(0, 0);
			this.statsProp.Name = "statsProp";
			this.statsProp.Size = new System.Drawing.Size(311, 311);
			this.statsProp.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(12, 244);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(287, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// EditEntityStatsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(311, 279);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.statsProp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditEntityStatsForm";
			this.Text = "Edit Stats";
			this.Load += new System.EventHandler(this.EditEntityStatsForm_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid statsProp;
        private System.Windows.Forms.Button btnSave;
    }
}