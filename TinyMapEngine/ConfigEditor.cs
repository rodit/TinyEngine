using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public class MobConfigEditor : UITypeEditor
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
            MobSpawn spawn = (MobSpawn)context.Instance;

            foreach (string file in Util.GetFileNamesRecursive(Path.Combine(Tiny.Root, "assets", "config", "entity", "mob")))
            {
                string full = "config/entity/mob/" + file;
                int index = lb.Items.Add(full);
                if (full == spawn.SpawnConfig)
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
