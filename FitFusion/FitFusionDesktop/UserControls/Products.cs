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
using FitFusionDesktop.EntityControls;

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

            var newItem = new ReaLTaiizor.Child.Crown.CrownDropDownItem
            {
                Text = "Your Text Here"
            };
            var newItem2 = new ReaLTaiizor.Child.Crown.CrownDropDownItem
            {
                Text = "Your Text Here2"
            };


            crownDropDownList1.Items.Add(newItem);
            crownDropDownList1.Items.Add(newItem2);
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
        }
    }
}
