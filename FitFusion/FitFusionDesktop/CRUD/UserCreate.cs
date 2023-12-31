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
using Models.User;
using ReaLTaiizor.Forms;
using Services;
using Services.Sort;

namespace FitFusionDesktop.CRUD
{
    public partial class UserCreate : Form
    {
        private readonly UserManager _userManager = new(new UserDAO(), new UserSorter());

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
                        nutriPoints: 0
                        );

                    break;
                default:
                    throw new ArgumentException("Form hasn't been correctly filled.");
            }

            return user;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                User user = DefineUser();
                _userManager.CreateUser(user);
                MessageBox.Show("User successfully created.");
                Close();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
