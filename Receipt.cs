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
    public partial class Receipt : Form
    {
        public DataTable receiptTable;
        public Receipt(DataTable receipt)
        {
            this.receiptTable = receipt; 
            InitializeComponent();
        }

        private void crvReceipt_Load(object sender, EventArgs e)
        {
            CrystalReport.crptReceipt crpt = new CrystalReport.crptReceipt();
            crpt.Database.Tables["Receipt"].SetDataSource(receiptTable);

            crvReceipt.ReportSource = null;
            crvReceipt.ReportSource = crpt;

        }
    }
}
