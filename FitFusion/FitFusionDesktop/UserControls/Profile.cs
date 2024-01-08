using Services;
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
using UserModel = Models.User.User;
using DataAcess;
using Microsoft.VisualBasic.ApplicationServices;
using Services.Sort;
using Services.Filter;

namespace FitFusionDesktop.UserControls
{
    public partial class Profile : UserControl
    {
        private readonly UserManager _userManager = new(new UserDAO());
        private UserModel CurrentUser;

        public Profile(UserModel user)
        {
            InitializeComponent();
            CurrentUser = user;
            lblRole.Text = $"Role: {user.GetUserRole()}";
            lblName.Text = $"Full name: {CurrentUser}";
            lblEmail.Text = $"Email: {CurrentUser.Email}";
            lblAddress.Text = $"Address: {CurrentUser.Address}";
        }

    }
}
