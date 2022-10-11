using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem.Src
{
    public class Attendant : User
    {
        public int Till { get; set; }

        public Attendant(int id)
        {
            this.Id = id;
        }

        public static DataTable GetAllProducts(string search = "")
        {
            DataTable productTable = new DataTable(); ;
            try
            {
                string query = "SELECT  product.name, category.name as category, product.stock, product.sellingPrice FROM product INNER JOIN category ON (product.categoryId = category.categoryId) WHERE CONCAT(product.name,category.name, product.barcode) LIKE '%" + search + "%'";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(productTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return productTable;
        }

        public void StartTill()
        {
            try
            {
                string query = "INSERT INTO till (userId) OUTPUT INSERTED.tillId VALUES(@UserId)";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@UserId", this.Id);
                Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    this.Till = Convert.ToInt32(Convert.ToInt32(reader["tillId"]));
                }
                MessageBox.Show("Till started");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            
        }
        public static void CloseTill(int tillId)
        {
            try
            {
                string query = "UPDATE till SET [close] = CURRENT_TIMESTAMP WHERE tillId=@TillId";
                SqlCommand sqlcommand = new SqlCommand(query, Connection);
                sqlcommand.Parameters.AddWithValue("@TillId", tillId);
                Connection.Open();
                sqlcommand.ExecuteNonQuery();
                MessageBox.Show("Till Closed");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
        }

        public static void FetchProduct(string barcode, ref ArrayList transactionItemList, int qty = 1)
        {
            for (int j = 0; j < qty; j++)
            { 
                TransactionItem transactionItem = null;
                try
                {
                    string query = "SELECT productId, name, sellingPrice FROM product WHERE barcode=@Barcode";
                    SqlCommand sqlCommand = new SqlCommand(query, Connection);
                    sqlCommand.Parameters.AddWithValue("@Barcode", barcode);
                    Connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        transactionItem = new TransactionItem((int)reader[0], (string)reader[1], (decimal)reader[2]);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    Connection.Close();
                }
                for (int i = 0; i < transactionItemList.Count; i++)
                {
                   
                    if (transactionItem.Equals((TransactionItem)transactionItemList[i]))
                    {
                        TransactionItem currentItem = (TransactionItem)transactionItemList[i];
                        int quantity = currentItem.Quantity;
                        transactionItem.Quantity += quantity;
                        transactionItem.updatePrice();
                        transactionItemList.RemoveAt(i);
                    }
                }
                    transactionItemList.Add(transactionItem);
            }
        }

        public static void  MakeSale(ArrayList transactionItemList, int tillId)
        {
            int num = transactionItemList.Count;
            decimal total = 0m;
            int last = 1;

            for (int j = 0; j < num; j++)
            {
                TransactionItem currentItem = (TransactionItem)transactionItemList[j];
                total += currentItem.Price;
                currentItem.Store();
                currentItem.UpdateStock(currentItem.ProductId, currentItem.Quantity);
            }
            try
            {
                string query = "SELECT TOP 1 transactionItemId FROM transactionItem ORDER BY transactionItemId DESC";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    last += (int)reader[0];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }

            int[] arr = Enumerable.Range(last - num, num).ToArray();

            try
            {
                string query2 = "INSERT INTO [transaction](transactionItem, tillId, total) VALUES (@TransactionItem, @TillId, @Total)";
                Connection.Open();
                SqlCommand sqlCommand2 = new SqlCommand(query2, Connection);
                sqlCommand2.Parameters.AddWithValue("@TransactionItem", string.Join(",", arr));
                sqlCommand2.Parameters.AddWithValue("@TillId", tillId);
                sqlCommand2.Parameters.AddWithValue("@Total", total);
                sqlCommand2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            GenerateReceipt(arr);
        }

        public static void GenerateReceipt(int[] transactionItemId)
        {
            try
            {
                DataTable receipt = new DataTable();
                string query = string.Format("SELECT product.name, transactionItem.quantity, transactionItem.unitPrice, transactionItem.price FROM transactionItem INNER JOIN product ON(transactionItem.productId = product.productId) WHERE transactionItem.transactionItemId IN ({0})", string.Join(",", transactionItemId));


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(receipt);
                }

                Receipt receiptView = new Receipt(receipt);
                receiptView.Show();
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static DataTable GetDailyReport(int id)
        {
            DataTable reportTable = new DataTable();
            try
            {
                string query = "SELECT till.tillId, [transaction].transactionId, [transaction].total  FROM till INNER JOIN [user] ON (till.userId = [user].userId) INNER JOIN [transaction] ON (till.tillId = [transaction].tillId) WHERE ([user].userId = "+ id +" AND CAST(time AS DATE) = CAST(GETDATE() AS DATE))";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(reportTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return reportTable;
        } 

        //transact
        //Scan barcode
        //record transaction with transaction detail 
        //maintain ledger of stock 
        //generate receipt
        //generate report
    }
}

