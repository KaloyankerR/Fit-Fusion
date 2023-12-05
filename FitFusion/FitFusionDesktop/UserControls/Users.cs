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

namespace FitFusionDesktop.UserControls
{
    public partial class Users : UserControl
    {
        private readonly UserManager userManager;
        private List<User> users;

        public Users()
        {
            InitializeComponent();
            userManager = new(new UserDAO());
            roleCmbBox.SelectedIndex = 2;
        }

        private void FillDataGridViewWithMockData(List<User> users)
        {
            UsersDataGrid.DataSource = users;
        }

        private void roleCmbBox_SelectedIndexChanged(object sender, EventArgs e)
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

            FillDataGridViewWithMockData(users);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            users = userManager.Search(users, txtSearchQuery.Text);
            FillDataGridViewWithMockData(users);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD.UserCreate frm = new();
                frm.ShowDialog();
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
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No products were bought.");
            }
            catch (ApplicationException ex)
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
                MessageBox.Show("User successfully deleted.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No products were bought.");
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
