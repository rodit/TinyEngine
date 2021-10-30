namespace TinyMapEngine
{
	partial class ItemEditorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditorForm));
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.lbItems = new System.Windows.Forms.ListBox();
			this.cxtItems = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblItemName = new System.Windows.Forms.Label();
			this.pbItemPreview = new TinyMapEngine.InterpolatedPictureBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.propItem = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.cxtItems.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbItemPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.Location = new System.Drawing.Point(0, 0);
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.lbItems);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.lblItemName);
			this.splitMain.Panel2.Controls.Add(this.pbItemPreview);
			this.splitMain.Panel2.Controls.Add(this.btnSave);
			this.splitMain.Panel2.Controls.Add(this.propItem);
			this.splitMain.Size = new System.Drawing.Size(807, 546);
			this.splitMain.SplitterDistance = 246;
			this.splitMain.TabIndex = 0;
			// 
			// lbItems
			// 
			this.lbItems.ContextMenuStrip = this.cxtItems;
			this.lbItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbItems.FormattingEnabled = true;
			this.lbItems.Location = new System.Drawing.Point(0, 0);
			this.lbItems.Name = "lbItems";
			this.lbItems.Size = new System.Drawing.Size(246, 546);
			this.lbItems.TabIndex = 0;
			this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
			// 
			// cxtItems
			// 
			this.cxtItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.cxtItems.Name = "cxtItems";
			this.cxtItems.Size = new System.Drawing.Size(114, 70);
			this.cxtItems.Opening += new System.ComponentModel.CancelEventHandler(this.cxtItems_Opening);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// lblItemName
			// 
			this.lblItemName.AutoSize = true;
			this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblItemName.Location = new System.Drawing.Point(2, 9);
			this.lblItemName.Name = "lblItemName";
			this.lblItemName.Size = new System.Drawing.Size(127, 20);
			this.lblItemName.TabIndex = 3;
			this.lblItemName.Text = "No item selected";
			// 
			// pbItemPreview
			// 
			this.pbItemPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbItemPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbItemPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
			this.pbItemPreview.Location = new System.Drawing.Point(490, 4);
			this.pbItemPreview.Name = "pbItemPreview";
			this.pbItemPreview.Size = new System.Drawing.Size(64, 64);
			this.pbItemPreview.TabIndex = 2;
			this.pbItemPreview.TabStop = false;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(3, 520);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(551, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// propItem
			// 
			this.propItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propItem.Location = new System.Drawing.Point(0, 49);
			this.propItem.Name = "propItem";
			this.propItem.Size = new System.Drawing.Size(557, 465);
			this.propItem.TabIndex = 0;
			// 
			// ItemEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 546);
			this.Controls.Add(this.splitMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ItemEditorForm";
			this.Text = "Items";
			this.Load += new System.EventHandler(this.ItemEditorForm_Load);
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			this.cxtItems.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbItemPreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.PropertyGrid propItem;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ContextMenuStrip cxtItems;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private TinyMapEngine.InterpolatedPictureBox pbItemPreview;
		private System.Windows.Forms.Label lblItemName;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		public System.Windows.Forms.ListBox lbItems;
	}
}