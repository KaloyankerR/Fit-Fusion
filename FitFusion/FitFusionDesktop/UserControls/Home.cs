using DataAcess;
using Models.User;
using Services;
using Services.Filter;
using Services.Sort;
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
    public partial class Home : UserControl
    {
        private readonly UserManager _userManager = new(new UserDAO(), new SortUserByFirstNameAscending());
        private readonly ProductManager _productManager = new(new ProductDAO(), new FilterByCategory(), new SortProductByTitleAscending());

        public Home(User user)
        {
            InitializeComponent();
            label1.Text = user.FirstName + " " + user.LastName;
            FillData();
        }

        public void FillData()
        {
            txtCustomers.Text = _userManager.GetUsers(new Customer()).Count().ToString();
            txtStaff.Text = _userManager.GetUsers(new Staff()).Count().ToString();
            txtOwners.Text = _userManager.GetUsers(new Owner()).Count().ToString();
            txtTotalUsers.Text = _userManager.GetAllUsers().Count().ToString();
            txtTotalProducts.Text = _productManager.GetProducts().Count().ToString();
        }

    }
}
