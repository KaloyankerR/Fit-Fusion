using Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcess;
using Controllers;

namespace FitFusionDesktop
{
    public partial class Login : Form
    {
        private readonly UserManager userManager;

        public Login()
        {
            InitializeComponent();
            userManager = new(new UserDAO());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User owner = userManager.GetUserByEmail(txtEmail.TextButton, new Owner());

            Main frm = new Main(owner);
            this.Hide();
            frm.ShowDialog();
            Application.Exit();

            //if (userManager.AuthenticateUser(txtEmail.TextButton, txtPassword.TextButton))
            //{
            //    User owner = userManager.GetUserByEmail(txtEmail.TextButton, new Owner());

            //    Main frm = new Main(owner);
            //    this.Hide();
            //    frm.ShowDialog();
            //    Application.Exit();
            //}
            //else if (userManager.AuthenticateUser(txtEmail.TextButton, txtPassword.TextButton, "Staff"))
            //{
            //    Staff staff = (Staff)userManager.GetUserByEmail(txtEmail.Text, new Staff());

            //    Main frm = new Main(staff);
            //    this.Hide();
            //    frm.ShowDialog();
            //    Application.Exit();
            //}
            //else
            //{
            //    txtEmail.Text = "";
            //    txtPassword.Text = "";

            //    MessageBox.Show("Incorrect credentials!");
            //}

        }

    }
}
