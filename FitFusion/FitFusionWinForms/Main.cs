using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionWinForms
{
    public partial class Main : Form
    {
        bool sidebarExpand;
        public Main()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;

                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void ClearMainPanel()
        {
            MainPanel.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearMainPanel();
            ChildForm child = new ChildForm() { TopLevel = false, TopMost = true };
            child.FormBorderStyle = FormBorderStyle.None;
            MainPanel.Controls.Add(child);
            child.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearMainPanel();
            Child2 child = new Child2() { TopLevel = false, TopMost= true };
            child.FormBorderStyle = FormBorderStyle.None;
            MainPanel.Controls.Add(child);
            child.Show();
        }

    }
}
