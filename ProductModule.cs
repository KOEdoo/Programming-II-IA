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
    public partial class ProductModule : Form
    {
        public ProductModule()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            categoryInput.Items.Clear();
            DataTable categoryTable = Admin.GetAllCategories();
            foreach (DataRow row in categoryTable.Rows)
            {
                categoryInput.Items.Add(new ComboBoxItem(row[0].ToString(), row[1].ToString()));
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wish To Save This Product ?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ComboBoxItem categoryId = categoryInput.SelectedItem as ComboBoxItem;
                Admin.AddProduct(barcodeInput.Text, nameInput.Text, Convert.ToInt32(categoryId.Key), Convert.ToInt32(stockInput.Text), Convert.ToInt32(reorderLevelInput.Text), Convert.ToDecimal(costPriceInput.Text), Convert.ToDecimal(sellingPriceInput.Text));
                Clear();
            }

        }

        public void Clear()
        {
            barcodeInput.Clear();
            nameInput.Clear();
            stockInput.Clear(); 
            reorderLevelInput.Clear();  
            costPriceInput.Clear();
            sellingPriceInput.Clear();
            categoryInput.Text = "";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
            saveButton.Enabled = true;
            updateButton.Enabled = false;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wish To Update This Product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ComboBoxItem categoryId = categoryInput.SelectedItem as ComboBoxItem;
                Admin.UpdateProduct(Convert.ToInt32(productIdLabel.Text), barcodeInput.Text, nameInput.Text, Convert.ToInt32(categoryId.Key), Convert.ToInt32(stockInput.Text), Convert.ToInt32(reorderLevelInput.Text), Convert.ToDecimal(costPriceInput.Text), Convert.ToDecimal(sellingPriceInput.Text));
                this.Dispose();
            }
        }
    }
}
