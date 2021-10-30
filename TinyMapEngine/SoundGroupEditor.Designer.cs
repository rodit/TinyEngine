namespace TinyMapEngine
{
    partial class SoundGroupEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundGroupEditor));
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.lblReloadGroups = new System.Windows.Forms.LinkLabel();
            this.lbEffects = new System.Windows.Forms.ListBox();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.tbSeek = new System.Windows.Forms.TrackBar();
            this.tbUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGroups
            // 
            this.lbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(12, 12);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(234, 342);
            this.lbGroups.TabIndex = 0;
            this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lbGroups_SelectedIndexChanged);
            // 
            // lblReloadGroups
            // 
            this.lblReloadGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReloadGroups.AutoSize = true;
            this.lblReloadGroups.Location = new System.Drawing.Point(12, 359);
            this.lblReloadGroups.Name = "lblReloadGroups";
            this.lblReloadGroups.Size = new System.Drawing.Size(41, 13);
            this.lblReloadGroups.TabIndex = 1;
            this.lblReloadGroups.TabStop = true;
            this.lblReloadGroups.Text = "Reload";
            this.lblReloadGroups.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReloadGroups_LinkClicked);
            // 
            // lbEffects
            // 
            this.lbEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.Location = new System.Drawing.Point(252, 12);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.Size = new System.Drawing.Size(173, 277);
            this.lbEffects.TabIndex = 2;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayPause.Location = new System.Drawing.Point(252, 298);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(173, 23);
            this.btnPlayPause.TabIndex = 3;
            this.btnPlayPause.Text = "Play";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // tbSeek
            // 
            this.tbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSeek.Location = new System.Drawing.Point(252, 327);
            this.tbSeek.Name = "tbSeek";
            this.tbSeek.Size = new System.Drawing.Size(173, 45);
            this.tbSeek.TabIndex = 6;
            this.tbSeek.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSeek.Scroll += new System.EventHandler(this.tbSeek_Scroll);
            // 
            // tbUpdater
            // 
            this.tbUpdater.Enabled = true;
            this.tbUpdater.Interval = 1;
            this.tbUpdater.Tick += new System.EventHandler(this.tbUpdater_Tick);
            // 
            // SoundGroupEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 381);
            this.Controls.Add(this.tbSeek);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.lbEffects);
            this.Controls.Add(this.lblReloadGroups);
            this.Controls.Add(this.lbGroups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundGroupEditor";
            this.Text = "Sound Effects";
            this.Load += new System.EventHandler(this.SoundGroupEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.LinkLabel lblReloadGroups;
        private System.Windows.Forms.ListBox lbEffects;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.TrackBar tbSeek;
        private System.Windows.Forms.Timer tbUpdater;
    }
}