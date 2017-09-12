namespace TinyMapEngine
{
    partial class NewWorldLocationForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.nmXpReward = new System.Windows.Forms.NumericUpDown();
            this.lblXpReward = new System.Windows.Forms.Label();
            this.lblXp = new System.Windows.Forms.Label();
            this.lblDefaultDiscovery = new System.Windows.Forms.Label();
            this.cbDefaultState = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmXpReward)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(49, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(12, 41);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(75, 13);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(93, 38);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(208, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // nmXpReward
            // 
            this.nmXpReward.Location = new System.Drawing.Point(93, 91);
            this.nmXpReward.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmXpReward.Name = "nmXpReward";
            this.nmXpReward.Size = new System.Drawing.Size(184, 20);
            this.nmXpReward.TabIndex = 3;
            // 
            // lblXpReward
            // 
            this.lblXpReward.AutoSize = true;
            this.lblXpReward.Location = new System.Drawing.Point(40, 93);
            this.lblXpReward.Name = "lblXpReward";
            this.lblXpReward.Size = new System.Drawing.Size(47, 13);
            this.lblXpReward.TabIndex = 5;
            this.lblXpReward.Text = "Reward:";
            // 
            // lblXp
            // 
            this.lblXp.AutoSize = true;
            this.lblXp.Location = new System.Drawing.Point(283, 93);
            this.lblXp.Name = "lblXp";
            this.lblXp.Size = new System.Drawing.Size(18, 13);
            this.lblXp.TabIndex = 6;
            this.lblXp.Text = "xp";
            // 
            // lblDefaultDiscovery
            // 
            this.lblDefaultDiscovery.AutoSize = true;
            this.lblDefaultDiscovery.Location = new System.Drawing.Point(15, 67);
            this.lblDefaultDiscovery.Name = "lblDefaultDiscovery";
            this.lblDefaultDiscovery.Size = new System.Drawing.Size(72, 13);
            this.lblDefaultDiscovery.TabIndex = 7;
            this.lblDefaultDiscovery.Text = "Default State:";
            // 
            // cbDefaultState
            // 
            this.cbDefaultState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultState.FormattingEnabled = true;
            this.cbDefaultState.Items.AddRange(new object[] {
            "Discovered",
            "Undiscovered",
            "Unknown"});
            this.cbDefaultState.Location = new System.Drawing.Point(93, 64);
            this.cbDefaultState.Name = "cbDefaultState";
            this.cbDefaultState.Size = new System.Drawing.Size(208, 21);
            this.cbDefaultState.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(93, 117);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(208, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewWorldLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 149);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cbDefaultState);
            this.Controls.Add(this.lblDefaultDiscovery);
            this.Controls.Add(this.lblXp);
            this.Controls.Add(this.lblXpReward);
            this.Controls.Add(this.nmXpReward);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewWorldLocationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create World Location";
            this.Load += new System.EventHandler(this.NewWorldLocationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmXpReward)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.NumericUpDown nmXpReward;
        private System.Windows.Forms.Label lblXpReward;
        private System.Windows.Forms.Label lblXp;
        private System.Windows.Forms.Label lblDefaultDiscovery;
        private System.Windows.Forms.ComboBox cbDefaultState;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}