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
        private string zplCommand; // Store the ZPL command to be printed
        private string printerName = "Zebra TLP 2824 Plus"; // Set the printer name
        

        public FormLabelPreview()
        {
            InitializeComponent();
        }



        // Method to set the label image in the PictureBox
        public void SetLabelImage(Bitmap labelImage)
        {
            // Clear any existing image before setting a new one
            if (pictureBoxLabel.Image != null)
            {
                pictureBoxLabel.Image.Dispose(); // Dispose of the previous image to free memory
                pictureBoxLabel.Image = null;
            }

            // Now set the new image
            pictureBoxLabel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLabel.Image = labelImage;
        }




        // Method to set the ZPL command when the preview is generated
        public void SetZplCommand(string zpl)
        {
            zplCommand = zpl;
        }

        // Method to handle the print button click
        private void zebraPrintButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(zplCommand))
            {
                // Send ZPL command to the printer using RawPrinterHelper
                string printerName = "ZDesigner TLP 2824 Plus (ZPL)"; // Replace with your printer's name
                bool success = RawPrinterHelper.SendStringToPrinter(printerName, zplCommand);

                if (!success)
                {
                    MessageBox.Show("Failed to print the label. Please check the printer connection.");
                }
                else
                {
                    MessageBox.Show("Sent to printer successfully!");
                }
            }
            else
            {
                MessageBox.Show("No label data available for printing.");
            }
        }

    }
}
