using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class WorldLocationsForm : Form
    {
        public WorldLocationsForm()
        {
            InitializeComponent();
        }

        private void WorldLocationsForm_Load(object sender, EventArgs e)
        {
            Activated += WorldLocationsForm_Activated;
            Deactivate += WorldLocationsForm_Deactivate;

            foreach (WorldLocation loc in WorldLocation.Locations)
                lbWorldLocations.Items.Add(loc);
        }

        private void WorldLocationsForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.4f;
        }

        private void WorldLocationsForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1f;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbWorldLocations.SelectedItem != null)
            {
                using (NewWorldLocationForm nwl = new NewWorldLocationForm(true))
                {
                    nwl.BringToFront();
                    nwl.CreatedLocation = (WorldLocation)lbWorldLocations.SelectedItem;
                    nwl.ShowDialog();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (NewWorldLocationForm nwl = new NewWorldLocationForm())
            {
                nwl.BringToFront();
                if (nwl.ShowDialog() == DialogResult.OK && nwl.CreatedLocation != null)
                {
                    lbWorldLocations.Items.Add(nwl.CreatedLocation);
                    WorldLocation.Locations.Add(nwl.CreatedLocation);
                    WorldLocation.SaveAll();
                }
            }
        }
    }

    public class WorldLocationEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;
            lb.DisplayMember = "Name";
            WorldLocation location = ((Map)context.Instance).WorldLocation;
            foreach (WorldLocation loc in WorldLocation.Locations)
            {
                int index = lb.Items.Add(loc);
                if (loc == location)
                    lb.SelectedIndex = index;
            }

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null)
                return value;

            return lb.SelectedItem;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }
}
