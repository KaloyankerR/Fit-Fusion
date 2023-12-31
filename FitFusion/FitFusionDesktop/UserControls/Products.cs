﻿using System;
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
using Interfaces;
using Services.Filter;
using Services.Sort;
using Models.Product.Enums;

namespace FitFusionDesktop.UserControls
{
    public partial class Products : UserControl
    {
        private readonly ProductManager _productManger = new(new ProductDAO(), new ProductFilter(), new ProductSorter());

        public Products()
        {
            InitializeComponent();
            RefreshFormData();
            categoryCmbBox.DataSource = Enum.GetValues(typeof(Category));
            sortCmbBox.DataSource = Enum.GetValues(typeof(SortParameter));
        }

        private void RefreshFormData()
        {
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD.ProductCreate frm = new();
                frm.ShowDialog();
                RefreshFormData();
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again later.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedId = Convert.ToInt16(ProductsDataGrid.SelectedRows[0].Cells[0].Value);
                Product product = _productManger.GetProductById(selectedId);

                CRUD.ProductUpdate frm = new(product);
                frm.ShowDialog();
                RefreshFormData();
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again later.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Product> products = _productManger.GetProducts();

            Dictionary<Enum, object> filter = new()
            {
                { FilterParameter.Category, Enum.TryParse(categoryCmbBox.SelectedItem?.ToString(), true, out Category result) ? result : Category.All }
            };

            products = _productManger.Search(_productManger.Filter(products, filter), txtSearchQuery.Text);

            if (sortCmbBox.SelectedItem is SortParameter selectedSort)
            {
                products = _productManger.Sort(products, selectedSort);
            }

            ProductsDataGrid.DataSource = products;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
