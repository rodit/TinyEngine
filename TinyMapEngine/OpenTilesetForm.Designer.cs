namespace TinyMapEngine
{
    partial class OpenTilesetForm
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
            this.lbTilesets = new System.Windows.Forms.ListBox();
            this.split = new System.Windows.Forms.SplitContainer();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTilesets
            // 
            this.lbTilesets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTilesets.FormattingEnabled = true;
            this.lbTilesets.Location = new System.Drawing.Point(0, 0);
            this.lbTilesets.Name = "lbTilesets";
            this.lbTilesets.Size = new System.Drawing.Size(175, 293);
            this.lbTilesets.TabIndex = 0;
            this.lbTilesets.SelectedIndexChanged += new System.EventHandler(this.lbTilesets_SelectedIndexChanged);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.btnSelect);
            this.split.Panel1.Controls.Add(this.lbTilesets);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.pbPreview);
            this.split.Size = new System.Drawing.Size(379, 293);
            this.split.SplitterDistance = 175;
            this.split.TabIndex = 1;
            // 
            // pbPreview
            // 
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(200, 293);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(0, 270);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(175, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // OpenTilesetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 293);
            this.Controls.Add(this.split);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "OpenTilesetForm";
            this.Text = "Load Tileset";
            this.Load += new System.EventHandler(this.OpenTilesetForm_Load);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTilesets;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnSelect;
    }
}