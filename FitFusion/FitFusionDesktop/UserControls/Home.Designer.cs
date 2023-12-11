namespace FitFusionDesktop.UserControls
{
    partial class Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtCustomers = new TextBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtTotalUsers = new TextBox();
            label5 = new Label();
            txtOwners = new TextBox();
            label4 = new Label();
            txtStaff = new TextBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            txtTotalProducts = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 163, 26);
            label1.Location = new Point(392, 35);
            label1.Name = "label1";
            label1.Size = new Size(94, 35);
            label1.TabIndex = 0;
            label1.Text = "Home";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 44);
            label2.Name = "label2";
            label2.Size = new Size(171, 33);
            label2.TabIndex = 1;
            label2.Text = "Customers:";
            // 
            // txtCustomers
            // 
            txtCustomers.Enabled = false;
            txtCustomers.Location = new Point(183, 49);
            txtCustomers.Name = "txtCustomers";
            txtCustomers.Size = new Size(110, 30);
            txtCustomers.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtTotalUsers);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtOwners);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtStaff);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCustomers);
            groupBox1.Location = new Point(50, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(323, 194);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Users";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(6, 143);
            label6.Name = "label6";
            label6.Size = new Size(91, 33);
            label6.TabIndex = 7;
            label6.Text = "Total:";
            // 
            // txtTotalUsers
            // 
            txtTotalUsers.Enabled = false;
            txtTotalUsers.Location = new Point(183, 148);
            txtTotalUsers.Name = "txtTotalUsers";
            txtTotalUsers.Size = new Size(110, 30);
            txtTotalUsers.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(6, 110);
            label5.Name = "label5";
            label5.Size = new Size(128, 33);
            label5.TabIndex = 5;
            label5.Text = "Owners:";
            // 
            // txtOwners
            // 
            txtOwners.Enabled = false;
            txtOwners.Location = new Point(183, 115);
            txtOwners.Name = "txtOwners";
            txtOwners.Size = new Size(110, 30);
            txtOwners.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(6, 77);
            label4.Name = "label4";
            label4.Size = new Size(87, 33);
            label4.TabIndex = 3;
            label4.Text = "Staff:";
            // 
            // txtStaff
            // 
            txtStaff.Enabled = false;
            txtStaff.Location = new Point(183, 82);
            txtStaff.Name = "txtStaff";
            txtStaff.Size = new Size(110, 30);
            txtStaff.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtTotalProducts);
            groupBox2.Location = new Point(527, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(323, 102);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Products";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(19, 44);
            label3.Name = "label3";
            label3.Size = new Size(91, 33);
            label3.TabIndex = 7;
            label3.Text = "Total:";
            // 
            // txtTotalProducts
            // 
            txtTotalProducts.Enabled = false;
            txtTotalProducts.Location = new Point(196, 49);
            txtTotalProducts.Name = "txtTotalProducts";
            txtTotalProducts.Size = new Size(110, 30);
            txtTotalProducts.TabIndex = 8;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Home";
            Size = new Size(932, 703);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCustomers;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtTotalUsers;
        private Label label5;
        private TextBox txtOwners;
        private Label label4;
        private TextBox txtStaff;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox txtTotalProducts;
    }
}
