namespace TinyEngine
{
    partial class AssetBrowserForm
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
            this.assetsTree.Size = new System.Drawing.Size(610, 472);
            this.assetsTree.TabIndex = 0;
            this.assetsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.assetsTree_AfterSelect);
            // 
            // AssetBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 472);
            this.Controls.Add(this.assetsTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AssetBrowserForm";
            this.Text = "Assets";
            this.Load += new System.EventHandler(this.AssetBrowserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView assetsTree;
    }
}