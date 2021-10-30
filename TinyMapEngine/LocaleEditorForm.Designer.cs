namespace TinyMapEngine
{
	partial class LocaleEditorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocaleEditorForm));
			this.lblLoadedLocale = new System.Windows.Forms.Label();
			this.lbGroups = new System.Windows.Forms.ListBox();
			this.lblGroups = new System.Windows.Forms.Label();
			this.lbEntries = new System.Windows.Forms.ListBox();
			this.btnSaveGroup = new System.Windows.Forms.Button();
			this.btnSaveAll = new System.Windows.Forms.Button();
			this.lnkReload = new System.Windows.Forms.LinkLabel();
			this.cxtEntries = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblEntries = new System.Windows.Forms.Label();
			this.cxtEntries.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLoadedLocale
			// 
			this.lblLoadedLocale.AutoSize = true;
			this.lblLoadedLocale.Location = new System.Drawing.Point(12, 9);
			this.lblLoadedLocale.Name = "lblLoadedLocale";
			this.lblLoadedLocale.Size = new System.Drawing.Size(110, 13);
			this.lblLoadedLocale.TabIndex = 1;
			this.lblLoadedLocale.Text = "Loaded Locale: None";
			// 
			// lbGroups
			// 
			this.lbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbGroups.FormattingEnabled = true;
			this.lbGroups.Location = new System.Drawing.Point(12, 38);
			this.lbGroups.Name = "lbGroups";
			this.lbGroups.Size = new System.Drawing.Size(189, 277);
			this.lbGroups.TabIndex = 2;
			this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lbGroups_SelectedIndexChanged);
			// 
			// lblGroups
			// 
			this.lblGroups.AutoSize = true;
			this.lblGroups.Location = new System.Drawing.Point(12, 22);
			this.lblGroups.Name = "lblGroups";
			this.lblGroups.Size = new System.Drawing.Size(44, 13);
			this.lblGroups.TabIndex = 3;
			this.lblGroups.Text = "Groups:";
			// 
			// lbEntries
			// 
			this.lbEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbEntries.ContextMenuStrip = this.cxtEntries;
			this.lbEntries.FormattingEnabled = true;
			this.lbEntries.Location = new System.Drawing.Point(207, 38);
			this.lbEntries.Name = "lbEntries";
			this.lbEntries.Size = new System.Drawing.Size(377, 277);
			this.lbEntries.TabIndex = 4;
			// 
			// btnSaveGroup
			// 
			this.btnSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveGroup.Location = new System.Drawing.Point(207, 321);
			this.btnSaveGroup.Name = "btnSaveGroup";
			this.btnSaveGroup.Size = new System.Drawing.Size(377, 23);
			this.btnSaveGroup.TabIndex = 5;
			this.btnSaveGroup.Text = "Save Group";
			this.btnSaveGroup.UseVisualStyleBackColor = true;
			this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);
			// 
			// btnSaveAll
			// 
			this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveAll.Location = new System.Drawing.Point(12, 321);
			this.btnSaveAll.Name = "btnSaveAll";
			this.btnSaveAll.Size = new System.Drawing.Size(189, 23);
			this.btnSaveAll.TabIndex = 8;
			this.btnSaveAll.Text = "Save All";
			this.btnSaveAll.UseVisualStyleBackColor = true;
			this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
			// 
			// lnkReload
			// 
			this.lnkReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lnkReload.AutoSize = true;
			this.lnkReload.Location = new System.Drawing.Point(543, 9);
			this.lnkReload.Name = "lnkReload";
			this.lnkReload.Size = new System.Drawing.Size(41, 13);
			this.lnkReload.TabIndex = 9;
			this.lnkReload.TabStop = true;
			this.lnkReload.Text = "Reload";
			this.lnkReload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReload_LinkClicked);
			// 
			// cxtEntries
			// 
			this.cxtEntries.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.cxtEntries.Name = "cxtEntries";
			this.cxtEntries.Size = new System.Drawing.Size(150, 70);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.editToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// lblEntries
			// 
			this.lblEntries.AutoSize = true;
			this.lblEntries.Location = new System.Drawing.Point(204, 22);
			this.lblEntries.Name = "lblEntries";
			this.lblEntries.Size = new System.Drawing.Size(42, 13);
			this.lblEntries.TabIndex = 11;
			this.lblEntries.Text = "Entries:";
			// 
			// LocaleEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 351);
			this.Controls.Add(this.lblEntries);
			this.Controls.Add(this.lnkReload);
			this.Controls.Add(this.btnSaveAll);
			this.Controls.Add(this.btnSaveGroup);
			this.Controls.Add(this.lbEntries);
			this.Controls.Add(this.lblGroups);
			this.Controls.Add(this.lbGroups);
			this.Controls.Add(this.lblLoadedLocale);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LocaleEditorForm";
			this.Text = "Locale Editor";
			this.Load += new System.EventHandler(this.LocaleEditorForm_Load);
			this.cxtEntries.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblLoadedLocale;
		private System.Windows.Forms.ListBox lbGroups;
		private System.Windows.Forms.Label lblGroups;
		private System.Windows.Forms.ListBox lbEntries;
		private System.Windows.Forms.Button btnSaveGroup;
		private System.Windows.Forms.Button btnSaveAll;
		private System.Windows.Forms.LinkLabel lnkReload;
		private System.Windows.Forms.ContextMenuStrip cxtEntries;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.Label lblEntries;
	}
}