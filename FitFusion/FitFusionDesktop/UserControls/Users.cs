using Services;
using DataAcess;
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
using FitFusionDesktop.CRUD;
using Services.Sort;
using Models.User.Enums;

namespace FitFusionDesktop.UserControls
{
    public partial class Users : UserControl
    {
        private readonly UserManager _userManager;
        private List<User> users = new();

        public Users()
        {
            InitializeComponent();
            _userManager = new(new UserDAO(), new UserSorter());
            roleCmbBox.DataSource = Enum.GetValues(typeof(Role));
            sortCmbBox.DataSource = Enum.GetValues(typeof(SortParameter));
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<User> users = new();

            //Dictionary<Enum, object> filter = new()
            //{
            //    {FilterParameter.Role, Enum.TryParse(roleCmbBox.SelectedItem?.ToString(), true, out Role result) ? result: Role.All }
            //};

            //users = _userManager.Search(_userManager.Filter(users, filter), txtSearchQuery.Text);

            Role role = Enum.TryParse(roleCmbBox.SelectedItem?.ToString(), true, out Role result) ? result : Role.All;

            if (role == Role.Owner)
            {
                users = _userManager.GetUsers(new Owner());
            }
            else if (role == Role.Staff)
            {
                users = _userManager.GetUsers(new Staff());
            }
            else if (role == Role.Customer)
            {
                users = _userManager.GetUsers(new Customer());
            }
            else
            {
                users = _userManager.GetAllUsers();
            }

            users = _userManager.Search(users, txtSearchQuery.Text);

            if (sortCmbBox.SelectedItem is SortParameter selectedSort)
            {
                users = _userManager.Sort(users, selectedSort);
            }

            UsersDataGrid.DataSource = users;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD.UserCreate frm = new();
                frm.ShowDialog();
                btnSearch_Click(this, EventArgs.Empty);
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again later.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedEmail = UsersDataGrid.SelectedRows[0].Cells[3].Value.ToString()!;
                User user = _userManager.GetUserByEmail(selectedEmail)!;

                CRUD.UserUpdate frm = new(user);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again later.");
            }
        }

        private void btnRecommendations_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = UsersDataGrid.SelectedRows[0];
                User selectedUser = (User)selectedRow.DataBoundItem;

                Recommendations frm = new(selectedUser.Id);
                frm.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No products were bought.");
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = UsersDataGrid.SelectedRows[0];
                User selectedUser = (User)selectedRow.DataBoundItem;

                _userManager.DeleteUser(selectedUser);
                btnSearch_Click(this, EventArgs.Empty);
                MessageBox.Show("User successfully deleted.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No products were bought.");
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(this, EventArgs.Empty);
        }
    }
}
