using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem.Src
{
    internal class TransactionItem
    {
        public int ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }

        public TransactionItem(int productId, string productName, decimal sellingPrice)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = sellingPrice;
            this.Quantity = 1;
            this.Price = this.UnitPrice * this.Quantity;
        }
        public void updatePrice()
        {
            this.Price = this.UnitPrice * this.Quantity;
        }
        public override string ToString()
        {
            string transactionItem = String.Format("productId:{0} name:{1} quantity:{2} unitprice:{3} price{4}", Convert.ToString(this.ProductId), Convert.ToString(this.ProductName), Convert.ToString(this.Quantity), Convert.ToString(this.UnitPrice), Convert.ToString(this.Price));

            return transactionItem;
        }
        public bool Equals(TransactionItem i)
        {
            return this.ProductId == i.ProductId;
        }
        public void Store()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventorySystem.Properties.Settings.LearningDb2ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "INSERT INTO transactionItem(productId, quantity, unitPrice, price) VALUES (@ProductId, @Quantity, @UnitPrice, @Price)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                sqlCommand.Parameters.AddWithValue("@ProductId", this.ProductId);
                sqlCommand.Parameters.AddWithValue("@Quantity", this.Quantity);
                sqlCommand.Parameters.AddWithValue("@UnitPrice", this.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@Price", this.Price);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateStock(int productId, int quantity)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["InventorySystem.Properties.Settings.LearningDb2ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = string.Format("UPDATE product SET stock -= {0} WHERE productId = {1}", quantity, productId);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
