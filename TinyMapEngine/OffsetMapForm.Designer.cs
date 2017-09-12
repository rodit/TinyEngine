namespace TinyMapEngine
{
    partial class OffsetMapForm
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
            this.lblOffsetTitle = new System.Windows.Forms.Label();
            this.roundedPanel1 = new TinyMapEngine.RoundedPanel();
            this.nmOffsetY = new System.Windows.Forms.NumericUpDown();
            this.nmOffsetX = new System.Windows.Forms.NumericUpDown();
            this.lblTiles3 = new System.Windows.Forms.Label();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblTiles2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOffsetTitle
            // 
            this.lblOffsetTitle.AutoSize = true;
            this.lblOffsetTitle.Location = new System.Drawing.Point(12, 9);
            this.lblOffsetTitle.Name = "lblOffsetTitle";
            this.lblOffsetTitle.Size = new System.Drawing.Size(35, 13);
            this.lblOffsetTitle.TabIndex = 1018;
            this.lblOffsetTitle.Text = "Offset";
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
            this.roundedPanel1.Location = new System.Drawing.Point(15, 25);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Radius = 4;
            this.roundedPanel1.Size = new System.Drawing.Size(192, 71);
            this.roundedPanel1.TabIndex = 1017;
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
            this.nmOffsetY.Size = new System.Drawing.Size(90, 20);
            this.nmOffsetY.TabIndex = 3;
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
            this.nmOffsetX.Size = new System.Drawing.Size(90, 20);
            this.nmOffsetX.TabIndex = 2;
            // 
            // lblTiles3
            // 
            this.lblTiles3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles3.AutoSize = true;
            this.lblTiles3.Location = new System.Drawing.Point(173, 64);
            this.lblTiles3.Name = "lblTiles3";
            this.lblTiles3.Size = new System.Drawing.Size(25, 13);
            this.lblTiles3.TabIndex = 1022;
            this.lblTiles3.Text = "tiles";
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.ForeColor = System.Drawing.Color.Black;
            this.lblOffsetX.Location = new System.Drawing.Point(23, 38);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(48, 13);
            this.lblOffsetX.TabIndex = 1019;
            this.lblOffsetX.Text = "X Offset:";
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.ForeColor = System.Drawing.Color.Black;
            this.lblOffsetY.Location = new System.Drawing.Point(23, 64);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(48, 13);
            this.lblOffsetY.TabIndex = 1020;
            this.lblOffsetY.Text = "Y Offset:";
            // 
            // lblTiles2
            // 
            this.lblTiles2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiles2.AutoSize = true;
            this.lblTiles2.Location = new System.Drawing.Point(173, 38);
            this.lblTiles2.Name = "lblTiles2";
            this.lblTiles2.Size = new System.Drawing.Size(25, 13);
            this.lblTiles2.TabIndex = 1021;
            this.lblTiles2.Text = "tiles";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(77, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 23);
            this.btnOk.TabIndex = 1023;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 1024;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OffsetMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 135);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTiles3);
            this.Controls.Add(this.lblOffsetX);
            this.Controls.Add(this.lblOffsetY);
            this.Controls.Add(this.lblTiles2);
            this.Controls.Add(this.lblOffsetTitle);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OffsetMapForm";
            this.Text = "Offset Map";
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmOffsetX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOffsetTitle;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.NumericUpDown nmOffsetY;
        private System.Windows.Forms.NumericUpDown nmOffsetX;
        private System.Windows.Forms.Label lblTiles3;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblTiles2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}