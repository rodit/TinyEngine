using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Design;
using System.Windows.Forms;
using TinyMapEngine.TinyEngine;

namespace TinyMapEngine
{
	public partial class EditEntityStatsForm : Form
	{
		public EntityStats Stats { get; set; }

		public EditEntityStatsForm(EntityStats stats)
		{
			Stats = stats;
			InitializeComponent();
		}

		private void EditEntityStatsForm_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
			statsProp.SelectedObject = new DictionaryPropertyGridAdapter<EntityStats.Stat, float>(Stats.Stats);
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class EntityStatsEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            EditEntityStatsForm form = new EditEntityStatsForm((EntityStats)value);
            form.ShowDialog();
            return form.Stats;
        }
    }
}
