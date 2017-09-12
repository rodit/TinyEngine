namespace TinyEngine.Forms
{
    partial class AssetManager
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
            this.assetsTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // assetsTree
            // 
            this.assetsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTree.Location = new System.Drawing.Point(0, 0);
            this.assetsTree.Name = "assetsTree";
            this.assetsTree.Size = new System.Drawing.Size(598, 412);
            this.assetsTree.TabIndex = 1;
            // 
            // AssetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 412);
            this.Controls.Add(this.assetsTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AssetManager";
            this.Text = "Asset Manager";
            this.Load += new System.EventHandler(this.AssetManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView assetsTree;
    }
}