using FitFusionDesktop.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Login login;

        public Main()
        {
            InitializeComponent();
            AddLogin();
        }

        private void AddLogin()
        {
            btnHome.Enabled = false;
            btnProducts.Enabled = false;
            btnUsers.Enabled = false;
            btnProfile.Enabled = false;

            login = new Login() { TopLevel = false, TopMost = true };
            login.FormBorderStyle = FormBorderStyle.None;
            MainPanel.Controls.Add(login);
            login.Show();

            login.ButtonClicked += OnChildFormButtonClicked;
        }
        
        private void ClearMainPanel()
        {
            MainPanel.Controls.Clear();
        }

        private void OnChildFormButtonClicked(object sender, EventArgs e)
        {
            btnHome.Enabled = true;
            btnProducts.Enabled = true;
            btnUsers.Enabled = true;
            btnProfile.Enabled = true;

            ClearMainPanel();

            // Add your new form here
            // For example:
            // NewForm newForm = new NewForm() { TopLevel = false, TopMost = true };
            // newForm.FormBorderStyle = FormBorderStyle.None;
            // MainPanel.Controls.Add(newForm);
            // newForm.Show();
        }


    }
}
