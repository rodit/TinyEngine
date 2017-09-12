namespace TinyMapEngine
{
    partial class ResizeMapForm
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
            this.lblMapDimens = new System.Windows.Forms.Label();
            this.groupMapDimensios = new TinyMapEngine.RoundedPanel();
            this.nmHeight = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nmWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblTiles1 = new System.Windows.Forms.Label();
            this.lblTiles0 = new System.Windows.Forms.Label();
            this.cbTopLeft = new System.Windows.Forms.CheckBox();
            this.roundedPanel1 = new TinyMapEngine.RoundedPanel();
            this.nmOffsetY = new System.Windows.Forms.NumericUpDown();
            this.nmOffsetX = new System.Windows.Forms.NumericUpDown();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblTiles3 = new System.Windows.Forms.Label();
            this.lblTiles2 = new System.Windows.Forms.Label();
            this.lblOffsetTitle = new System.Windows.Forms.Label();
            this.cbTopCenter = new System.Windows.Forms.CheckBox();
            this.cbMiddleRight = new System.Windows.Forms.CheckBox();
            this.cbBottomCenter = new System.Windows.Forms.CheckBox();
            this.cbMiddleLeft = new System.Windows.Forms.CheckBox();
            this.cbBottomLeft = new System.Windows.Forms.CheckBox();
            this.cbBottomRight = new System.Windows.Forms.CheckBox();
            this.cbTopRight = new System.Windows.Forms.CheckBox();
            this.cbMiddleCenter = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupMapDimensios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMapDimens
            // 
            this.lblMapDimens.AutoSize = true;
            this.lblMapDimens.Location = new System.Drawing.Point(12, 9);
            this.lblMapDimens.Name = "lblMapDimens";
            this.lblMapDimens.Size = new System.Drawing.Size(113, 13);
            this.lblMapDimens.TabIndex = 1005;
            this.lblMapDimens.Text = "New Map Dimensions:";
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
            this.groupMapDimensios.Location = new System.Drawing.Point(12, 25);
            this.groupMapDimensios.Name = "groupMapDimensios";
            this.groupMapDimensios.Radius = 4;
            this.groupMapDimensios.Size = new System.Drawing.Size(180, 71);
            this.groupMapDimensios.TabIndex = 1004;
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
            this.nmHeight.Size = new System.Drawing.Size(78, 20);
            this.nmHeight.TabIndex = 3;
            this.nmHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
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
            this.nmWidth.Size = new System.Drawing.Size(78, 20);
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
            // lblTiles1
            // 
            this.lblTiles1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles1.AutoSize = true;
            this.lblTiles1.Location = new System.Drawing.Point(158, 64);
            this.lblTiles1.Name = "lblTiles1";
            this.lblTiles1.Size = new System.Drawing.Size(25, 13);
            this.lblTiles1.TabIndex = 1011;
            this.lblTiles1.Text = "tiles";
            // 
            // lblTiles0
            // 
            this.lblTiles0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles0.AutoSize = true;
            this.lblTiles0.Location = new System.Drawing.Point(158, 38);
            this.lblTiles0.Name = "lblTiles0";
            this.lblTiles0.Size = new System.Drawing.Size(25, 13);
            this.lblTiles0.TabIndex = 1010;
            this.lblTiles0.Text = "tiles";
            // 
            // cbTopLeft
            // 
            this.cbTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbTopLeft.AutoSize = true;
            this.cbTopLeft.Location = new System.Drawing.Point(242, 93);
            this.cbTopLeft.Name = "cbTopLeft";
            this.cbTopLeft.Size = new System.Drawing.Size(31, 23);
            this.cbTopLeft.TabIndex = 1012;
            this.cbTopLeft.Text = " ↖ ";
            this.cbTopLeft.UseVisualStyleBackColor = true;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel1.Background = System.Drawing.SystemColors.Control;
            this.roundedPanel1.BorderWidth = 1F;
            this.roundedPanel1.Controls.Add(this.nmOffsetY);
            this.roundedPanel1.Controls.Add(this.nmOffsetX);
            this.roundedPanel1.ForeColor = System.Drawing.Color.Silver;
            this.roundedPanel1.Location = new System.Drawing.Point(204, 25);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Radius = 4;
            this.roundedPanel1.Size = new System.Drawing.Size(180, 159);
            this.roundedPanel1.TabIndex = 1013;
            // 
            // nmOffsetY
            // 
            this.nmOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nmOffsetY.Location = new System.Drawing.Point(62, 37);
            this.nmOffsetY.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmOffsetY.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.nmOffsetY.Name = "nmOffsetY";
            this.nmOffsetY.Size = new System.Drawing.Size(78, 20);
            this.nmOffsetY.TabIndex = 3;
            this.nmOffsetY.ValueChanged += new System.EventHandler(this.nmOffsetY_ValueChanged);
            // 
            // nmOffsetX
            // 
            this.nmOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nmOffsetX.Location = new System.Drawing.Point(62, 11);
            this.nmOffsetX.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmOffsetX.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.nmOffsetX.Name = "nmOffsetX";
            this.nmOffsetX.Size = new System.Drawing.Size(78, 20);
            this.nmOffsetX.TabIndex = 2;
            this.nmOffsetX.ValueChanged += new System.EventHandler(this.nmOffsetX_ValueChanged);
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.ForeColor = System.Drawing.Color.Black;
            this.lblOffsetX.Location = new System.Drawing.Point(212, 38);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(48, 13);
            this.lblOffsetX.TabIndex = 999;
            this.lblOffsetX.Text = "X Offset:";
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.ForeColor = System.Drawing.Color.Black;
            this.lblOffsetY.Location = new System.Drawing.Point(212, 64);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(48, 13);
            this.lblOffsetY.TabIndex = 1000;
            this.lblOffsetY.Text = "Y Offset:";
            // 
            // lblTiles3
            // 
            this.lblTiles3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles3.AutoSize = true;
            this.lblTiles3.Location = new System.Drawing.Point(350, 64);
            this.lblTiles3.Name = "lblTiles3";
            this.lblTiles3.Size = new System.Drawing.Size(25, 13);
            this.lblTiles3.TabIndex = 1015;
            this.lblTiles3.Text = "tiles";
            // 
            // lblTiles2
            // 
            this.lblTiles2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles2.AutoSize = true;
            this.lblTiles2.Location = new System.Drawing.Point(350, 38);
            this.lblTiles2.Name = "lblTiles2";
            this.lblTiles2.Size = new System.Drawing.Size(25, 13);
            this.lblTiles2.TabIndex = 1014;
            this.lblTiles2.Text = "tiles";
            // 
            // lblOffsetTitle
            // 
            this.lblOffsetTitle.AutoSize = true;
            this.lblOffsetTitle.Location = new System.Drawing.Point(201, 9);
            this.lblOffsetTitle.Name = "lblOffsetTitle";
            this.lblOffsetTitle.Size = new System.Drawing.Size(38, 13);
            this.lblOffsetTitle.TabIndex = 1016;
            this.lblOffsetTitle.Text = "Offset:";
            // 
            // cbTopCenter
            // 
            this.cbTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbTopCenter.AutoSize = true;
            this.cbTopCenter.Location = new System.Drawing.Point(279, 93);
            this.cbTopCenter.Name = "cbTopCenter";
            this.cbTopCenter.Size = new System.Drawing.Size(32, 23);
            this.cbTopCenter.TabIndex = 1017;
            this.cbTopCenter.Text = " ↑";
            this.cbTopCenter.UseVisualStyleBackColor = true;
            // 
            // cbMiddleRight
            // 
            this.cbMiddleRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbMiddleRight.AutoSize = true;
            this.cbMiddleRight.Location = new System.Drawing.Point(316, 122);
            this.cbMiddleRight.Name = "cbMiddleRight";
            this.cbMiddleRight.Size = new System.Drawing.Size(32, 23);
            this.cbMiddleRight.TabIndex = 1018;
            this.cbMiddleRight.Text = " →";
            this.cbMiddleRight.UseVisualStyleBackColor = true;
            // 
            // cbBottomCenter
            // 
            this.cbBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbBottomCenter.AutoSize = true;
            this.cbBottomCenter.Location = new System.Drawing.Point(279, 151);
            this.cbBottomCenter.Name = "cbBottomCenter";
            this.cbBottomCenter.Size = new System.Drawing.Size(32, 23);
            this.cbBottomCenter.TabIndex = 1018;
            this.cbBottomCenter.Text = " ↓";
            this.cbBottomCenter.UseVisualStyleBackColor = true;
            // 
            // cbMiddleLeft
            // 
            this.cbMiddleLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbMiddleLeft.AutoSize = true;
            this.cbMiddleLeft.Location = new System.Drawing.Point(242, 122);
            this.cbMiddleLeft.Name = "cbMiddleLeft";
            this.cbMiddleLeft.Size = new System.Drawing.Size(32, 23);
            this.cbMiddleLeft.TabIndex = 1019;
            this.cbMiddleLeft.Text = "← ";
            this.cbMiddleLeft.UseVisualStyleBackColor = true;
            // 
            // cbBottomLeft
            // 
            this.cbBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbBottomLeft.AutoSize = true;
            this.cbBottomLeft.Location = new System.Drawing.Point(243, 151);
            this.cbBottomLeft.Name = "cbBottomLeft";
            this.cbBottomLeft.Size = new System.Drawing.Size(31, 23);
            this.cbBottomLeft.TabIndex = 1012;
            this.cbBottomLeft.Text = " ↙ ";
            this.cbBottomLeft.UseVisualStyleBackColor = true;
            // 
            // cbBottomRight
            // 
            this.cbBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbBottomRight.AutoSize = true;
            this.cbBottomRight.Location = new System.Drawing.Point(316, 151);
            this.cbBottomRight.Name = "cbBottomRight";
            this.cbBottomRight.Size = new System.Drawing.Size(31, 23);
            this.cbBottomRight.TabIndex = 1012;
            this.cbBottomRight.Text = " ↘ ";
            this.cbBottomRight.UseVisualStyleBackColor = true;
            // 
            // cbTopRight
            // 
            this.cbTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbTopRight.AutoSize = true;
            this.cbTopRight.Location = new System.Drawing.Point(317, 93);
            this.cbTopRight.Name = "cbTopRight";
            this.cbTopRight.Size = new System.Drawing.Size(31, 23);
            this.cbTopRight.TabIndex = 1012;
            this.cbTopRight.Text = " ↗ ";
            this.cbTopRight.UseVisualStyleBackColor = true;
            // 
            // cbMiddleCenter
            // 
            this.cbMiddleCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbMiddleCenter.AutoSize = true;
            this.cbMiddleCenter.Location = new System.Drawing.Point(279, 122);
            this.cbMiddleCenter.Name = "cbMiddleCenter";
            this.cbMiddleCenter.Size = new System.Drawing.Size(32, 23);
            this.cbMiddleCenter.TabIndex = 1020;
            this.cbMiddleCenter.Text = "  • ";
            this.cbMiddleCenter.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 161);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 23);
            this.btnOk.TabIndex = 1021;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 23);
            this.btnCancel.TabIndex = 1022;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResizeMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbMiddleCenter);
            this.Controls.Add(this.cbMiddleLeft);
            this.Controls.Add(this.cbBottomCenter);
            this.Controls.Add(this.cbMiddleRight);
            this.Controls.Add(this.cbTopCenter);
            this.Controls.Add(this.cbBottomLeft);
            this.Controls.Add(this.cbTopRight);
            this.Controls.Add(this.cbBottomRight);
            this.Controls.Add(this.cbTopLeft);
            this.Controls.Add(this.lblOffsetTitle);
            this.Controls.Add(this.lblTiles3);
            this.Controls.Add(this.lblOffsetX);
            this.Controls.Add(this.lblOffsetY);
            this.Controls.Add(this.lblTiles2);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.lblTiles1);
            this.Controls.Add(this.lblTiles0);
            this.Controls.Add(this.lblMapDimens);
            this.Controls.Add(this.groupMapDimensios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResizeMapForm";
            this.Text = "Resize Map";
            this.Load += new System.EventHandler(this.ResizeMapForm_Load);
            this.groupMapDimensios.ResumeLayout(false);
            this.groupMapDimensios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMapDimens;
        private RoundedPanel groupMapDimensios;
        private System.Windows.Forms.NumericUpDown nmHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nmWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblTiles1;
        private System.Windows.Forms.Label lblTiles0;
        private System.Windows.Forms.CheckBox cbTopLeft;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.NumericUpDown nmOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.NumericUpDown nmOffsetX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblTiles3;
        private System.Windows.Forms.Label lblTiles2;
        private System.Windows.Forms.Label lblOffsetTitle;
        private System.Windows.Forms.CheckBox cbTopCenter;
        private System.Windows.Forms.CheckBox cbMiddleRight;
        private System.Windows.Forms.CheckBox cbBottomCenter;
        private System.Windows.Forms.CheckBox cbMiddleLeft;
        private System.Windows.Forms.CheckBox cbBottomLeft;
        private System.Windows.Forms.CheckBox cbBottomRight;
        private System.Windows.Forms.CheckBox cbTopRight;
        private System.Windows.Forms.CheckBox cbMiddleCenter;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}