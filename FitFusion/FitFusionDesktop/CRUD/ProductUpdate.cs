﻿using DataAcess;
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
    public partial class ProductUpdate : Form
    {
        private readonly ProductManager _productManager = new(new ProductDAO(), new ProductFilter(), new ProductSorter());
        private Product _product;

        public ProductUpdate(Product product)
        {
            InitializeComponent();
            _product = product;
            FillData();
            cbxCategory.DataSource = Enum.GetValues(typeof(Category));
        }

        private void FillData()
        {
            txtTitle.Text = _product.Title;
            txtDescription.Text = _product.Description;
            txtPrice.Value = (decimal)_product.Price;
            txtImageUrl.Text = _product.ImageUrl;
        }

        private Product DefineProduct()
        {
            try
            {
                return new Product
                (
                    id: _product.Id,
                    title: txtTitle.Text,
                    description: txtDescription.Text,
                    price: (double)txtPrice.Value,
                    category: (Category)Enum.Parse(typeof(Category), cbxCategory.SelectedIndex.ToString()),
                    imageUrl: txtImageUrl.Text
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
                Product product = DefineProduct();
                _productManager.UpdateProduct(product);
                MessageBox.Show("Product successfully created.");
                Close();
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
