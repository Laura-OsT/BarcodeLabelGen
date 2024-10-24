using System;
using System.Configuration;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using ZXing;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SqlConnection Connection { get; private set; }

        public Form1()
        {
            InitializeComponent();

            try
            {
                // Get the connection string from the environment variable
                string connectionString = Environment.GetEnvironmentVariable("DBLabelGenerator");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string not found in environment variables.");
                }

                // Establish the database connection
                Connection = new SqlConnection(connectionString);
                Connection.Open();
                statusLabel.Text = "Connected to Database Successfully";

                // Set KeyPreview property to true
                this.KeyPreview = true;

                // Attach KeyDown event handler to the form
                this.KeyDown += Form1_KeyDown;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Database Connection failed - check Connection String or contact Laura ASAP " + ex.Message;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Trigger the search when Enter is pressed
                PerformSearch();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSF_ProdDataSet.ITM1' table. You can move, or remove it, as needed.
            this.iTM1TableAdapter.Fill(this.cSF_ProdDataSet.ITM1);

        }

        private void iTM1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.iTM1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cSF_ProdDataSet);

        }

        // ------------------Query and Display Data------------------

        
        private void RetrieveAndShowDataExact(string userInput)
        {
            string query = "SELECT TOP 1 OITM.ItemCode, OITM.ItemName, OITM.CodeBars, OITM.SuppCatNum, OITM.OnHand, OITM.IsCommited, OITM.OnOrder, OITM.BuyUnitMsr, ITM1.Price " +
               "FROM OITM " +
               "INNER JOIN ITM1 ON OITM.ItemCode = ITM1.ItemCode " +
               "INNER JOIN OPLN ON ITM1.PriceList = OPLN.ListNum " +
               "WHERE OITM.ItemCode = @UserInput OR OITM.SuppCatNum = @UserInput " +
               "ORDER BY ITM1.Price DESC";



            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@UserInput", userInput);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    dataTable.Clear(); // Clear existing data before filling
                    //DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Display the data in ListBox 
                    output.Items.Clear();
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string result = $"SKU: {row["ItemCode"]}";
                            output.Items.Add(result);
                            result = $"Product Name: {row["ItemName"]}";
                            output.Items.Add(result);
                            result = $"Barcode: {row["CodeBars"]}";
                            output.Items.Add(result);
                            result = $"Model: {row["SuppCatNum"]}";
                            output.Items.Add(result);
                            result = $"Price: ${Convert.ToDecimal(row["Price"]):F2}";
                            output.Items.Add(result);
                            result = $"In Stock: {Convert.ToDecimal(row["OnHand"]):N0}";
                            output.Items.Add(result);
                            result = $"Commited: {Convert.ToDecimal(row["IsCommited"]):N0}";
                            output.Items.Add(result);
                            result = $"On Order: {Convert.ToDecimal(row["OnOrder"]):N0}";
                            output.Items.Add(result);
                            result = $"Unit of Measure: {row["BuyUnitMsr"]}";
                            output.Items.Add(result);
                            break;
                        }
                    }
                    else
                    {
                        output.Items.Add("No data found for the entered SKU or Model.");
                    }
                }
            }
        }

        private void RetrieveAndShowData(string userInput)
        {
            string query = "SELECT Subquery.ItemCode, Subquery.ItemName, Subquery.CodeBars, Subquery.SuppCatNum, Subquery.OnHand, Subquery.IsCommited, Subquery.OnOrder, Subquery.BuyUnitMsr, Subquery.Price " +
                "FROM (SELECT OITM.ItemCode, OITM.ItemName, OITM.CodeBars, OITM.SuppCatNum, OITM.OnHand, OITM.IsCommited, OITM.OnOrder, OITM.BuyUnitMsr, ITM1.Price, ROW_NUMBER() OVER(PARTITION BY OITM.SuppCatNum ORDER BY OITM.ItemCode) AS RowNum " +
                "FROM OITM " +
                "INNER JOIN ITM1 ON OITM.ItemCode = ITM1.ItemCode " +
                "INNER JOIN OPLN ON ITM1.PriceList = OPLN.ListNum " +
                "WHERE OITM.ItemCode = @UserInput OR OITM.SuppCatNum LIKE '%' + @UserInput + '%') " +
                "AS Subquery WHERE RowNum = 1 " +
                "ORDER BY Subquery.Price DESC";


            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@UserInput", userInput.TrimStart('*') + "%"); // Remove asterisk and add % for SQL wildcard

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    dataTable.Clear(); // Clear existing data before filling
                    adapter.Fill(dataTable);

                    DisplayWildcardSearchResults();
                }
            }
        }

        private void PerformSearch()
        {
            string userInput = inputBox.Text.Trim();
            if (!string.IsNullOrEmpty(userInput))
            {
                if (userInput.StartsWith("*"))
                {
                    // Wildcard search by SuppCatNum
                    RetrieveAndShowData(userInput);
                }
                else
                {
                    // Exact search by ItemCode or SuppCatNum
                    RetrieveAndShowDataExact(userInput);
                }
            }
        }
        private void DisplaySearchResults()
        {
            // Display search results in the output ListBox
            output.Items.Clear();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    List<string> itemDetails = new List<string>();

                    itemDetails.Add($"SKU: {row["ItemCode"]}");
                    itemDetails.Add($"Product Name: {row["ItemName"]}");
                    itemDetails.Add($"Barcode: {row["CodeBars"]}");
                    itemDetails.Add($"Model: {row["SuppCatNum"]}");
                    itemDetails.Add($"Price: ${Convert.ToDecimal(row["Price"]):F2}");
                    itemDetails.Add($"In Stock: {Convert.ToDecimal(row["OnHand"]):N0}");
                    itemDetails.Add($"Commited: {Convert.ToDecimal(row["IsCommited"]):N0}");
                    itemDetails.Add($"On Order: {Convert.ToDecimal(row["OnOrder"]):N0}");
                    itemDetails.Add($"Unit of Measure: {row["BuyUnitMsr"]}");

                    output.Items.Add(string.Join(Environment.NewLine, itemDetails));
                    output.Items.Add("------------------------------"); // Separator between items
                }
            }
            else
            {
                output.Items.Add("No data found for the entered SKU or Model.");
            }
        }

        private void DisplayWildcardSearchResults()
        {
            // Display wildcard search results in the output ListBox
            output.Items.Clear();
            if (dataTable.Rows.Count > 0)
            {
                output.Items.Add("Multiple items found. Please select one:");
                foreach (DataRow row in dataTable.Rows)
                {
                    output.Items.Add(row["SuppCatNum"]);
                }
            }
            else
            {
                output.Items.Add("No items found matching the search criteria.");
            }
        }
        //Generate barcode
        private Bitmap GenerateBarcode(string itemCode)
            {
                BarcodeWriter barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128, // Choose the barcode format, CODE_128 is a good option
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 120,  // Set the width of the barcode
                        Height = 50,  // Set the height of the barcode
                        Margin = 0    // Set the margin around the barcode
                    }
                };

        // Generate the barcode image from the itemCode
        return barcodeWriter.Write(itemCode);
    }

        //
        //Label preview
        private void ShowLabelPreviewInPopup(Bitmap labelBitmap, string zplCommand)
        {
            FormLabelPreview previewForm = new FormLabelPreview();
            previewForm.SetLabelImage(labelBitmap); // Use the SetLabelImage method to show the preview
            previewForm.SetZplCommand(zplCommand);  // Use the SetZplCommand method to store the ZPL command
            previewForm.ShowDialog();               // Show the form as a modal pop-up
        }


        private void GenerateLabelPreview(string itemName, string suppCatNum, string itemCode, decimal price, string buyUnitMsr, string codeBars)
        {
            // Create a bitmap for the label preview
            Bitmap labelBitmap = new Bitmap(180, 106); // Adjust the size to your label's dimensions (4.5 cm x 2.5 cm)

            using (Graphics g = Graphics.FromImage(labelBitmap))
            {
                g.Clear(Color.White); // Set the background color to white

                // Draw product information onto the label
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                {
                    g.DrawString(itemName, font, Brushes.Black, new PointF(10, 5)); // Product Name
                }

                using (Font font = new Font("Arial", 8))
                {
                    g.DrawString($"{suppCatNum}", font, Brushes.Black, new PointF(10, 25)); // Model Number
                }

                

                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                {
                    g.DrawString($"${price:F2}", font, Brushes.Black, new PointF(120, 60)); // Price
                }

                using (Font font = new Font("Arial", 6))
                {
                    g.DrawString($"{buyUnitMsr}", font, Brushes.Black, new PointF(150, 80)); // Units of Measure
                }

                // Generate the barcode image
                Bitmap barcodeImage = GenerateBarcode(itemCode);
                g.DrawImage(barcodeImage, new PointF(10, 50)); // Draw the barcode below the text

                // No need to draw codeBars as it is not required on the label.
                // You can keep it in the parameters for other internal logic if necessary.
            }
            // Generate the ZPL string for printing
            string zplCommand = GenerateZpl(itemName, suppCatNum, itemCode, price, buyUnitMsr, labelBitmap);

            // Show the label preview in a pop-up window
            ShowLabelPreviewInPopup(labelBitmap, zplCommand);
        }

        // Printing on the Zebra printer
        private string GenerateZpl(string itemName, string suppCatNum, string itemCode, decimal price, string buyUnitMsr, Bitmap barcodeImage)
        {
            // Create the ZPL command string for the label
            string zpl = $@"
            ^XA
            ^FO10,10^A0N,30,30^FD{itemName}^FS               // Product Name
            ^FO10,50^A0N,24,24^FDModel: {suppCatNum}^FS       // Model Number
            ^FO10,90^GB200,0,3^FS                            // Line Separator
            ^FO10,100^B3N,N,60,Y,N^FD{itemCode}^FS            // Barcode for ItemCode (Code 128)
            ^FO120,160^A0N,24,24^FDPrice: ${price:F2}^FS      // Price
            ^FO120,190^A0N,24,24^FD{buyUnitMsr} each^FS       // Units of Measure
            ^XZ
            ";

            return zpl;
        }


        //Print the label preview
        private void printBtn_Click(object sender, EventArgs e)
        {
            if (output.Items.Count > 0)
            {
                // Extract the relevant data from the ListBox output
                string itemCode = output.Items[0].ToString().Split(':')[1].Trim();
                string itemName = output.Items[1].ToString().Split(':')[1].Trim();
                string suppCatNum = output.Items[3].ToString().Split(':')[1].Trim();
                string priceString = output.Items[4].ToString().Split('$')[1].Trim();
                decimal price = Convert.ToDecimal(priceString);
                string buyUnitMsr = output.Items[8].ToString().Split(':')[1].Trim();

                // Generate barcode image
                Bitmap barcodeImage = GenerateBarcode(itemCode);

                // Generate ZPL string
                string zplCommand = GenerateZpl(itemName, suppCatNum, itemCode, price, buyUnitMsr, barcodeImage);

                // Show the label preview with ZPL command
                ShowLabelPreviewInPopup(barcodeImage, zplCommand);
            }
            else
            {
                MessageBox.Show("No data to print. Please search and select a product first.");
            }
        }



        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // string userInput = inputBox.Text;
            // RetrieveAndShowData(userInput);
            PerformSearch();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter key is pressed, trigger the search
                PerformSearch();
            }
        }

        // --------------------------------------------------------
        // Declare dataTable at the class level
        private DataTable dataTable = new DataTable();

       



        // importBtn_Click method
        private void importBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files|*.csv";
            saveFileDialog.Title = "Save CSV File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        sw.WriteLine("ItemCode,ItemName,CodeBars,SuppCatNum,Price,BuyUnitMsr");

                        // Access the class-level dataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string barcode = $"'{row["CodeBars"]}";

                            string csvLine = $"{row["ItemCode"]},{row["ItemName"]},{barcode},{row["SuppCatNum"]},{row["Price"]},{row["BuyUnitMsr"]}";
                            sw.WriteLine(csvLine);

                            
                        }
                    }

                    MessageBox.Show("CSV file has been saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving CSV file: {ex.Message}");
                }
            }
        }



        // --------------------------------------------------------

        private void clearBtn_Click(object sender, EventArgs e)
        {
            inputBox.Clear();
            output.Items.Clear();
        }

        private void output_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ListBox
            string selectedSuppCatNum = output.SelectedItem.ToString();

            // Perform a search to retrieve the details of the selected item
            RetrieveAndShowDataExact(selectedSuppCatNum);
        }
    }
}
