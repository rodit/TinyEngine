namespace TinyMapEngine
{
	partial class TimePickerForm
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
			this.nmSecs = new System.Windows.Forms.NumericUpDown();
			this.nmMins = new System.Windows.Forms.NumericUpDown();
			this.nmHours = new System.Windows.Forms.NumericUpDown();
			this.lblc0 = new System.Windows.Forms.Label();
			this.lblc1 = new System.Windows.Forms.Label();
			this.lblc2 = new System.Windows.Forms.Label();
			this.nmMillis = new System.Windows.Forms.NumericUpDown();
			this.lblHours = new System.Windows.Forms.Label();
			this.lblMins = new System.Windows.Forms.Label();
			this.lblSeconds = new System.Windows.Forms.Label();
			this.lblMillis = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nmSecs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMins)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMillis)).BeginInit();
			this.SuspendLayout();
			// 
			// nmSecs
			// 
			this.nmSecs.Location = new System.Drawing.Point(167, 12);
			this.nmSecs.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.nmSecs.Name = "nmSecs";
			this.nmSecs.Size = new System.Drawing.Size(49, 20);
			this.nmSecs.TabIndex = 0;
			this.nmSecs.ValueChanged += new System.EventHandler(this.nmSecs_ValueChanged);
			// 
			// nmMins
			// 
			this.nmMins.Location = new System.Drawing.Point(96, 12);
			this.nmMins.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.nmMins.Name = "nmMins";
			this.nmMins.Size = new System.Drawing.Size(49, 20);
			this.nmMins.TabIndex = 1;
			this.nmMins.ValueChanged += new System.EventHandler(this.nmMins_ValueChanged);
			// 
			// nmHours
			// 
			this.nmHours.Location = new System.Drawing.Point(12, 12);
			this.nmHours.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nmHours.Name = "nmHours";
			this.nmHours.Size = new System.Drawing.Size(62, 20);
			this.nmHours.TabIndex = 2;
			// 
			// lblc0
			// 
			this.lblc0.AutoSize = true;
			this.lblc0.Location = new System.Drawing.Point(80, 14);
			this.lblc0.Name = "lblc0";
			this.lblc0.Size = new System.Drawing.Size(10, 13);
			this.lblc0.TabIndex = 3;
			this.lblc0.Text = ":";
			// 
			// lblc1
			// 
			this.lblc1.AutoSize = true;
			this.lblc1.Location = new System.Drawing.Point(151, 14);
			this.lblc1.Name = "lblc1";
			this.lblc1.Size = new System.Drawing.Size(10, 13);
			this.lblc1.TabIndex = 4;
			this.lblc1.Text = ":";
			// 
			// lblc2
			// 
			this.lblc2.AutoSize = true;
			this.lblc2.Location = new System.Drawing.Point(222, 14);
			this.lblc2.Name = "lblc2";
			this.lblc2.Size = new System.Drawing.Size(10, 13);
			this.lblc2.TabIndex = 5;
			this.lblc2.Text = ":";
			// 
			// nmMillis
			// 
			this.nmMillis.Location = new System.Drawing.Point(238, 12);
			this.nmMillis.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nmMillis.Name = "nmMillis";
			this.nmMillis.Size = new System.Drawing.Size(63, 20);
			this.nmMillis.TabIndex = 6;
			this.nmMillis.ValueChanged += new System.EventHandler(this.nmMillis_ValueChanged);
			// 
			// lblHours
			// 
			this.lblHours.AutoSize = true;
			this.lblHours.Location = new System.Drawing.Point(24, 35);
			this.lblHours.Name = "lblHours";
			this.lblHours.Size = new System.Drawing.Size(35, 13);
			this.lblHours.TabIndex = 7;
			this.lblHours.Text = "Hours";
			// 
			// lblMins
			// 
			this.lblMins.AutoSize = true;
			this.lblMins.Location = new System.Drawing.Point(97, 35);
			this.lblMins.Name = "lblMins";
			this.lblMins.Size = new System.Drawing.Size(44, 13);
			this.lblMins.TabIndex = 8;
			this.lblMins.Text = "Minutes";
			// 
			// lblSeconds
			// 
			this.lblSeconds.AutoSize = true;
			this.lblSeconds.Location = new System.Drawing.Point(167, 35);
			this.lblSeconds.Name = "lblSeconds";
			this.lblSeconds.Size = new System.Drawing.Size(49, 13);
			this.lblSeconds.TabIndex = 9;
			this.lblSeconds.Text = "Seconds";
			// 
			// lblMillis
			// 
			this.lblMillis.AutoSize = true;
			this.lblMillis.Location = new System.Drawing.Point(237, 35);
			this.lblMillis.Name = "lblMillis";
			this.lblMillis.Size = new System.Drawing.Size(64, 13);
			this.lblMillis.TabIndex = 10;
			this.lblMillis.Text = "Milliseconds";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(96, 59);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(205, 23);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 59);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(78, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// TimePickerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 94);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblMillis);
			this.Controls.Add(this.lblSeconds);
			this.Controls.Add(this.lblMins);
			this.Controls.Add(this.lblHours);
			this.Controls.Add(this.nmMillis);
			this.Controls.Add(this.lblc2);
			this.Controls.Add(this.lblc1);
			this.Controls.Add(this.lblc0);
			this.Controls.Add(this.nmHours);
			this.Controls.Add(this.nmMins);
			this.Controls.Add(this.nmSecs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TimePickerForm";
			this.Text = "Time";
			this.Load += new System.EventHandler(this.TimePickerForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nmSecs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMins)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMillis)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown nmSecs;
		private System.Windows.Forms.NumericUpDown nmMins;
		private System.Windows.Forms.NumericUpDown nmHours;
		private System.Windows.Forms.Label lblc0;
		private System.Windows.Forms.Label lblc1;
		private System.Windows.Forms.Label lblc2;
		private System.Windows.Forms.NumericUpDown nmMillis;
		private System.Windows.Forms.Label lblHours;
		private System.Windows.Forms.Label lblMins;
		private System.Windows.Forms.Label lblSeconds;
		private System.Windows.Forms.Label lblMillis;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
	}
}