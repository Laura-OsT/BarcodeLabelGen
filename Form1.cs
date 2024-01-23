using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SqlConnection Connection { get; }
        string connectionString = "Data Source=827-INC.;Initial Catalog=CSF_Prod;User Id=sa;Password=B24dcwTStqG2Ki;";

        public Form1()
        {
            InitializeComponent();

            try
            {
                Connection = new SqlConnection();
                Connection.ConnectionString = connectionString;
                Connection.Open();
                statusLabel.Text = "Connected to Database Successfully";
                // Set KeyPreview property to true
                this.KeyPreview = true;

                // Attach KeyDown event handler to the form
                this.KeyDown += Form1_KeyDown;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Database Connection failed - check Connection String or contact Laura ASAP " +
                ex.Message;
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


        private void RetrieveAndShowData(string userInput)
        {
            string query = "SELECT OITM.ItemCode, OITM.ItemName, OITM.CodeBars, OITM.SuppCatNum, OITM.OnHand, OITM.IsCommited, OITM.OnOrder, OITM.BuyUnitMsr, ITM1.Price " +
               "FROM OITM " +
               "INNER JOIN ITM1 ON OITM.ItemCode = ITM1.ItemCode " +
               "INNER JOIN OPLN ON ITM1.PriceList = OPLN.ListNum " +
               "WHERE OITM.ItemCode = @UserInput OR OITM.SuppCatNum = @UserInput";

            //SELECT T0.[ItemCode], T0.[ItemName], T1.[Price], T2.[ListName] FROM OITM T0 INNER JOIN ITM1 T1 ON T0.[ItemCode] = T1.[ItemCode] INNER JOIN OPLN T2 ON T1.[PriceList] = T2.[ListNum] WHERE T2.[ListName] = [%0]



            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@UserInput", userInput);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
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
                            result = $"Price: ${row["Price"]}";
                            output.Items.Add(result);
                            result = $"In Stock: {Convert.ToDecimal(row["OnHand"]):N0}";
                            output.Items.Add(result);
                            result = $"Commited: {Convert.ToDecimal(row["Price"]):N0}";
                            output.Items.Add(result);
                            result = $"On Order: {Convert.ToDecimal(row["OnOrder"]):N0}";
                            output.Items.Add(result);
                            result = $"Unit Measure: {row["BuyUnitMsr"]}";
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PerformSearch()
        {
            string userInput = inputBox.Text;

            if (!string.IsNullOrEmpty(userInput))
            {
                RetrieveAndShowData(userInput);
            }
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

       

        private void clearBtn_Click(object sender, EventArgs e)
        {
            inputBox.Clear();
            output.Items.Clear();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            // Check if there is data to export
            if (output.Items.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show a SaveFileDialog to choose the file location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to CSV";
            saveFileDialog.DefaultExt = "csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StreamWriter to write to the selected file
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write the header to the file
                        writer.WriteLine("SKU,Product Name,Barcode,Model,Price");

                        // Write each item to the file
                        foreach (var item in output.Items)
                        {
                            writer.WriteLine(item);
                        }
                    }

                    MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
