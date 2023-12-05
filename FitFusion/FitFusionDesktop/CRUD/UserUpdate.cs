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
using Services;

namespace FitFusionDesktop.CRUD
{
    public partial class UserUpdate : Form
    {
        private readonly UserManager _userManager = new(new UserDAO());
        private User User { get; set; }

        public UserUpdate(User user)
        {
            InitializeComponent();
            User = user;
            FillData();
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

        private void FillData()
        {
            cbxRole.SelectedItem = User.GetUserRole();
            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            txtEmail.Text = User.Email;
            txtAddress.Text = User.Address;
            
            if (User is Owner owner)
            {
                txtPhone.Text = owner.Phone;
            }
            else if (User is Staff staff)
            {
                txtPhone.Text = staff.Phone;
            }

        }

        private User DefineUser()
        {
            User user;

            switch (cbxRole.SelectedItem.ToString())
            {
                case "Owner":
                    user = new Owner(
                        id: User.Id,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: User.PasswordHash,
                        passwordSalt: User.PasswordSalt,
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );

                    break;
                case "Staff":
                    user = new Staff(
                        id: User.Id,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: User.PasswordHash,
                        passwordSalt: User.PasswordSalt,
                        address: txtAddress.Text,
                        phone: txtPhone.Text
                        );

                    break;
                case "Customer":
                    user = new Customer(
                        id: User.Id,
                        firstName: txtFirstName.Text,
                        lastName: txtLastName.Text,
                        email: txtEmail.Text,
                        passwordHash: User.PasswordHash,
                        passwordSalt: User.PasswordSalt,
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
                _userManager.UpdateUser(user);
                MessageBox.Show("User successfully updated.");
                Close();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
