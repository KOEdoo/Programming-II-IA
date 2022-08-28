using InventoryManagementSystem.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AdminReport : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["InventorySystem.Properties.Settings.LearningDb2ConnectionString"].ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionString);
        public AdminReport()
        {
            InitializeComponent();
            LoadReport();
        }
        public void LoadReport(Boolean check = false)
        {
            dataGridViewReport.Rows.Clear();

            DataTable reportTable = Admin.GetDailyReport(check);
            foreach (DataRow row in reportTable.Rows)
            {
                dataGridViewReport.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewReport.Columns[e.ColumnIndex].Name;
            int transactionId = Convert.ToInt32(dataGridViewReport.Rows[e.RowIndex].Cells[1].Value);
            string total = dataGridViewReport.Rows[e.RowIndex].Cells[2].Value.ToString();
            string transactionItems = "";
            string dateTime = "";
            DataTable transactionDetails = new DataTable();

            if (colName == "Detail")
            {
                ReportModule detail = new ReportModule();
                try
                {
                    string query = "SELECT transactionItem, time FROM [transaction] WHERE transactionId = @TransactionId";


                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@TransactionId", transactionId);
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        transactionItems = reader["transactionItem"].ToString();
                        dateTime = reader["time"].ToString();
                    }
                    reader.Close();

                    string query1 = "SELECT  product.name, transactionItem.quantity, transactionItem.unitPrice, transactionItem.price FROM transactionItem INNER JOIN product ON (transactionItem.productId = product.productId) WHERE transactionItemId IN (" + transactionItems + ")";


                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query1, connection);
                    using (sqlDataAdapter)
                    {
                        sqlDataAdapter.Fill(transactionDetails);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

                foreach (DataRow row in transactionDetails.Rows)
                {
                    detail.dataGridViewTransactionDetail.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
                detail.totalLabel.Text = total;
                detail.dateLabel.Text = dateTime;
                detail.ShowDialog();
            }
        }

        private void AllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AllCheck.Checked)
            {
                LoadReport(true);
            }
            else
            {
                LoadReport(false);
            }
        }
    }
}
