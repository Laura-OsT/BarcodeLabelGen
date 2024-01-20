using System;
using System.Data;
using System.Data.SqlClient;
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
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Database Connection failed - check Connection String : " +
                ex.Message;
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
            string query = "SELECT OITM.ItemCode, OITM.ItemName, OITM.CodeBars, OITM.SuppCatNum, ITM1.PriceList " +
                           "FROM OITM " +
                           "LEFT JOIN ITM1 ON OITM.ItemCode = ITM1.ItemCode " +
                           "WHERE OITM.ItemCode = @UserInput OR OITM.SuppCatNum = @UserInput";

            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@UserInput", userInput);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Display the data in your ListBox or any other desired way
                    output.Items.Clear();
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string result = $"ItemCode: {row["ItemCode"]}, ItemName: {row["ItemName"]}, CodeBars: {row["CodeBars"]}, SuppCatNum: {row["SuppCatNum"]}, PriceList: {row["PriceList"]}";
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string userInput = inputBox.Text;
            RetrieveAndShowData(userInput);
        }
    }
}
