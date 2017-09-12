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
using TinyEngine.TinyRPG;

namespace TinyEngine
{
    public partial class InventoryEditorForm : Form
    {
        public Inventory Inventory { get; set; }

        public InventoryEditorForm(Inventory inventory = null)
        {
            Inventory = inventory;
            InitializeComponent();
        }

        private void InventoryEditorForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            dataInventory.UserDeletingRow += DataInventory_UserDeletingRow;
            foreach (ItemStack stack in Inventory.Stacks)
                dataInventory.Rows.Add(stack.Item.Name, stack.Count);
            dataInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataInventory.AutoResizeColumns();
            foreach (TinyItem item in Project.Items)
                cbItemName.Items.Add(item);
        }

        private void DataInventory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Inventory.Stacks.RemoveAt(e.Row.Index);
        }

        private void cbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinyItem item = (TinyItem)cbItemName.SelectedItem;
            if (item.Properties.ContainsKey("stackSize"))
                numItemCount.Maximum = (int)item.Properties["stackSize"];
            else if (item.Properties.ContainsKey("stackable") && !(bool)item.Properties["stackable"])
                numItemCount.Maximum = 1;
            else
                numItemCount.Maximum = 99;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            TinyItem item = (TinyItem)cbItemName.SelectedItem;
            if (item == null)
                item = Project.Items.Find(x => x.Name == cbItemName.Text);
            if (item == null)
                MessageBox.Show("Item with id \"" + cbItemName.Text + "\" does not exist.", "TinyEngine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                int count = (int)numItemCount.Value;
                Inventory.Stacks.Add(new ItemStack(item, count));
                dataInventory.Rows.Add(item.Name, count);
            }
        }

        private void btnClearInventory_Click(object sender, EventArgs e)
        {
            Inventory.Stacks.Clear();
            dataInventory.Rows.Clear();
        }

        private void btnSaveInventory_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public class InventoryEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            InventoryEditorForm form = new InventoryEditorForm((Inventory)value);
            form.ShowDialog();
            return form.Inventory;
        }
    }
}
