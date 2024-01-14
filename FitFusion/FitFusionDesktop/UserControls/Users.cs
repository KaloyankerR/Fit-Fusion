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
using Services.Filter;
using Interfaces.Strategy;
using Models.Product;
using Interfaces;

namespace FitFusionDesktop.UserControls
{
    public partial class Users : UserControl
    {
        private readonly UserManager _userManager;

        public Users()
        {
            InitializeComponent();
            _userManager = new(new UserDAO());
            roleCmbBox.DataSource = Enum.GetValues(typeof(Role));
            sortCmbBox.DataSource = Enum.GetValues(typeof(SortParameter));
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch ((Role)roleCmbBox.SelectedItem)
            {
                case Role.Customer:
                    btnRecommendations.Visible = true;
                    break;
                default:
                    btnRecommendations.Visible = false;
                    break;
            }

            List<User> users = _userManager.GetAllUsers();

            List<IFilter<User>> filters = new()
            {
                { new KeywordFilterStrategy(txtSearchQuery.Text) },
                { new RoleFilterStrategy(Enum.TryParse(roleCmbBox.SelectedItem?.ToString(), true, out Role result) ? result : Role.All) }
            };

            users = _userManager.Filter(users, filters);

            if (sortCmbBox.SelectedItem is SortParameter selectedSort)
            {
                ISort<User> sorter;

                switch (selectedSort)
                {
                    case SortParameter.FirstNameAscending:
                        sorter = new FirstNameAscending();
                        break;
                    case SortParameter.FirstNameDescending:
                        sorter = new FirstNameDescending();
                        break;
                    case SortParameter.LastNameAscending:
                        sorter = new LastNameAscending();
                        break;
                    case SortParameter.LastNameDescending:
                        sorter = new LastNameDescending();
                        break;
                    default:
                        sorter = new FirstNameAscending();
                        break;
                }
                
                users = _userManager.Sort(users, sorter);
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

        private void roleCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
