using FitFusionDesktop.UserControls;
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
        public string Email;
        public string Password;

        public Main(string email, string password)
        {
            InitializeComponent();
            Email = email;
            Password = password;
            RefreshPage();
        }

        public void ClearControls()
        {
            BodyPanel.Controls.Clear();
        }

        public void RefreshPage()
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home(Email, Password));
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home(Email, Password));
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Products());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Users());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Profile());
        }
            
    }
}
