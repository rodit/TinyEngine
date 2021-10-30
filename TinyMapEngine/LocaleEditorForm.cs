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
	public partial class LocaleEditorForm : Form
	{
		public LocaleEditorForm()
		{
			InitializeComponent();
		}

		private void LocaleEditorForm_Load(object sender, EventArgs e)
		{
			FormClosing += LocaleEditorForm_FormClosing;
			lblLoadedLocale.Text = "Loaded Locale: " + Tiny.Locale.LocaleName;
			lbEntries.DisplayMember = "Name";
			lbEntries.MouseDoubleClick += LbEntries_MouseDoubleClick;
			LoadLocaleData();
		}

		private void LbEntries_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lbEntries.SelectedIndex > -1)
				editToolStripMenuItem.PerformClick();
		}

		public void LoadLocaleData()
		{
			lbGroups.Items.Clear();
			lbEntries.Items.Clear();
			foreach (string group in Tiny.Locale.Entries.Keys)
				lbGroups.Items.Add(group);
		}

		private void LocaleEditorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Hide();
			e.Cancel = true;
		}

		private void lnkReload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (MessageBox.Show("Are you sure you would like to reload the locale? Any unsaved changes will be lost.", "Reload", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Tiny.Locale = new LocaleFile();
				Tiny.Locale.Load("en");
				LoadLocaleData();
			}
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbGroups.SelectedIndex > -1)
			{
				string entryName = DialogStringInput.GetInput("Locale Entry Name");
				if (!string.IsNullOrEmpty(entryName))
				{
					LocaleEntry entry = Tiny.Locale.AddEntry((string)lbGroups.SelectedItem, entryName, "");
					LocaleEntryRef lref = new LocaleEntryRef(entry);
					lbEntries.Items.Add(lref);
					lbEntries.SelectedItem = lref;
					editToolStripMenuItem.PerformClick();
				}
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbEntries.SelectedIndex > -1)
			{
				using (LocaleEntryEditForm editor = new LocaleEntryEditForm((LocaleEntryRef)lbEntries.SelectedItem))
				{
					editor.ShowDialog();
				}
			}
		}

		private void lbGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			lbEntries.Items.Clear();
			if (lbGroups.SelectedIndex > -1)
			{
				string group = lbGroups.SelectedItem as string;
				List<LocaleEntry> entries = Tiny.Locale.Entries[group];
				foreach (LocaleEntry entry in entries)
				{
					if (!(entry is LocaleEntry.CommentEntry) && entry != LocaleEntry.BLANK_LINE)
						lbEntries.Items.Add(new LocaleEntryRef(entry));
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbEntries.SelectedIndex > -1)
			{
				LocaleEntryRef lref = (LocaleEntryRef)lbEntries.SelectedItem;
				Tiny.Locale.RemoveEntry((string)lbGroups.SelectedItem, lref.Name);
				lbEntries.Items.Remove(lref);
			}
		}

		private void btnSaveAll_Click(object sender, EventArgs e)
		{
			Tiny.Locale.Save();
		}

		private void btnSaveGroup_Click(object sender, EventArgs e)
		{
			if (lbGroups.SelectedIndex > -1)
				Tiny.Locale.Save((string)lbGroups.SelectedItem);
		}
	}
}
