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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void showPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheck.Checked == false)
                passwordInput.UseSystemPasswordChar = true;
            else
                passwordInput.UseSystemPasswordChar = false;
        }

        private void clearLabel_Click(object sender, EventArgs e)
        {
            passwordInput.Clear();
            usernameInput.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
               int id = User.LoginUser(usernameInput.Text, passwordInput.Text, out string userAccess, out string userRole);
                if(userAccess == "revoked")
                {
                    MessageBox.Show("User Access has been revoked", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if(userRole == "admin")
                    {
                        MainForm main = new MainForm();
                        this.Hide();
                        main.ShowDialog();
                        return;
                    }
                    else if(userRole == "attendant")
                    {
                        Attendant user = new Attendant(id);
                        AttendantForm  attendant = new AttendantForm(user);
                        this.Hide();
                        attendant.ShowDialog();
                        return ;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Username and Password are Incorrect", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            MessageBox.Show("Enter a Valid Username and Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
