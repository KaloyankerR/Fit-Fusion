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
    public partial class UserEntityControl : UserControl
    {
        private readonly UserManager _userManager = new(new UserDAO());
        private Editor parentForm;
        private User user; // keep this in mind

        public UserEntityControl(Editor frm)
        {
            InitializeComponent();
            parentForm = frm;
            btnSubmit.TextButton = "Create";
            cbxRole.SelectedItem = "Owner";
        }

        public UserEntityControl(Editor frm, User currentUser)
        {
            InitializeComponent();
            parentForm = frm;
            user = currentUser;
            btnSubmit.TextButton = "Update";
            cbxRole.SelectedItem = currentUser.GetType();
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

        private User DefineUser()
        {
            User user;

            switch (cbxRole.SelectedItem.ToString())
            {
                case "Owner":
                    user = new Owner(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );

                    break;
                case "Staff":
                    user = new Staff(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );

                    break;
                case "Customer":
                    user = new Customer(
                        id: 0,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: txtPassword.Text,
                        passwordSalt: "",
                        address: txtAddress.Text,
                        loyaltyScore: 0
                        );

                    break;
                default:
                    user = null; 
                    break;
            }

            return user;
        }

        private void CreateUser()
        {
            User user = DefineUser();
            _userManager.CreateUser(user);
        }

        private void UpdateUser()
        {
            User user = DefineUser();
            _userManager.UpdateUser(user);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.TextButton == "Create")
            {
                CreateUser();
                parentForm.DialogResult = DialogResult.OK;
            }
            else if (btnSubmit.TextButton == "Update")
            {
                UpdateUser();
                parentForm.DialogResult = DialogResult.OK;
            }

            parentForm.DialogResult = DialogResult.Cancel;
            parentForm.Close();

        }

    }
}
