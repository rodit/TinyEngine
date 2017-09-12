using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyEngine
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void SetProgress(int progress, int max)
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new Action(() => { sp(progress, max); }));
            else
                sp(progress, max);
        }

        private void sp(int progress, int max)
        {
            progressBar.Value = progress;
            progressBar.Maximum = max;
        }

        public void SetProgressText(string txt)
        {
            if (lblProgress.InvokeRequired)
                lblProgress.Invoke(new Action(() => { spt(txt); }));
            else
                spt(txt);
        }

        private void spt(string txt)
        {
            lblProgress.Text = txt;
        }

        public void OnComplete()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { oc(); }));
            else
                oc();
        }

        private void oc()
        {
            Close();
        }
    }
}
