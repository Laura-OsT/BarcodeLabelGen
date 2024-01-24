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
            string query = "SELECT TOP 1 OITM.ItemCode, OITM.ItemName, OITM.CodeBars, OITM.SuppCatNum, OITM.OnHand, OITM.IsCommited, OITM.OnOrder, OITM.BuyUnitMsr, ITM1.Price " +
               "FROM OITM " +
               "INNER JOIN ITM1 ON OITM.ItemCode = ITM1.ItemCode " +
               "INNER JOIN OPLN ON ITM1.PriceList = OPLN.ListNum " +
               "WHERE OITM.ItemCode = @UserInput OR OITM.SuppCatNum = @UserInput " +
               "ORDER BY ITM1.Price DESC";

            //SELECT T0.[ItemCode], T0.[ItemName], T1.[Price], T2.[ListName] FROM OITM T0 INNER JOIN ITM1 T1 ON T0.[ItemCode] = T1.[ItemCode] INNER JOIN OPLN T2 ON T1.[PriceList] = T2.[ListNum] WHERE T2.[ListName] = [%0]



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

        // --------------------------------------------------------
        // Declare dataTable at the class level
        private DataTable dataTable = new DataTable();

        // Your existing RetrieveAndShowData method
       

        // Your existing importBtn_Click method
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

        

    }
}
