using InventoryManagementSystem.Src;
using System;
using System.Collections;
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
    public partial class OrderModule : Form
    {
        int Till = 0;
        public OrderModule(int tillId)
        {
            InitializeComponent();
            LoadProduct();
            Till = tillId;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadProduct(string search = null)
        {
            dataGridViewProduct.Rows.Clear();

            DataTable productTable = Admin.GetAllProducts(search);
            foreach (DataRow row in productTable.Rows)
            {
                dataGridViewProduct.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[4].ToString(), row[7].ToString());
            }
        }
        int qty = 0;
        private void productQty_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(productQty.Value) > qty)
            {
                MessageBox.Show("Instock Quantity is not enough !", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productQty.Value -= 1;
                return;
            }
            try
            {
                decimal total = Convert.ToInt32(productQty.Value) * Convert.ToDecimal(productPrice.Text);
                totalPrice.Text = total.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Select a Product First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(searchInput.Text);
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productQty.Value = 0;
            productName.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            productPrice.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt32(dataGridViewProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
            productBarcode.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        ArrayList cartList = new ArrayList();
        decimal Total = 0m;

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                Attendant.FetchProduct(productBarcode.Text, ref cartList, Convert.ToInt32(productQty.Text));
                if(productQty.Value > 0)
                {
                    dataGridViewCart.Rows.Add(productName.Text, productQty.Value, productPrice.Text, totalPrice.Text);
                    Total += Convert.ToDecimal(totalPrice.Text);
                    totalPriceLabel.Text = Total.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Clear();
            }

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewCart.Columns[e.ColumnIndex].Name;

            if (colName == "Remove")
            {
                Total -= Convert.ToDecimal(dataGridViewCart.Rows[e.RowIndex].Cells[3].Value.ToString());
                totalPriceLabel.Text = Total.ToString();
                dataGridViewCart.Rows.RemoveAt(e.RowIndex);
                cartList.RemoveAt(e.RowIndex);
            }
            }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                if (MessageBox.Show("Please Confirm Order" , "Order Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Attendant.MakeSale(cartList, Till);
                }


                totalPriceLabel.Text = "";
                cartList.Clear();
                dataGridViewCart.Rows.Clear();
                dataGridViewCart.Refresh();
                Total = 0m;
                LoadProduct();
            }
            else
            {
                MessageBox.Show("Cart Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void Clear()
        {
            productQty.Value = 0;
            productBarcode.Text = "";
            productName.Clear();
            productPrice.Clear();
            totalPrice.Clear();
            searchInput.Clear();
        }

        private void OrderModule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attendant.CloseTill(Till);
        }
    }
}
