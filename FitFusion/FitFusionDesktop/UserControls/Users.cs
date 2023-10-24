using Controllers.User;
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
            // FillDataGridViewWithMockData("Customers");
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
            users = userManager.SearchFilter(users, txtSearchQuery.Text);
            FillDataGridViewWithMockData(users);
        }
    }
}
