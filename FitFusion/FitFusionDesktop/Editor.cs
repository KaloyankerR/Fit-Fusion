using FitFusionDesktop.CRUD;
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
    public partial class Editor : Form
    {
        public Editor(EditorMode mode)
        {
            InitializeComponent();
            ShowPage(mode);
        }

        public void ClearControls()
        {
            BodyPanel.Controls.Clear();
        }

        private void ShowPage(EditorMode mode)
        {
            switch (mode)
            {
                case EditorMode.UserCreate:
                    ClearControls();
                    BodyPanel.Controls.Add(new UserCreate());
                    break;
            }

        }

    }
}
