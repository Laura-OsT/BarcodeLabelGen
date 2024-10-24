using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormLabelPreview : Form
    {
        public FormLabelPreview()
        {
            InitializeComponent();
        }

        // Method to set the image in the PictureBox
        public void SetLabelImage(Bitmap labelImage)
        {
            pictureBoxLabel.Image = labelImage; // Assuming you have a PictureBox named pictureBoxLabel
        }
    }

}
