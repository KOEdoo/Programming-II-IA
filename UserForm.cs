using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.Src;

namespace InventoryManagementSystem
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {

            DataTable userTable = Admin.ViewAllUsers();
            dataGridViewUser.Rows.Clear();
            foreach(DataRow row in userTable.Rows)
            {
                dataGridViewUser.Rows.Add(row[0].ToString(), row[2].ToString(), row[3].ToString(), row[1].ToString(), row[4].ToString(), row[6].ToString() );
            }

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            UserModule userModule = new UserModule();
            userModule.saveButton.Enabled = true;
            userModule.updateButton.Enabled = false ;
            userModule.ShowDialog();
            LoadUser();

        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewUser.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                UserModule userModule = new UserModule();
                userModule.usernameInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.roleInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.nameInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.phoneInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.saveButton.Enabled = false;
                userModule.updateButton.Enabled = true;
                userModule.usernameInput.Enabled = false;
                userModule.clearButton.Enabled = false;
                userModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                string userId = dataGridViewUser.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Are You Sure You Want To Revoke This User's Access", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Admin.ChangeAccess(Convert.ToInt32(userId), "revoked");
                    MessageBox.Show("User Access Has Been Revoked");
                }
            }
            LoadUser();
        }
    }
}
