namespace TinyEngine
{
    partial class EditEntityStatsForm
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
            this.statsProp = new System.Windows.Forms.PropertyGrid();
            this.cbStatType = new System.Windows.Forms.ComboBox();
            this.statValue = new System.Windows.Forms.NumericUpDown();
            this.btnAddStat = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statValue)).BeginInit();
            this.SuspendLayout();
            // 
            // statsProp
            // 
            this.statsProp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsProp.HelpVisible = false;
            this.statsProp.Location = new System.Drawing.Point(0, 0);
            this.statsProp.Name = "statsProp";
            this.statsProp.Size = new System.Drawing.Size(419, 276);
            this.statsProp.TabIndex = 0;
            // 
            // cbStatType
            // 
            this.cbStatType.FormattingEnabled = true;
            this.cbStatType.Location = new System.Drawing.Point(12, 287);
            this.cbStatType.Name = "cbStatType";
            this.cbStatType.Size = new System.Drawing.Size(188, 21);
            this.cbStatType.TabIndex = 1;
            // 
            // statValue
            // 
            this.statValue.DecimalPlaces = 1;
            this.statValue.Location = new System.Drawing.Point(206, 287);
            this.statValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.statValue.Name = "statValue";
            this.statValue.Size = new System.Drawing.Size(120, 20);
            this.statValue.TabIndex = 2;
            // 
            // btnAddStat
            // 
            this.btnAddStat.Location = new System.Drawing.Point(332, 285);
            this.btnAddStat.Name = "btnAddStat";
            this.btnAddStat.Size = new System.Drawing.Size(75, 23);
            this.btnAddStat.TabIndex = 3;
            this.btnAddStat.Text = "Add";
            this.btnAddStat.UseVisualStyleBackColor = true;
            this.btnAddStat.Click += new System.EventHandler(this.btnAddStat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(12, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(395, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditEntityStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 352);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddStat);
            this.Controls.Add(this.statValue);
            this.Controls.Add(this.cbStatType);
            this.Controls.Add(this.statsProp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditEntityStatsForm";
            this.Text = "Edit Stats";
            this.Load += new System.EventHandler(this.EditEntityStatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid statsProp;
        private System.Windows.Forms.ComboBox cbStatType;
        private System.Windows.Forms.NumericUpDown statValue;
        private System.Windows.Forms.Button btnAddStat;
        private System.Windows.Forms.Button btnSave;
    }
}