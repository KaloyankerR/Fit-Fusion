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
            lblRole.Text = user.GetUserRole();
            lblName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
        }

    }
}
