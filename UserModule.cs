using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using InventoryManagementSystem.Src;

namespace InventoryManagementSystem
{
    public partial class UserModule : Form
    {
        public UserModule()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(password1Input.Text != passwordInput.Text)
            {
                MessageBox.Show("Password did not Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("Are You Sure You Wish To Save This User ?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                User.CreateUser(nameInput.Text, usernameInput.Text, roleInput.Text, passwordInput.Text, phoneInput.Text);
                Clear();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            nameInput.Clear();
            usernameInput.Clear();
            passwordInput.Clear();
            password1Input.Clear();
            phoneInput.Clear();
        }

    

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (password1Input.Text != passwordInput.Text)
            {
                MessageBox.Show("Password did not Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are You Sure You Wish To Update This User", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Admin.UpdateUser(nameInput.Text, usernameInput.Text, roleInput.Text, passwordInput.Text, phoneInput.Text);
                this.Dispose();
            }
        }

    }
}
