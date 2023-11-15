using DataAcess;
using Models.Product;
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

namespace FitFusionDesktop.CRUD
{
    public partial class ProductEntityControl : UserControl
    {
        private readonly ProductManager _productManager = new(new ProductDAO());
        private readonly EditorMode _currentMode;
        private readonly Product _currentProduct;
        private readonly Editor parentForm;

        public ProductEntityControl(Editor frm, EditorMode mode, Product currentProduct = null)
        {
            InitializeComponent();
            parentForm = frm;
            _currentProduct = currentProduct;
            _currentMode = mode;
            cbxCategory.DataSource = Enum.GetValues(typeof(Category));

            ConfigureMode();
        }

        private void ConfigureMode()
        {
            switch (_currentMode)
            {
                case EditorMode.ProductCreate:
                    btnSubmit.TextButton = "Create";
                    break;
                case EditorMode.ProductUpdate:
                    txtTitle.Text = _currentProduct.Title;
                    txtDescription.Text = _currentProduct.Description;
                    txtPrice.Value = (decimal)_currentProduct.Price;
                    cbxCategory.SelectedItem = _currentProduct.Category;
                    txtImageUrl.Text = _currentProduct.ImageUrl;
                    btnSubmit.TextButton = "Update";
                    break;
            }

        }

        private Product DefineProduct()
        {
            Product product;

            if (_currentMode == EditorMode.ProductCreate)
            {
                product = new()
                {
                    Id = 0,
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    Price = (double)txtPrice.Value,
                    Category = (Category)Enum.Parse(typeof(Category), cbxCategory.SelectedIndex.ToString()),
                    ImageUrl = txtImageUrl.Text
                };
            }
            else if (_currentMode == EditorMode.ProductUpdate)
            {
                product = new()
                {
                    Id = _currentProduct.Id,
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    Price = (double)txtPrice.Value,
                    Category = (Category)Enum.Parse(typeof(Category), cbxCategory.SelectedIndex.ToString()),
                    ImageUrl = txtImageUrl.Text
                };
            }
            else
            {
                product = null;
            }

            return product;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Product product = DefineProduct();

            if (btnSubmit.TextButton == "Create")
            {
                if (_productManager.CreateProduct(product))
                {
                    parentForm.DialogResult = DialogResult.OK;
                    parentForm.Close();
                }
                else
                {
                    parentForm.DialogResult = DialogResult.Cancel;
                    parentForm.Close();
                }
            }
            else if (btnSubmit.TextButton == "Update")
            {
                if(_productManager.UpdateProduct(product))
                {
                    parentForm.DialogResult = DialogResult.OK;
                    parentForm.Close();
                }
                else
                {
                    parentForm.DialogResult = DialogResult.Cancel;
                    parentForm.Close();
                }
            }
        }

    }
}
