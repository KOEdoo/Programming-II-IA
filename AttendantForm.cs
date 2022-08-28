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
    public partial class AttendantForm : Form
    {
        public Attendant user;
        public AttendantForm(Attendant user)
        {
            this.user = user;
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void orderButton_Click(object sender, EventArgs e)
        {       
            if(MessageBox.Show("Open a new Till ","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.user.StartTill();
                openChildForm(new OrderModule(this.user.Till));
            }
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            openChildForm(new AttendantProduct());
        }

        private void AttendantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new LoginForm().Show();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            openChildForm(new AttendantReport(this.user.Id));
        }
    }
}
