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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }
        
        public void LoadProduct(string search = null)
        {          
            dataGridViewProduct.Rows.Clear();

            DataTable productTable = Admin.GetAllProducts(search);
            foreach (DataRow row in productTable.Rows)
            {
                dataGridViewProduct.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            ProductModule productModule = new ProductModule();
            productModule.saveButton.Enabled = true;
            productModule.updateButton.Enabled = false;
            productModule.ShowDialog();
            LoadProduct();
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewProduct.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                ProductModule productModule = new ProductModule();
                productModule.productIdLabel.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                productModule.barcodeInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.nameInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.categoryInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.stockInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.reorderLevelInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.costPriceInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.sellingPriceInput.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[7].Value.ToString();

                productModule.saveButton.Enabled = false;
                productModule.updateButton.Enabled = true;
                productModule.clearButton.Enabled = false;
                productModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                string productId = dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Are You Sure You Want To Delete this Product ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Admin.DeleteProduct(Convert.ToInt32(productId));
                    MessageBox.Show("Record has been successfully deleted");
                }
            }
            LoadProduct();
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(searchInput.Text);
        }
    }
}
