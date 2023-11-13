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
        private User user = new Owner(); // keep this in mind

        public UserEntityControl(Editor frm)
        {
            parentForm = frm;
            btnSubmit.TextButton = "Create";
            InitializeComponent();
            cbxRole.SelectedItem = "Owner";
        }

        //public UserEntityControl(Editor frm, User currentUser)
        //{
        //    parentForm = frm;
        //    btnSubmit.TextButton = "Update";
        //    user = currentUser;
        //    InitializeComponent();
        //}

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

        private void CreateUser()
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

        private void UpdateUser()
        {

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
