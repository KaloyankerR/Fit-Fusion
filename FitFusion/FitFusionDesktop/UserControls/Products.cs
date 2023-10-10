using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Product;
using DataAcess;


namespace FitFusionDesktop.UserControls
{
    public partial class Products : UserControl
    {
        public ProductDAO ProductDAO;

        public Products()
        {
            ProductDAO = new ProductDAO();
            InitializeComponent();
            FillDataGridViewWithMockData();

            ProductsDataGrid.BackgroundColor = Color.FromArgb(255, 163, 26);
            ProductsDataGrid.GridColor = Color.FromArgb(255, 163, 26);
            // ProductsDataGrid.Color

        }

        private void FillDataGridViewWithMockData()
        {
            //List<Product> products = new List<Product>
            //{
            //    new Product(1, "Treadmill", "High-performance treadmill for home use", null),
            //    new Product(2, "Protein Powder", "Premium whey protein isolate", null),
            //    new Product(3, "Yoga Mat", "Non-slip yoga mat with carry strap", null),
            //};

            List<Product> products = ProductDAO.GetAllProducts();
            ProductsDataGrid.DataSource = products;
        }

    }
}
