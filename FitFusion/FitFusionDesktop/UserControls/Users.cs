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
            users = userManager.Search(users, txtSearchQuery.Text);
            FillDataGridViewWithMockData(users);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Editor frm = new Editor(EditorMode.UserCreate);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("User created!");
            }
            else
            {
                MessageBox.Show("Failed to create the user!");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string selectedEmail = Convert.ToString(UsersDataGrid.SelectedRows[0].Cells[3].Value);
            //User user = userManager.GetUserByEmail(selectedEmail);

            Editor frm = new Editor(EditorMode.UserUpdate, new Owner());
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("User updated!");
            }
            else
            {
                MessageBox.Show("Failed to update the user!");
            }
        }


    }
}
