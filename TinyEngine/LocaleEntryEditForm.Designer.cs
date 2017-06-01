namespace TinyEngine
{
    partial class LocaleEntryEditForm
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
            this.txtLocaleValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLocaleName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLocaleValue
            // 
            this.txtLocaleValue.Location = new System.Drawing.Point(12, 38);
            this.txtLocaleValue.Multiline = true;
            this.txtLocaleValue.Name = "txtLocaleValue";
            this.txtLocaleValue.Size = new System.Drawing.Size(374, 134);
            this.txtLocaleValue.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(374, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLocaleName
            // 
            this.txtLocaleName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtLocaleName.Enabled = false;
            this.txtLocaleName.Location = new System.Drawing.Point(12, 12);
            this.txtLocaleName.Name = "txtLocaleName";
            this.txtLocaleName.Size = new System.Drawing.Size(374, 20);
            this.txtLocaleName.TabIndex = 2;
            // 
            // LocaleEntryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 213);
            this.Controls.Add(this.txtLocaleName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLocaleValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocaleEntryEditForm";
            this.Text = "Locale Entry";
            this.Load += new System.EventHandler(this.LocaleEntryEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocaleValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLocaleName;
    }
}