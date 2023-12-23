using Services;
using DataAcess;
using Models.Product;
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

namespace FitFusionDesktop.UserControls
{
    public partial class Users : UserControl
    {
        private readonly UserManager userManager;
        private List<User> users = new();

        public Users()
        {
            InitializeComponent();
            userManager = new(new UserDAO(), new SortUserByFirstNameAscending());
            roleCmbBox.SelectedIndex = 2;
        }

        private void RefreshFormData()
        {
            if (roleCmbBox.SelectedItem.ToString() == "Owners")
            {
                users = userManager.GetUsers(new Owner());
            }
            else if (roleCmbBox.SelectedItem.ToString() == "Staff")
            {
                users = userManager.GetUsers(new Staff());
            }
            else
            {
                users = userManager.GetUsers(new Customer());
            }

            users = userManager.Search(users, txtSearchQuery.Text);
            UsersDataGrid.DataSource = users;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void roleCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD.UserCreate frm = new();
                frm.ShowDialog();
                RefreshFormData();
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
                User user = userManager.GetUserByEmail(selectedEmail)!;

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

                userManager.DeleteUser(selectedUser);
                RefreshFormData();
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
            RefreshFormData();
        }
    }
}
