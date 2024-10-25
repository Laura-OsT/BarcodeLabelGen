using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string printerName = "ZDesigner TLP 2824 Plus (ZPL)"; // Set the printer name


        public FormLabelPreview()
        {
            InitializeComponent();

            numericUpDownCopies.Minimum = 1; // Minimum value set to 1
            numericUpDownCopies.Maximum = 50; // Set the maximum as you desire
            numericUpDownCopies.Value = 1;    // Default value

            // Update Print button's position if needed
            this.zebraPrintButton.Location = new System.Drawing.Point(233, 300);

        }

        // Add a field to store the number of copies
        private int numberOfCopies = 1; // Default to 1

        // Method to set the number of copies
        public void SetNumberOfCopies(int copies)
        {
            numberOfCopies = copies;
            numericUpDownCopies.Value = copies; // Reflect the number in the UI
        }

        public int GetNumberOfCopies()
        {
            return (int)numericUpDownCopies.Value;
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
                // Retrieve the number of copies from the NumericUpDown control
                int numberOfCopies = (int)numericUpDownCopies.Value;

                // If the command contains ^PQ, replace it; otherwise, append the correct ^PQ command
                if (zplCommand.Contains("^PQ"))
                {
                    // Update the existing ^PQ command to reflect the correct number of copies
                    zplCommand = System.Text.RegularExpressions.Regex.Replace(zplCommand, @"\^PQ\d+", $"^PQ{numberOfCopies}");
                    // Debugging to verify the updated ZPL command
                    //MessageBox.Show("Updated ZPL Command:\n" + zplCommand);

                }
                else
                {
                    // If ^PQ isn't found, add it before the ^XZ (end of the ZPL command)
                    int insertPosition = zplCommand.LastIndexOf("^XZ");
                    if (insertPosition > 0)
                    {
                        zplCommand = zplCommand.Insert(insertPosition, $"^PQ{numberOfCopies}");
                    }
                }

                // Send ZPL command to the printer using RawPrinterHelper
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
