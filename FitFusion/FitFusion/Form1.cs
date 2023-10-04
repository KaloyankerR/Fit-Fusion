using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymAppWinForm
{
    public partial class Form1 : Form
    {
        //private readonly AuthenticationService authentication;
        //private bool isLoggedIn = false;
        //private User loginSuccessful;
        public Form1()
        {
            //IUserRepository userRepository = new UserRepository();
            //authentication = new AuthenticationService(userRepository);
            InitializeComponent();
        }

        private void add_UControls(UserControl userControl)
        {
            //if (isLoggedIn)
            //{
            //    userControl.Dock = DockStyle.Fill;
            //    pnl_main.Controls.Clear();
            //    pnl_main.Controls.Add(userControl);
            //    userControl.BringToFront();
            //}
            //else
            //{
            //    MessageBox.Show("Please log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }


        private void Btn_Click(object sender, EventArgs e)
        {
        //    if (isLoggedIn)
        //    {
        //        foreach (var pnl in tableLayoutPanel1.Controls.OfType<Panel>())
        //            pnl.BackColor = Color.Silver;

        //        Button btn = (Button)sender;
        //        switch (btn.Name)
        //        {
        //            case "btn_home":
        //                add_UControls(new UC_Home(loginSuccessful));
        //                pnl_home.BackColor = Color.MediumSeaGreen;
        //                break;
        //            case "btn_products":
        //                add_UControls(new UC_Products());
        //                pnl_products.BackColor = Color.MediumSeaGreen;
        //                break;
        //            case "btn_users":
        //                add_UControls(new UC_User());
        //                pnl_users.BackColor = Color.MediumSeaGreen;
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowLoginForm()
        {
            //Form1 formLogin = new Form1();
            //formLogin.ShowDialog();

            //if (formLogin.loginSuccessful != null)
            //{
            //    isLoggedIn = true; 
            //}
            //else
            //{
            //    Close();
            //}

        }
        public void Logout()
        {
            //isLoggedIn = false; 
            //pnl_main.Controls.Clear(); 
            //ShowLoginForm(); 
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        loginSuccessful = authentication.CheckLogin(tb_email.Text, tb_pw.Text);

        //        if (loginSuccessful != null && loginSuccessful.UserType == UserType.Admin)
        //        {
        //            isLoggedIn = true;
        //            add_UControls(new UC_Home(loginSuccessful));
        //        }
        //        else if (loginSuccessful != null && loginSuccessful.UserType == UserType.Customer)
        //        {
        //            MessageBox.Show("Access denied. Only admin accounts are allowed to log in.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid login credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }
    }
}