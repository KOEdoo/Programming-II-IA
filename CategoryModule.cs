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
    public partial class CategoryModule : Form
    {
        public CategoryModule()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wish To Save This Category ?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Admin.AddCategory(categoryInput.Text);
            }
            Clear();
        }
        public void Clear()
        {
            categoryInput.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
            saveButton.Enabled = true;
            updateButton.Enabled = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wish To Update This Category", "Updating Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Admin.UpdateCategory(Convert.ToInt32(categoryIdLabel.Text), categoryInput.Text);
            }
            }
    }
}
