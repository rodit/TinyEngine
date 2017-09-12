namespace TinyEngine
{
    partial class InventoryEditorForm
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
            this.dataInventory = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbItemName = new System.Windows.Forms.ComboBox();
            this.numItemCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnClearInventory = new System.Windows.Forms.Button();
            this.btnSaveInventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dataInventory
            // 
            this.dataInventory.AllowUserToAddRows = false;
            this.dataInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.itemCount});
            this.dataInventory.Location = new System.Drawing.Point(0, 0);
            this.dataInventory.Name = "dataInventory";
            this.dataInventory.Size = new System.Drawing.Size(477, 278);
            this.dataInventory.TabIndex = 0;
            this.dataInventory.TabStop = false;
            // 
            // item
            // 
            this.item.HeaderText = "Item";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // itemCount
            // 
            this.itemCount.HeaderText = "Count";
            this.itemCount.Name = "itemCount";
            this.itemCount.ReadOnly = true;
            // 
            // cbItemName
            // 
            this.cbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbItemName.FormattingEnabled = true;
            this.cbItemName.Location = new System.Drawing.Point(12, 283);
            this.cbItemName.Name = "cbItemName";
            this.cbItemName.Size = new System.Drawing.Size(172, 21);
            this.cbItemName.TabIndex = 1;
            this.cbItemName.SelectedIndexChanged += new System.EventHandler(this.cbItemName_SelectedIndexChanged);
            // 
            // numItemCount
            // 
            this.numItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numItemCount.Location = new System.Drawing.Point(190, 284);
            this.numItemCount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numItemCount.Name = "numItemCount";
            this.numItemCount.Size = new System.Drawing.Size(136, 20);
            this.numItemCount.TabIndex = 2;
            this.numItemCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(390, 283);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnClearInventory
            // 
            this.btnClearInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInventory.Location = new System.Drawing.Point(332, 283);
            this.btnClearInventory.Name = "btnClearInventory";
            this.btnClearInventory.Size = new System.Drawing.Size(52, 23);
            this.btnClearInventory.TabIndex = 4;
            this.btnClearInventory.TabStop = false;
            this.btnClearInventory.Text = "Clear";
            this.btnClearInventory.UseVisualStyleBackColor = true;
            this.btnClearInventory.Click += new System.EventHandler(this.btnClearInventory_Click);
            // 
            // btnSaveInventory
            // 
            this.btnSaveInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInventory.Location = new System.Drawing.Point(12, 310);
            this.btnSaveInventory.Name = "btnSaveInventory";
            this.btnSaveInventory.Size = new System.Drawing.Size(453, 23);
            this.btnSaveInventory.TabIndex = 5;
            this.btnSaveInventory.Text = "Save";
            this.btnSaveInventory.UseVisualStyleBackColor = true;
            this.btnSaveInventory.Click += new System.EventHandler(this.btnSaveInventory_Click);
            // 
            // InventoryEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 345);
            this.Controls.Add(this.btnSaveInventory);
            this.Controls.Add(this.btnClearInventory);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.numItemCount);
            this.Controls.Add(this.cbItemName);
            this.Controls.Add(this.dataInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InventoryEditorForm";
            this.Text = "Inventory Editor";
            this.Load += new System.EventHandler(this.InventoryEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataInventory;
        private System.Windows.Forms.ComboBox cbItemName;
        private System.Windows.Forms.NumericUpDown numItemCount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCount;
        private System.Windows.Forms.Button btnClearInventory;
        private System.Windows.Forms.Button btnSaveInventory;
    }
}