using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace InventoryManagementSystem.Src
{
    internal class Admin : User
    {
        public Admin()
        {
        }

        public static void AddCategory(string name)
        {
            try
            {
                string query = "INSERT INTO category VALUES (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");
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
        public static void UpdateCategory(int Id, string name)
        {
            try
            {
                string query = "UPDATE category SET name = @name WHERE categoryId = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Updated");
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

        public static DataTable GetAllCategories()
        {
            DataTable categoryTable = new DataTable(); ;
            try
            {
                string query = "SELECT * FROM category";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(categoryTable);
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
            return categoryTable;
        }

        public static void DeleteCategory(int id)
        {
            try
            {
                string query = "DELETE FROM category WHERE categoryId= @Id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
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

        public static void AddProduct(string barcode, string name, int categoryId, int stock, int reorderLevel, decimal costPrice, decimal sellingPrice)
        {
            try
            {
                string query = "INSERT INTO product(barcode, name, categoryId, stock, reorderLevel, costPrice, sellingPrice) VALUES(@Barcode, @Name, @CategoryId, @Stock, @ReorderLevel, @CostPrice, @SellingPrice)";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Barcode", barcode);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                sqlCommand.Parameters.AddWithValue("@Stock", stock);
                sqlCommand.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                sqlCommand.Parameters.AddWithValue("@CostPrice", costPrice);
                sqlCommand.Parameters.AddWithValue("@SellingPrice", sellingPrice);

                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Product Added");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Duplicate Barcode Inserted");
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

        public static DataTable GetAllProducts(string search = "")
        {
            DataTable productTable = new DataTable(); ;
            try
            {
                string query = "SELECT product.productId, product.barcode, product.name, category.name as category, product.stock, product.reorderLevel, product.costPrice, product.sellingPrice FROM product INNER JOIN category ON (product.categoryId = category.categoryId) WHERE CONCAT(product.name,category.name, product.barcode) LIKE '%"+search+"%'";
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
        public static void DeleteProduct(int id)
        {
            try
            {
                string query = "DELETE FROM product WHERE productId= @Id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
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
        // update product ??
        public static void UpdateProduct(int id, string barcode, string name, int categoryId, int stock, int reorderLevel, decimal costPrice, decimal sellingPrice)
        {
            try
            {
                string query = "UPDATE product SET barcode = @Barcode, name = @Name, categoryId = @CategoryId, stock = @Stock, reorderLevel = @ReorderLevel, costPrice = @costPrice, sellingPrice = @SellingPrice WHERE productId = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Barcode", barcode);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                sqlCommand.Parameters.AddWithValue("@Stock", stock);
                sqlCommand.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                sqlCommand.Parameters.AddWithValue("@CostPrice", costPrice);
                sqlCommand.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Product Updated");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Duplicate Barcode Inserted");
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
        // stock product
        public static void StockProduct(int id, int stock)
        {
            try
            {
                string query = "UPDATE product SET stock += @Stock WHERE productId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Stock", stock);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Stock added");

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
        //view users
        public static DataTable ViewAllUsers()
        {
            DataTable userTable = new DataTable();
            try
            {
                string query = "SELECT * FROM [user]";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(userTable);
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
            return userTable;
        }
        public static void UpdateUser( string name, string username, string role, string password, string phoneNumber)
        {
            string passwordHash = SecurePassword.HashPassword(password);
            try
            {
                string query = "UPDATE [user] SET name=@name, role=@role, password=@password, phoneNumber=@phoneNumber WHERE username = @username";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@role", role);
                sqlCommand.Parameters.AddWithValue("@password", passwordHash);
                sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("User has been successfully updated !");
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
        //revoke user access
        //reset user password (Change Access to reset)
        public static void ChangeAccess(int id, string status)
        {
            try
            {
                string query = "UPDATE [user] SET access = @Status WHERE userId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Status", status);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
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
        //generate report
        public static DataTable GetDailyReport(Boolean all = false)
        {
            DataTable reportTable = new DataTable();
            try
            {
                string query = "SELECT till.tillId, [transaction].transactionId, [transaction].total, [user].name  FROM till INNER JOIN [user] ON (till.userId = [user].userId) INNER JOIN [transaction] ON (till.tillId = [transaction].tillId)";
                if (all == false)
                    query += "WHERE  CAST(time AS DATE) = CAST(GETDATE() AS DATE)";
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
    }

}
/*try
{

}
catch (Exception e)
{
    MessageBox.Show(e.ToString());
}
finally
{
    Connection.Close();
}*/