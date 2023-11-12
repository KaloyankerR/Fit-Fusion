namespace FitFusionDesktop.CRUD
{
    partial class UserCreate
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtAddress = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 37);
            label1.Name = "label1";
            label1.Size = new Size(50, 23);
            label1.TabIndex = 0;
            label1.Text = "Role";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Owner", "Staff", "Customer" });
            comboBox1.Location = new Point(43, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 31);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 117);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 3;
            label2.Text = "First name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(43, 143);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 30);
            txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(43, 227);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 30);
            txtLastName.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(43, 201);
            label3.Name = "label3";
            label3.Size = new Size(102, 23);
            label3.TabIndex = 5;
            label3.Text = "Last name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(307, 63);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 30);
            txtEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(307, 37);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(307, 143);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 30);
            txtPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(307, 117);
            label5.Name = "label5";
            label5.Size = new Size(98, 23);
            label5.TabIndex = 9;
            label5.Text = "Password";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(307, 227);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 30);
            txtAddress.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(307, 201);
            label6.Name = "label6";
            label6.Size = new Size(83, 23);
            label6.TabIndex = 11;
            label6.Text = "Address";
            // 
            // UserCreate
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            Controls.Add(txtAddress);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtLastName);
            Controls.Add(label3);
            Controls.Add(txtFirstName);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserCreate";
            Size = new Size(568, 565);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtAddress;
        private Label label6;
    }
}
