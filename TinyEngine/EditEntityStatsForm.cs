using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Design;
using System.Windows.Forms;
using TinyEngine.TinyRPG;

namespace TinyEngine
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
            cbStatType.DataSource = Enum.GetValues(typeof(Stats));
            statsProp.SelectedObject = new DictionaryPropertyGridAdapter<string, float>(Stats.Stats);
        }

        private void btnAddStat_Click(object sender, EventArgs e)
        {
            Stats.Stats[cbStatType.Text] = (float)statValue.Value;
            statsProp.SelectedObject = new DictionaryPropertyGridAdapter<string, float>(Stats.Stats);
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
