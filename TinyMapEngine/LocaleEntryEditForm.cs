using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyMapEngine.TinyEngine;

namespace TinyMapEngine
{
    public partial class LocaleEntryEditForm : Form
    {
        public LocaleEntryRef Entry { get; set; }

        public LocaleEntryEditForm(LocaleEntryRef entry)
        {
            Entry = entry;
            InitializeComponent();
        }

        private void LocaleEntryEditForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            txtLocaleName.Text = Entry.Name;
            txtLocaleValue.Text = Entry.Value.Replace("\\n", "\r\n");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entry.Value = txtLocaleValue.Text.Replace("\r\n", "\\n");
            Close();
        }
    }

    public class LocaleEntryEditor : UITypeEditor
    {
        public class LocaleEntryChangedEventArgs : EventArgs
        {
            public LocaleEntryRef EntryRef { get; set; }

            public LocaleEntryChangedEventArgs(LocaleEntryRef entryRef)
            {
                EntryRef = entryRef;
            }
        }

        public static event Action<object, LocaleEntryChangedEventArgs> LocaleEntryChanged;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (Tiny.Locale == null)
            {
                MessageBox.Show("Please load a locale before attempting to edit its values!", "No Locale Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return value;
            }
            LocaleEntryEditForm form = new LocaleEntryEditForm((LocaleEntryRef)value);
            form.ShowDialog();
            LocaleEntryChanged?.Invoke(this, new LocaleEntryChangedEventArgs(form.Entry));
            return form.Entry;
        }
    }
}
