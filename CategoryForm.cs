using InventoryManagementSystem.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }
        public void LoadCategory()
        {

            DataTable categoryTable = Admin.GetAllCategories();
            dataGridViewCategory.Rows.Clear();
            foreach (DataRow row in categoryTable.Rows)
            {
                dataGridViewCategory.Rows.Add(row[0].ToString(), row[1].ToString());
            }

        }

        //private void addUserButton_Click(object sender, EventArgs e)
        //{
        //    UserModule userModule = new UserModule();
        //    userModule.saveButton.Enabled = true;
        //    userModule.updateButton.Enabled = false;
        //    userModule.ShowDialog();
        //    LoadCategory();

        //}

        //private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string colName = dataGridViewUser.Columns[e.ColumnIndex].Name;

        //    if (colName == "Edit")
        //    {
        //        UserModule userModule = new UserModule();
        //        userModule.usernameInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        userModule.roleInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        userModule.nameInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        userModule.phoneInput.Text = dataGridViewUser.Rows[e.RowIndex].Cells[4].Value.ToString();

        //        userModule.saveButton.Enabled = false;
        //        userModule.updateButton.Enabled = true;
        //        userModule.usernameInput.Enabled = false;
        //        userModule.clearButton.Enabled = false;
        //        userModule.ShowDialog();

        //    }
        //    else if (colName == "Delete")
        //    {
        //        string userId = dataGridViewUser.Rows[e.RowIndex].Cells[0].Value.ToString();

        //        if (MessageBox.Show("Are You Sure You Want To Revoke This User's Access", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            Admin.ChangeAccess(Convert.ToInt32(userId), "revoked");
        //            MessageBox.Show("User Access Has Been Revoked");
        //        }
        //    }
        //    LoadUser();
        //}

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryModule formModule = new CategoryModule();
            formModule.saveButton.Enabled = true;
            formModule.updateButton.Enabled = false;
            formModule.Show();
            LoadCategory();

        }

        private void dataGridViewCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewCategory.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CategoryModule categoryModule = new CategoryModule();
                categoryModule.categoryIdLabel.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                categoryModule.categoryInput.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

                categoryModule.saveButton.Enabled = false;
                categoryModule.updateButton.Enabled = true;
                categoryModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                string categoryId = dataGridViewCategory.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Are You Sure You Want To Delete This Category", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Admin.DeleteCategory(Convert.ToInt32(categoryId));
                    MessageBox.Show("Category has been Deleted");
                }
            }
            LoadCategory();
        }
    }
}
