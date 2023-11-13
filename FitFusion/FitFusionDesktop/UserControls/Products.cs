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
using Services;

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

            categoryCmbBox.DataSource = Enum.GetValues(typeof(Category));
        }

        private void FillDataGridViewWithMockData()
        {
            ProductsDataGrid.DataSource = products;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Editor frm = new Editor(EditorMode.ProductCreate);

            if (!frm.IsDisposed)
            {
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Product created!");
                }
                else
                {
                    MessageBox.Show("Failed to create a product!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect mode!");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt16(ProductsDataGrid.SelectedRows[0].Cells[0].Value);
            Product product = productManger.GetProductById(selectedId);

            Editor frm = new Editor(EditorMode.ProductUpdate, product);

            if (!frm.IsDisposed)
            {
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Product updated!");
                }
                else
                {
                    MessageBox.Show("Failed to update the product!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect mode!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            products = productManger.Search(productManger.GetProducts(), txtSearchQuery.Text);
            FillDataGridViewWithMockData();
        }

        
    }
}
