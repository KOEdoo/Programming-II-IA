namespace InventoryManagementSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.reportButton = new InventoryManagementSystem.ProductButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productButton = new InventoryManagementSystem.ProductButton();
            this.categorybutton = new InventoryManagementSystem.ProductButton();
            this.userButton = new InventoryManagementSystem.ProductButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorybutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.reportButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.productButton);
            this.panel1.Controls.Add(this.categorybutton);
            this.panel1.Controls.Add(this.userButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 603);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 421);
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
            this.label8.Location = new System.Drawing.Point(39, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "SYSTEM";
            // 
            // reportButton
            // 
            this.reportButton.Image = ((System.Drawing.Image)(resources.GetObject("reportButton.Image")));
            this.reportButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("reportButton.ImageHover")));
            this.reportButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("reportButton.ImageNormal")));
            this.reportButton.Location = new System.Drawing.Point(38, 371);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(36, 34);
            this.reportButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reportButton.TabIndex = 13;
            this.reportButton.TabStop = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.label7.Location = new System.Drawing.Point(19, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "MANAGEMENT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.label3.Location = new System.Drawing.Point(28, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "INVENTORY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "USERS";
            // 
            // productButton
            // 
            this.productButton.Image = ((System.Drawing.Image)(resources.GetObject("productButton.Image")));
            this.productButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("productButton.ImageHover")));
            this.productButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("productButton.ImageNormal")));
            this.productButton.Location = new System.Drawing.Point(40, 95);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(36, 34);
            this.productButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productButton.TabIndex = 10;
            this.productButton.TabStop = false;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // categorybutton
            // 
            this.categorybutton.Image = ((System.Drawing.Image)(resources.GetObject("categorybutton.Image")));
            this.categorybutton.ImageHover = ((System.Drawing.Image)(resources.GetObject("categorybutton.ImageHover")));
            this.categorybutton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("categorybutton.ImageNormal")));
            this.categorybutton.Location = new System.Drawing.Point(40, 187);
            this.categorybutton.Name = "categorybutton";
            this.categorybutton.Size = new System.Drawing.Size(36, 34);
            this.categorybutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.categorybutton.TabIndex = 11;
            this.categorybutton.TabStop = false;
            this.categorybutton.Click += new System.EventHandler(this.categorybutton_Click);
            // 
            // userButton
            // 
            this.userButton.Image = ((System.Drawing.Image)(resources.GetObject("userButton.Image")));
            this.userButton.ImageHover = ((System.Drawing.Image)(resources.GetObject("userButton.ImageHover")));
            this.userButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userButton.ImageNormal")));
            this.userButton.Location = new System.Drawing.Point(40, 279);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(36, 34);
            this.userButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userButton.TabIndex = 14;
            this.userButton.TabStop = false;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "CATEGORIES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "PRODUCT";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(113, 582);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 21);
            this.panel2.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(113, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(969, 582);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("HP Simplified", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorybutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label3;
        private ProductButton productButton;
        private System.Windows.Forms.Label label1;
        private ProductButton userButton;
        private ProductButton reportButton;
        private ProductButton categorybutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}