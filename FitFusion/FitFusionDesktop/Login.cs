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

namespace FitFusionDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Owner mockOwner = new Owner
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com",
                Password = "ownerpassword123",
                Address = "789 Business Street",
                Phone = "555-5678"
            };

            Main frm = new Main(mockOwner);
            this.Hide();
            frm.ShowDialog();
            Application.Exit();

            //UserDAO userDAO = new UserDAO();
            //List<User> res = userDAO.GetAllUsers(new Staff());
            //label1.Text = "neshto";
        }

    }
}
