using FitFusionDesktop.UserControls;
using Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionDesktop
{
    public partial class Main : Form
    {
        public User User;

        public Main(User user)
        {
            InitializeComponent();
            User = user;
            RefreshPage();
        }

        public void ClearControls()
        {
            BodyPanel.Controls.Clear();
            btnHome.ForeColor = Color.FromArgb(255, 255, 255);
            btnProducts.ForeColor = Color.FromArgb(255, 255, 255);
            btnUsers.ForeColor = Color.FromArgb(255, 255, 255);
            btnProfile.ForeColor = Color.FromArgb(255, 255, 255);
        }

        public void RefreshPage()
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home(User));
            btnHome.ForeColor = Color.FromArgb(255, 163, 26);
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home(Email, Password));
            btnHome.ForeColor = Color.FromArgb(255, 163, 26);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Products());
            btnProducts.ForeColor = Color.FromArgb(255, 163, 26);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Users());
            btnUsers.ForeColor = Color.FromArgb(255, 163, 26);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Profile());
            btnProfile.ForeColor = Color.FromArgb(255, 163, 26);
        }
            
    }
}
