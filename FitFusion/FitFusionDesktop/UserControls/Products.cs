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
using Controllers.Product;

namespace FitFusionDesktop.UserControls
{
    public partial class Products : UserControl
    {
        private readonly ProductManager productManger;
        private List<Product> products;

        public Products()
        {
            InitializeComponent();
            productManger = new(new ProductDAO());
            products = productManger.GetProducts();
            FillDataGridViewWithMockData();
        }

        private void FillDataGridViewWithMockData()
        {
            ProductsDataGrid.DataSource = products;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            products = productManger.Search(productManger.GetProducts(), txtSearchQuery.Text);
            FillDataGridViewWithMockData();
        }

    }
}
