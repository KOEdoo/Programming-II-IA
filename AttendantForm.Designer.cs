namespace InventoryManagementSystem
{
    partial class AttendantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendantForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.reportButton = new InventoryManagementSystem.ProductButton();
            this.orderButton = new InventoryManagementSystem.ProductButton();
            this.productButton = new InventoryManagementSystem.ProductButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.reportButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.orderButton);
            this.panel1.Controls.Add(this.productButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 603);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "REPORTS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.label8.Location = new System.Drawing.Point(39, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "SYSTEM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.label7.Location = new System.Drawing.Point(19, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "MANAGEMENT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "TILL\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "INVENTORY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "PRODUCT";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(128, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(954, 603);
            this.panelMain.TabIndex = 2;
            // 
            // reportButton
            // 
            this.reportButton.Image = ((System.Drawing.Image)(resources.GetObject("reportButton.Image")));
            this.reportButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("reportButton.ImageHover")));
            this.reportButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("reportButton.ImageNormal")));
            this.reportButton.Location = new System.Drawing.Point(38, 323);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(36, 38);
            this.reportButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reportButton.TabIndex = 13;
            this.reportButton.TabStop = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Image = ((System.Drawing.Image)(resources.GetObject("orderButton.Image")));
            this.orderButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("orderButton.ImageHover")));
            this.orderButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("orderButton.ImageNormal")));
            this.orderButton.Location = new System.Drawing.Point(38, 215);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(36, 38);
            this.orderButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.orderButton.TabIndex = 12;
            this.orderButton.TabStop = false;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // productButton
            // 
            this.productButton.Image = ((System.Drawing.Image)(resources.GetObject("productButton.Image")));
            this.productButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("productButton.ImageHover")));
            this.productButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("productButton.ImageNormal")));
            this.productButton.Location = new System.Drawing.Point(40, 107);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(36, 38);
            this.productButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productButton.TabIndex = 10;
            this.productButton.TabStop = false;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // AttendantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("HP Simplified", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttendantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendantForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AttendantForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private ProductButton reportButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private ProductButton orderButton;
        private ProductButton productButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
    }
}