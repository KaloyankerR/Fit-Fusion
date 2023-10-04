using System.Windows.Forms;

namespace GymAppWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_users = new System.Windows.Forms.Panel();
            this.btn_users = new System.Windows.Forms.Button();
            this.pnl_products = new System.Windows.Forms.Panel();
            this.btn_products = new System.Windows.Forms.Button();
            this.pnl_home = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.PnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnl_users.SuspendLayout();
            this.pnl_products.SuspendLayout();
            this.pnl_home.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.tableLayoutPanel1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1182, 87);
            this.PnlMain.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pnl_users, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnl_products, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnl_home, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnl_users
            // 
            this.pnl_users.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pnl_users.Controls.Add(this.btn_users);
            this.pnl_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_users.Location = new System.Drawing.Point(791, 5);
            this.pnl_users.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.pnl_users.Name = "pnl_users";
            this.pnl_users.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnl_users.Size = new System.Drawing.Size(386, 82);
            this.pnl_users.TabIndex = 5;
            // 
            // btn_users
            // 
            this.btn_users.BackColor = System.Drawing.Color.Silver;
            this.btn_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_users.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_users.FlatAppearance.BorderSize = 0;
            this.btn_users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_users.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_users.ForeColor = System.Drawing.Color.Black;
            this.btn_users.Image = ((System.Drawing.Image)(resources.GetObject("btn_users.Image")));
            this.btn_users.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_users.Location = new System.Drawing.Point(0, 0);
            this.btn_users.Margin = new System.Windows.Forms.Padding(0);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(386, 76);
            this.btn_users.TabIndex = 1;
            this.btn_users.Text = "Users";
            this.btn_users.UseVisualStyleBackColor = false;
            this.btn_users.Click += new System.EventHandler(this.Btn_Click);
            // 
            // pnl_products
            // 
            this.pnl_products.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pnl_products.Controls.Add(this.btn_products);
            this.pnl_products.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_products.Location = new System.Drawing.Point(398, 5);
            this.pnl_products.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.pnl_products.Name = "pnl_products";
            this.pnl_products.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnl_products.Size = new System.Drawing.Size(383, 82);
            this.pnl_products.TabIndex = 4;
            // 
            // btn_products
            // 
            this.btn_products.BackColor = System.Drawing.Color.Silver;
            this.btn_products.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_products.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_products.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_products.FlatAppearance.BorderSize = 0;
            this.btn_products.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_products.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_products.ForeColor = System.Drawing.Color.Black;
            this.btn_products.Image = ((System.Drawing.Image)(resources.GetObject("btn_products.Image")));
            this.btn_products.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_products.Location = new System.Drawing.Point(0, 0);
            this.btn_products.Margin = new System.Windows.Forms.Padding(0);
            this.btn_products.Name = "btn_products";
            this.btn_products.Size = new System.Drawing.Size(383, 76);
            this.btn_products.TabIndex = 1;
            this.btn_products.Text = "Products";
            this.btn_products.UseVisualStyleBackColor = false;
            this.btn_products.Click += new System.EventHandler(this.Btn_Click);
            // 
            // pnl_home
            // 
            this.pnl_home.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pnl_home.Controls.Add(this.btn_home);
            this.pnl_home.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_home.Location = new System.Drawing.Point(5, 5);
            this.pnl_home.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.pnl_home.Name = "pnl_home";
            this.pnl_home.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnl_home.Size = new System.Drawing.Size(383, 82);
            this.pnl_home.TabIndex = 3;
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.Silver;
            this.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_home.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_home.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_home.ForeColor = System.Drawing.Color.Black;
            this.btn_home.Image = ((System.Drawing.Image)(resources.GetObject("btn_home.Image")));
            this.btn_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_home.Location = new System.Drawing.Point(0, 0);
            this.btn_home.Margin = new System.Windows.Forms.Padding(0);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(383, 76);
            this.btn_home.TabIndex = 1;
            this.btn_home.Text = "Home";
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.Btn_Click);
            // 
            // pnl_main
            // 
            this.pnl_main.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_main.BackgroundImage")));
            this.pnl_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_main.Controls.Add(this.label3);
            this.pnl_main.Controls.Add(this.label2);
            this.pnl_main.Controls.Add(this.label1);
            this.pnl_main.Controls.Add(this.btn_login);
            this.pnl_main.Controls.Add(this.tb_pw);
            this.pnl_main.Controls.Add(this.tb_email);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 87);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1182, 616);
            this.pnl_main.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(493, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "SIGN IN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(362, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(362, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email:";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Silver;
            this.btn_login.ForeColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(467, 281);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(211, 54);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Log In";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_pw
            // 
            this.tb_pw.BackColor = System.Drawing.Color.Silver;
            this.tb_pw.ForeColor = System.Drawing.Color.Black;
            this.tb_pw.Location = new System.Drawing.Point(444, 231);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.Size = new System.Drawing.Size(252, 27);
            this.tb_pw.TabIndex = 1;
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.Silver;
            this.tb_email.ForeColor = System.Drawing.Color.Black;
            this.tb_email.Location = new System.Drawing.Point(444, 184);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(252, 27);
            this.tb_email.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.PnlMain);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GymShopify";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnl_users.ResumeLayout(false);
            this.pnl_products.ResumeLayout(false);
            this.pnl_home.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.pnl_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel PnlMain;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnl_users;
        private Button btn_users;
        private Panel pnl_products;
        private Button btn_products;
        private Panel pnl_home;
        private Button btn_home;
        private Panel pnl_main;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_login;
        private TextBox tb_pw;
        private TextBox tb_email;
    }
}