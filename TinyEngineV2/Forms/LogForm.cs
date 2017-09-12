using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyEngine.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            Log.LogEvent += OnLogMessage;
            lbLogs.DrawMode = DrawMode.OwnerDrawFixed;
            lbLogs.DrawItem += LbLogs_DrawItem;
        }

        private void LbLogs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Log.LogEventArgs item = (Log.LogEventArgs)lbLogs.Items[e.Index];
            Graphics g = e.Graphics;
            Color color = Color.Black;
            if (item.Log == Log.LOG_WARN)
                color = Color.Gold;
            else if (item.Log == Log.LOG_ERROR)
                color = Color.Red;
            g.DrawString(item.ToString(), e.Font, new SolidBrush(color), new PointF(e.Bounds.X, e.Bounds.Y));
        }

        public void OnLogMessage(object sender, Log.LogEventArgs args)
        {
            if (lbLogs.InvokeRequired)
                lbLogs.Invoke(new Action(() =>
                {
                    lbLogs.Items.Add(args);
                    lbLogs.SelectedIndex = lbLogs.Items.Count - 1;
                }));
            else
            {
                lbLogs.Items.Add(args);
                lbLogs.SelectedIndex = lbLogs.Items.Count - 1;
            }
        }

        private void cxClearLog_Click(object sender, EventArgs e)
        {
            lbLogs.Items.Clear();
        }
    }
}
