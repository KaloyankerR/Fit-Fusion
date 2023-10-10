using DataAcess;
using Models.Product;
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
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            FillDataGridViewWithMockData();
        }

        private void FillDataGridViewWithMockData()
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Treadmill", "High-performance treadmill for home use", null),
                new Product(2, "Protein Powder", "Premium whey protein isolate", null),
                new Product(3, "Yoga Mat", "Non-slip yoga mat with carry strap", null),
            };

            UsersDataGrid.DataSource = products;
        }

    }
}
