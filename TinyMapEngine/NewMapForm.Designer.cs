namespace TinyMapEngine
{
    partial class NewMapForm
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
            this.lblWidth = new System.Windows.Forms.Label();
            this.nmWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.nmHeight = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupMapDimensios = new TinyMapEngine.RoundedPanel();
            this.lblMapDimens = new System.Windows.Forms.Label();
            this.lblMapName = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbWorldLocation = new System.Windows.Forms.ComboBox();
            this.lblTiles0 = new System.Windows.Forms.Label();
            this.lblTiles1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).BeginInit();
            this.groupMapDimensios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.ForeColor = System.Drawing.Color.Black;
            this.lblWidth.Location = new System.Drawing.Point(18, 13);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 999;
            this.lblWidth.Text = "Width:";
            // 
            // nmWidth
            // 
            this.nmWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nmWidth.Location = new System.Drawing.Point(62, 11);
            this.nmWidth.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmWidth.Name = "nmWidth";
            this.nmWidth.Size = new System.Drawing.Size(117, 20);
            this.nmWidth.TabIndex = 2;
            this.nmWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.ForeColor = System.Drawing.Color.Black;
            this.lblHeight.Location = new System.Drawing.Point(15, 39);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 1000;
            this.lblHeight.Text = "Height:";
            // 
            // nmHeight
            // 
            this.nmHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nmHeight.Location = new System.Drawing.Point(62, 37);
            this.nmHeight.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmHeight.Name = "nmHeight";
            this.nmHeight.Size = new System.Drawing.Size(117, 20);
            this.nmHeight.TabIndex = 3;
            this.nmHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(12, 149);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(219, 23);
            this.btnCreate.TabIndex = 1001;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupMapDimensios
            // 
            this.groupMapDimensios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMapDimensios.Background = System.Drawing.SystemColors.Control;
            this.groupMapDimensios.BorderWidth = 1F;
            this.groupMapDimensios.Controls.Add(this.nmHeight);
            this.groupMapDimensios.Controls.Add(this.lblWidth);
            this.groupMapDimensios.Controls.Add(this.nmWidth);
            this.groupMapDimensios.Controls.Add(this.lblHeight);
            this.groupMapDimensios.ForeColor = System.Drawing.Color.Silver;
            this.groupMapDimensios.Location = new System.Drawing.Point(12, 72);
            this.groupMapDimensios.Name = "groupMapDimensios";
            this.groupMapDimensios.Radius = 4;
            this.groupMapDimensios.Size = new System.Drawing.Size(219, 71);
            this.groupMapDimensios.TabIndex = 1002;
            // 
            // lblMapDimens
            // 
            this.lblMapDimens.AutoSize = true;
            this.lblMapDimens.Location = new System.Drawing.Point(12, 56);
            this.lblMapDimens.Name = "lblMapDimens";
            this.lblMapDimens.Size = new System.Drawing.Size(88, 13);
            this.lblMapDimens.TabIndex = 1003;
            this.lblMapDimens.Text = "Map Dimensions:";
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(25, 9);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(38, 13);
            this.lblMapName.TabIndex = 1004;
            this.lblMapName.Text = "Name:";
            // 
            // txtMapName
            // 
            this.txtMapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapName.Location = new System.Drawing.Point(69, 6);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(162, 20);
            this.txtMapName.TabIndex = 0;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 35);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 1006;
            this.lblLocation.Text = "Location:";
            // 
            // cbWorldLocation
            // 
            this.cbWorldLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWorldLocation.FormattingEnabled = true;
            this.cbWorldLocation.Location = new System.Drawing.Point(69, 32);
            this.cbWorldLocation.Name = "cbWorldLocation";
            this.cbWorldLocation.Size = new System.Drawing.Size(162, 21);
            this.cbWorldLocation.TabIndex = 1;
            // 
            // lblTiles0
            // 
            this.lblTiles0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles0.AutoSize = true;
            this.lblTiles0.Location = new System.Drawing.Point(197, 85);
            this.lblTiles0.Name = "lblTiles0";
            this.lblTiles0.Size = new System.Drawing.Size(25, 13);
            this.lblTiles0.TabIndex = 1008;
            this.lblTiles0.Text = "tiles";
            // 
            // lblTiles1
            // 
            this.lblTiles1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles1.AutoSize = true;
            this.lblTiles1.Location = new System.Drawing.Point(197, 111);
            this.lblTiles1.Name = "lblTiles1";
            this.lblTiles1.Size = new System.Drawing.Size(25, 13);
            this.lblTiles1.TabIndex = 1009;
            this.lblTiles1.Text = "tiles";
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 184);
            this.Controls.Add(this.lblTiles1);
            this.Controls.Add(this.lblTiles0);
            this.Controls.Add(this.cbWorldLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.lblMapDimens);
            this.Controls.Add(this.groupMapDimensios);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Map";
            this.Load += new System.EventHandler(this.NewMapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).EndInit();
            this.groupMapDimensios.ResumeLayout(false);
            this.groupMapDimensios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nmWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown nmHeight;
        private System.Windows.Forms.Button btnCreate;
        private RoundedPanel groupMapDimensios;
        private System.Windows.Forms.Label lblMapDimens;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cbWorldLocation;
        private System.Windows.Forms.Label lblTiles0;
        private System.Windows.Forms.Label lblTiles1;
    }
}