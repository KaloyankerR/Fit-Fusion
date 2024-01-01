using DataAcess;
using Services.Filter;
using Services.Sort;
using Services;
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

namespace FitFusionDesktop
{
    public partial class ProductSuggestion : Form
    {
        private readonly ProductManager _productManger = new(new ProductDAO(), new ProductFilter(), new ProductSorter());
        private readonly OrderManager _orderManger = new(new OrderDAO());
        private readonly int _customerId;

        public ProductSuggestion(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            ProductsDataGrid.DataSource = _productManger.GetProducts();
        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt16(ProductsDataGrid.SelectedRows[0].Cells[0].Value);
            Product product = _productManger.GetProductById(selectedId);

            _orderManger.CreateMerchantRecommendation(_customerId, product);
            Close();
        }
    }
}
