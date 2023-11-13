using DataAcess;
using Models.User;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionDesktop.CRUD
{
    public partial class UserCreate : UserControl
    {
        private readonly UserManager _userManager = new(new UserDAO());

        public UserCreate()
        {
            InitializeComponent();
            cbxRole.SelectedItem = "Owner";
        }

        private void cbxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRole.SelectedItem.ToString() == "Owner" || cbxRole.SelectedItem.ToString() == "Staff")
            {
                groupBxPhone.Visible = true;
            }
            else
            {
                groupBxPhone.Visible = false;
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (cbxRole.SelectedItem.ToString())
            {
                case "Owner":
                    Owner owner = new(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );


                    _userManager.CreateUser(owner);
                    break;
                case "Staff":
                    Staff staff = new(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );


                    _userManager.CreateUser(staff);
                    break;
                case "Customer":
                    Customer customer = new(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        loyaltyScore: 0
                        );


                    _userManager.CreateUser(customer);
                    break;
            }

        }
    }
}
