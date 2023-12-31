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
using Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Services.Sort;

namespace FitFusionDesktop
{
    public partial class Login : Form
    {
        private readonly UserManager _userManager;

        public Login()
        {
            InitializeComponent();
            _userManager = new(new UserDAO(), new UserSorter());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User? user = _userManager.AuthenticateUser(txtEmail.TextButton, txtPassword.TextButton);

            if (user != null && user is not Customer)
            {
                Main frm = new Main(user);
                this.Hide();
                frm.ShowDialog();
                Application.Exit();
            }
            else
            {
                txtEmail.TextButton = string.Empty;
                txtPassword.TextButton = string.Empty;

                MessageBox.Show("Incorrect login details for Staff members and Owners.");
            }

            // Owner owner = new Owner(1, "Steve", "Orlov", "steve@gmail.com", "steve@gmail.com", "", "Chicago", "555-555-123");
            // _userManager.CreateUser(owner);


        }

    }
}
