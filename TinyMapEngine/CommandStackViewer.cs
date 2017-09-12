using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Commands;

namespace TinyMapEngine
{
    public partial class CommandStackViewer : Form
    {
        public CommandStackViewer()
        {
            InitializeComponent();

            CommandStack.Executed += CommandStack_Executed;
            CommandStack.Undone += CommandStack_Undone;
            CommandStack.Cleared += CommandStack_Cleared;
        }

        private void CommandStackViewer_Load(object sender, EventArgs e)
        {
            TopMost = true;

            Activated += CommandStackViewer_Activated;
            Deactivate += CommandStackViewer_Deactivate;
        }

        private void CommandStackViewer_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.4f;
        }

        private void CommandStackViewer_Activated(object sender, EventArgs e)
        {
            Opacity = 1f;
        }

        private void CommandStack_Undone(object sender, CommandStack.ExecuteEventArgs e)
        {
            lbCommandStack.Items.Remove(e.Command.GetType().ToString());
        }

        private void CommandStack_Executed(object sender, CommandStack.ExecuteEventArgs e)
        {
            lbCommandStack.Items.Add(e.Command.GetType().ToString());
        }

        private void CommandStack_Cleared(object sender, EventArgs e)
        {
            lbCommandStack.Items.Clear();
        }

        private void btnClearStack_Click(object sender, EventArgs e)
        {
            CommandStack.Clear();
        }
    }
}
