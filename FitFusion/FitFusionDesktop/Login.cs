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
using Services.Filter;

namespace FitFusionDesktop
{
    public partial class Login : Form
    {
        private readonly UserManager _userManager;

        public Login()
        {
            InitializeComponent();
            _userManager = new(new UserDAO());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
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

                    MessageBox.Show("Sorry, only Staff and Owners can access the desktop application!");
                }
            }
            catch (DataAccessException)
            {
                MessageBox.Show("A problem with the database occured. Please try again later!");
            }
            catch
            {
                MessageBox.Show("Incorrect credentials. Please enter valid ones!");
            }


        }

    }
}
