using FitFusionDesktop.CRUD;
using Microsoft.VisualBasic.ApplicationServices;
using Models.Product;
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

namespace FitFusionDesktop
{
    public partial class Editor : Form
    {
        private UserModel userParam = null;
        private Product product = new();

        public Editor(EditorMode mode)
        {
            InitializeComponent();
            ShowPage(mode);
        }

        public Editor(EditorMode mode, UserModel user)
        {
            InitializeComponent();
            userParam = user;
            ShowPage(mode);
        }

        public Editor(EditorMode mode, Product productParam)
        {
            InitializeComponent();
            product = productParam;
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
                    BodyPanel.Controls.Add((Control)new CRUD.UserEntityControl(this));
                    break;
                case EditorMode.UserUpdate:
                    ClearControls();
                    BodyPanel.Controls.Add((Control)new CRUD.UserEntityControl(this, userParam));
                    break;
                case EditorMode.ProductCreate:
                    ClearControls();
                    BodyPanel.Controls.Add((Control)new CRUD.ProductEntityControl(this, mode));
                    break;
                case EditorMode.ProductUpdate:
                    ClearControls();
                    BodyPanel.Controls.Add((Control)new CRUD.ProductEntityControl(this, mode, product));
                    break;
                default:
                    DialogResult = DialogResult.Cancel;
                    Close();
                    break;
            }

        }

    }
}
