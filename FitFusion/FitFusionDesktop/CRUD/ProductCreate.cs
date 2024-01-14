using DataAcess;
using Models.Product;
using Models.Product.Enums;
using Services;
using Services.Filter;
using Services.Sort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionDesktop.CRUD
{
    public partial class ProductCreate : Form
    {
        private readonly ProductManager _productManager = new(new ProductDAO());

        public ProductCreate()
        {
            InitializeComponent();
            cbxCategory.DataSource = Enum.GetValues(typeof(Category));
        }

        private Product DefineProduct()
        {
            try
            {
                return new Product
                (
                    id: 0,
                    title: txtTitle.Text,
                    description: string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text,
                    price: (double)txtPrice.Value,
                    category: (Category)Enum.Parse(typeof(Category), cbxCategory.SelectedIndex.ToString()),
                    imageUrl: string.IsNullOrWhiteSpace(txtImageUrl.Text) ? null : txtImageUrl.Text
                );
            }
            catch (Exception)
            {
                throw new ArgumentException("Form hasn't been correctly filled.");
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Category)Enum.Parse(typeof(Category), cbxCategory.SelectedIndex.ToString()) != Category.All)
                {
                    Product product = DefineProduct();
                    _productManager.CreateProduct(product);
                    MessageBox.Show("Product successfully created.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Please change category to be different than All.");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
