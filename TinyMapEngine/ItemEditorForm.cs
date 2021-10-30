using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Windows.Forms;
using TinyMapEngine.TinyEngine;

namespace TinyMapEngine
{
	public partial class ItemEditorForm : Form
	{
		public ItemEditorForm()
		{
			InitializeComponent();
		}

		private void ItemEditorForm_Load(object sender, EventArgs e)
		{
			FormClosing += ItemEditorForm_FormClosing;
            pbItemPreview.InterpolationMode = InterpolationMode.NearestNeighbor;
			propItem.PropertySort = PropertySort.Categorized;
			propItem.PropertyValueChanged += PropItem_PropertyValueChanged;
			lbItems.DisplayMember = "Name";
			ReloadItems();
		}

        private void PropItem_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Name")
            {
                lbItems.DisplayMember = null;
                object sel = lbItems.SelectedItem;
                lbItems.SelectedItem = null;
                lbItems.SelectedItem = sel;
                lbItems.DisplayMember = "Name";
            }
        }

		private void ItemEditorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Hide();
			e.Cancel = true;
		}

		public void ReloadItems()
		{
			propItem.SelectedObject = null;
			lbItems.Items.Clear();
            TinyItem.LoadItemRegistry();
			foreach(TinyItem item in TinyItem.Registry)
                lbItems.Items.Add(item);
        }

		private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			propItem.SelectedObject = null;
			lblItemName.Text = "No item selected.";
			pbItemPreview.Image = null;
			if (lbItems.SelectedIndex > -1)
			{
				TinyItem item = (TinyItem)lbItems.SelectedItem;
				propItem.SelectedObject = item;
				lblItemName.Text = item.DisplayName.Value;
				string bmpPath = Path.Combine(Tiny.Root, "assets", item.Resource);
				if (File.Exists(bmpPath))
					pbItemPreview.Image = Util.LoadImage(bmpPath);
				else
					pbItemPreview.Image = Util.LoadImage(Path.Combine(Tiny.Root, "assets", "bitmap", "undefined.png"));
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			XmlWriterSettings config = new XmlWriterSettings();
			config.Indent = true;
			config.IndentChars = "\t";
			config.OmitXmlDeclaration = true;
			XmlWriter writer = XmlWriter.Create(Path.Combine(Tiny.Root, "assets", "config", "items.xml"), config);
			writer.WriteStartElement("items");
			foreach (object item in lbItems.Items)
			{
				writer.WriteStartElement("item");
				((TinyItem)item).Save(writer);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.Close();
			Tiny.Locale.Save("item");
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReloadItems();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbItems.SelectedIndex > -1)
			{
				if (MessageBox.Show("Are you sure you want to delete this item? This action cannot be undone.", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					TinyItem item = (TinyItem)lbItems.SelectedItem;
					lbItems.Items.RemoveAt(lbItems.SelectedIndex);
					Tiny.Locale.RemoveEntry("item", item.DisplayName.Name);
					Tiny.Locale.RemoveEntry("item", item.Description.Name);
				}
			}
		}

		private void cxtItems_Opening(object sender, CancelEventArgs e)
		{
			deleteToolStripMenuItem.Visible = lbItems.SelectedIndex > -1;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (CreateItemForm create = new CreateItemForm())
			{
				if (create.ShowDialog() == DialogResult.OK && create.CreatedItem != null)
					lbItems.Items.Add(create.CreatedItem);
			}
		}
	}
}
