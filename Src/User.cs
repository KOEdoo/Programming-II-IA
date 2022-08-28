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
    public class User
    {
        public int Id { get; set; }
      

        private static string connectionString = ConfigurationManager.ConnectionStrings["InventorySystem.Properties.Settings.LearningDb2ConnectionString"].ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionString);

        public static SqlConnection Connection { get { return connection; } }

        public static void CreateUser(string name, string username, string role, string password, string phoneNumber)
        {
            string passwordHash = SecurePassword.HashPassword(password);
            try
            {
                string query = "INSERT INTO [user](name,username,role,password,phoneNumber) VALUES (@name, @username, @role, @password, @phoneNumber)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@role", role);
                sqlCommand.Parameters.AddWithValue("@password", passwordHash);
                sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("User Successfully Created");
            }
            // catch error for username already existing
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Username already Exists ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static int LoginUser(string username, string password, out string userAccess, out string userRole)
        {
            string passwordHash = "";
            string access = "";
            string role = "";
            int userId = 0 ;
            try
            {
                string query = "SELECT * FROM [user] WHERE username=@Username";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Username", username);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    userId = Convert.ToInt32(reader["userId"].ToString());
                    role = reader["role"].ToString();
                    passwordHash = reader["password"].ToString();
                    access = reader["access"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
                userAccess = access;
                userRole = role;
            }
            if (access == "granted")
            {
                SecurePassword.VerifyPassword(password, passwordHash);
            }
            return userId;
        }
    }
}

