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
    public partial class Home : UserControl
    {
        public Home(User user)
        {
            InitializeComponent();
            label1.Text = user.FirstName + " " + user.LastName;
        }
    }
}
