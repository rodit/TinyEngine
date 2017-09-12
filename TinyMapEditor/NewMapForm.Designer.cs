namespace TinyMapEditor
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
            this.lblMapWidth = new System.Windows.Forms.Label();
            this.nmWidth = new System.Windows.Forms.NumericUpDown();
            this.nmHeight = new System.Windows.Forms.NumericUpDown();
            this.lblMapHeight = new System.Windows.Forms.Label();
            this.nmTileHeight = new System.Windows.Forms.NumericUpDown();
            this.lblTHeight = new System.Windows.Forms.Label();
            this.nmTileWidth = new System.Windows.Forms.NumericUpDown();
            this.lblTWidth = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTileWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMapWidth
            // 
            this.lblMapWidth.AutoSize = true;
            this.lblMapWidth.Location = new System.Drawing.Point(19, 14);
            this.lblMapWidth.Name = "lblMapWidth";
            this.lblMapWidth.Size = new System.Drawing.Size(38, 13);
            this.lblMapWidth.TabIndex = 0;
            this.lblMapWidth.Text = "Width:";
            // 
            // nmWidth
            // 
            this.nmWidth.Location = new System.Drawing.Point(63, 12);
            this.nmWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmWidth.Name = "nmWidth";
            this.nmWidth.Size = new System.Drawing.Size(83, 20);
            this.nmWidth.TabIndex = 1;
            this.nmWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmHeight
            // 
            this.nmHeight.Location = new System.Drawing.Point(217, 12);
            this.nmHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmHeight.Name = "nmHeight";
            this.nmHeight.Size = new System.Drawing.Size(83, 20);
            this.nmHeight.TabIndex = 2;
            this.nmHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMapHeight
            // 
            this.lblMapHeight.AutoSize = true;
            this.lblMapHeight.Location = new System.Drawing.Point(170, 14);
            this.lblMapHeight.Name = "lblMapHeight";
            this.lblMapHeight.Size = new System.Drawing.Size(41, 13);
            this.lblMapHeight.TabIndex = 0;
            this.lblMapHeight.Text = "Height:";
            // 
            // nmTileHeight
            // 
            this.nmTileHeight.Location = new System.Drawing.Point(217, 38);
            this.nmTileHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmTileHeight.Name = "nmTileHeight";
            this.nmTileHeight.Size = new System.Drawing.Size(83, 20);
            this.nmTileHeight.TabIndex = 4;
            this.nmTileHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lblTHeight
            // 
            this.lblTHeight.AutoSize = true;
            this.lblTHeight.Location = new System.Drawing.Point(163, 40);
            this.lblTHeight.Name = "lblTHeight";
            this.lblTHeight.Size = new System.Drawing.Size(48, 13);
            this.lblTHeight.TabIndex = 0;
            this.lblTHeight.Text = "THeight:";
            // 
            // nmTileWidth
            // 
            this.nmTileWidth.Location = new System.Drawing.Point(63, 38);
            this.nmTileWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTileWidth.Name = "nmTileWidth";
            this.nmTileWidth.Size = new System.Drawing.Size(83, 20);
            this.nmTileWidth.TabIndex = 3;
            this.nmTileWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lblTWidth
            // 
            this.lblTWidth.AutoSize = true;
            this.lblTWidth.Location = new System.Drawing.Point(12, 40);
            this.lblTWidth.Name = "lblTWidth";
            this.lblTWidth.Size = new System.Drawing.Size(45, 13);
            this.lblTWidth.TabIndex = 0;
            this.lblTWidth.Text = "TWidth:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(184, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 96);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nmTileHeight);
            this.Controls.Add(this.lblTHeight);
            this.Controls.Add(this.nmTileWidth);
            this.Controls.Add(this.lblTWidth);
            this.Controls.Add(this.nmHeight);
            this.Controls.Add(this.lblMapHeight);
            this.Controls.Add(this.nmWidth);
            this.Controls.Add(this.lblMapWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewMapForm";
            this.Text = "New Map";
            this.Load += new System.EventHandler(this.NewMapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTileWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMapWidth;
        private System.Windows.Forms.NumericUpDown nmWidth;
        private System.Windows.Forms.NumericUpDown nmHeight;
        private System.Windows.Forms.Label lblMapHeight;
        private System.Windows.Forms.NumericUpDown nmTileHeight;
        private System.Windows.Forms.Label lblTHeight;
        private System.Windows.Forms.NumericUpDown nmTileWidth;
        private System.Windows.Forms.Label lblTWidth;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}