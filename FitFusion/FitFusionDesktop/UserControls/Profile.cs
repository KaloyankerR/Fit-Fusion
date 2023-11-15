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
using Services;

namespace FitFusionDesktop.UserControls
{
    public partial class Profile : UserControl
    {
        private UserManager UserManager { get; set; }
        private User CurrentUser { get; set; }

        public Profile(User user)
        {
            InitializeComponent();
            UserManager = new(new DataAcess.UserDAO());
            CurrentUser = UserManager.GetUserById(1, new Owner());

            lblRole.Text = "Owner";
            lblName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
        }
    }
}
