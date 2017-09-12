namespace TinyEngine
{
    partial class AssetPreviewer
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
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreview
            // 
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(335, 306);
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // txtPreview
            // 
            this.txtPreview.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreview.Location = new System.Drawing.Point(0, 0);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(335, 306);
            this.txtPreview.TabIndex = 1;
            // 
            // animTimer
            // 
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // AssetPreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 306);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.pbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AssetPreviewer";
            this.Text = "Asset Preview";
            this.Load += new System.EventHandler(this.AssetPreviewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Timer animTimer;
    }
}