using FitFusionDesktop.UserControls;
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
        public Main()
        {
            InitializeComponent();
            RefreshPage();
        }

        public void ClearControls()
        {
            BodyPanel.Controls.Clear();
        }

        public void RefreshPage()
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home());
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Home());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ClearControls();
            BodyPanel.Controls.Add(new Products());
        }


    }
}
