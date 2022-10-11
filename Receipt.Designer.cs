
namespace InventoryManagementSystem
{
    partial class Receipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvReceipt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReceipt
            // 
            this.crvReceipt.ActiveViewIndex = -1;
            this.crvReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReceipt.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReceipt.DisplayStatusBar = false;
            this.crvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReceipt.Location = new System.Drawing.Point(0, 0);
            this.crvReceipt.Name = "crvReceipt";
            this.crvReceipt.Size = new System.Drawing.Size(800, 450);
            this.crvReceipt.TabIndex = 0;
            this.crvReceipt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvReceipt.Load += new System.EventHandler(this.crvReceipt_Load);
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvReceipt);
            this.Name = "Receipt";
            this.Text = "Receipt";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReceipt;
    }
}