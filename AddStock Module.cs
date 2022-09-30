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
    public partial class AddStock_Module : Form
    {
        public AddStock_Module()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(productId.Text);
            int stock = Convert.ToInt32(addStock.Value);
            Admin.StockProduct(id, stock);
            this.Dispose();
        }
    }
}
