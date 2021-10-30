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

namespace TinyMapEngine
{
	public partial class TimePickerForm : Form
	{
		public long TimeMS { get; set; } = 0L;

		const long TIME_HOUR = 60 * TIME_MINUTE;
		const long TIME_MINUTE = 60 * TIME_SECOND;
		const long TIME_SECOND = 1000;

		public TimePickerForm()
		{
			InitializeComponent();
		}

		private void TimePickerForm_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
			long remain = TimeMS;
			while(remain > 0)
			{
				if (remain >= TIME_HOUR)
				{
					remain -= TIME_HOUR;
					nmHours.Value++;
				}
				else if (remain >= TIME_MINUTE)
				{
					remain -= TIME_MINUTE;
					nmMins.Value++;
				}
				else if (remain >= TIME_SECOND)
				{
					remain -= TIME_SECOND;
					nmSecs.Value++;
				}
				else
				{
					nmMillis.Value += remain;
					break;
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			TimeMS = (long)(TIME_HOUR * nmHours.Value + TIME_MINUTE * nmMins.Value + TIME_SECOND * nmSecs.Value + nmMillis.Value);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}

		private void nmMillis_ValueChanged(object sender, EventArgs e)
		{
			if(nmMillis.Value == TIME_SECOND)
			{
				nmMillis.Value = 0;
				nmSecs.Value++;
			}
		}

		private void nmSecs_ValueChanged(object sender, EventArgs e)
		{
			if (nmSecs.Value == 60)
			{
				nmSecs.Value = 0;
				nmMins.Value++;
			}
		}

		private void nmMins_ValueChanged(object sender, EventArgs e)
		{
			if (nmMins.Value == 60)
			{
				nmMins.Value = 0;
				nmHours.Value++;
			}
		}
	}

	public class MilliTimeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			TimePickerForm picker = new TimePickerForm();
			picker.TimeMS = (long)value;
			picker.ShowDialog();
			return picker.TimeMS;
		}
	}
}
