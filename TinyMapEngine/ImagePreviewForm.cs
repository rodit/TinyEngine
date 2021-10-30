using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyMapEngine
{
    public partial class ImagePreviewForm : Form
    {
        public Bitmap Image { get; set; }

        public ImagePreviewForm()
        {
            InitializeComponent();
        }

        private void ImagePreviewForm_Load(object sender, EventArgs e)
        {
            pbPreview.Image = Image;
            ClientSize = Image.Size;
        }
    }
}
