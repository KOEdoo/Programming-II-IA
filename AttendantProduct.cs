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
    public partial class AttendantProduct : Form
    {
        public AttendantProduct()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct(string search = null)
        {
            dataGridViewProduct.Rows.Clear();

            DataTable productTable = Attendant.GetAllProducts(search);
            foreach (DataRow row in productTable.Rows)
            {
                dataGridViewProduct.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }
        }

    private void searchInput_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(searchInput.Text);
        }
    }
}
