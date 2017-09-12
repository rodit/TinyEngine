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
    public partial class EditEquipDataForm : Form
    {
        private static EquipData.Slot[] GetSlots(params EquipData.Slot[] slots)
        {
            return slots;
        }

        private static Dictionary<TinyItem.ItemTypes, EquipData.Slot[]> slotMap = new Dictionary<TinyItem.ItemTypes, EquipData.Slot[]>()
        {
            { TinyItem.ItemTypes.ArmourChestplate, GetSlots(EquipData.Slot.SLOT_CHEST) },
            { TinyItem.ItemTypes.ArmourHelmet, GetSlots(EquipData.Slot.SLOT_HELMET) },
            { TinyItem.ItemTypes.ArmourShield, GetSlots(EquipData.Slot.SLOT_HAND_0, EquipData.Slot.SLOT_HAND_1) },
            { TinyItem.ItemTypes.ArmourShoulderPlate, GetSlots(EquipData.Slot.SLOT_SHOULDERS) },
            { TinyItem.ItemTypes.Necklace, GetSlots(EquipData.Slot.SLOT_NECK) },
            { TinyItem.ItemTypes.Ring, GetSlots(EquipData.Slot.SLOT_FINGER_0, EquipData.Slot.SLOT_FINGER_1) },
            { TinyItem.ItemTypes.Weapon, GetSlots(EquipData.Slot.SLOT_HAND_0, EquipData.Slot.SLOT_HAND_1) },
        };

        private static bool CanPutInSlot(TinyItem item, EquipData.Slot slot)
        {
            TinyItem.ItemTypes type = (TinyItem.ItemTypes)item.Properties["type"];
            if (!slotMap.ContainsKey(type))
                return false;
            EquipData.Slot[] slots = slotMap[type];
            foreach (EquipData.Slot slot0 in slots)
                if (slot0 == slot)
                    return true;
            return false;
        }

        public EquipData Equip { get; set; }

        public EditEquipDataForm(EquipData equip)
        {
            Equip = equip;
            InitializeComponent();
        }

        private void EditEquipDataForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            cbItemHelmet.Tag = EquipData.Slot.SLOT_HELMET;
            cbItemChest.Tag = EquipData.Slot.SLOT_CHEST;
            cbItemShoulders.Tag = EquipData.Slot.SLOT_SHOULDERS;
            cbItemNeck.Tag = EquipData.Slot.SLOT_NECK;
            cbItemFinger0.Tag = EquipData.Slot.SLOT_FINGER_0;
            cbItemFinger1.Tag = EquipData.Slot.SLOT_FINGER_1;
            cbItemMainHand.Tag = EquipData.Slot.SLOT_HAND_0;
            cbItemOffhand.Tag = EquipData.Slot.SLOT_HAND_1;
            foreach (Control control in Controls)
            {
                if (control.Tag is EquipData.Slot)
                {
                    ComboBox cb = (ComboBox)control;
                    cb.Items.Add("null");
                    foreach (TinyItem item in Project.Items)
                    {
                        if (CanPutInSlot(item, (EquipData.Slot)cb.Tag))
                            cb.Items.Add(item);
                    }
                    TinyItem i = Equip.Equipped[(int)control.Tag];
                    cb.SelectedItem = i;
                    if (cb.SelectedItem == null)
                        cb.SelectedIndex = 0;
                    cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
                }
            }
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            EquipData.Slot slot = (EquipData.Slot)cb.Tag;
            if (cb.SelectedIndex > 0)
                Equip.Equipped[(int)slot] = (TinyItem)cb.SelectedItem;
            else
                Equip.Equipped[(int)slot] = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class EquipDataEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            EditEquipDataForm form = new EditEquipDataForm((EquipData)value);
            form.ShowDialog();
            return form.Equip;
        }
    }
}
