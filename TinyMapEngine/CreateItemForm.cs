using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyMapEngine.TinyEngine;

namespace TinyMapEngine
{
	public partial class CreateItemForm : Form
	{
		public TinyItem CreatedItem { get; set; } = null;

		public CreateItemForm()
		{
			InitializeComponent();
		}

		private void CreateItemForm_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
			cbType.DisplayMember = "jType";
			TinyItem.ItemTypeReg.ForEach((type) =>
			{
				TinyItem item = (TinyItem)Activator.CreateInstance(type);
				cbType.Items.Add(item);
			});
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			txtName.Text = txtName.Text.Trim();
			if (string.IsNullOrWhiteSpace(txtName.Text))
				MessageBox.Show("Please enter a name for the new item.");
			else
			{
				foreach (object item in MainForm.itemsForm.lbItems.Items)
				{
					if ((item as TinyItem).Name == txtName.Text)
					{
						MessageBox.Show("This item name is already in use.");
						return;
					}
				}
				if (cbType.SelectedIndex < 0)
					MessageBox.Show("Please select an item type.");
				else
				{
					CreatedItem = (TinyItem)cbType.SelectedItem;
					CreatedItem.InitWithName(txtName.Text);
					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}
	}
}
