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

namespace FitFusionDesktop.UserControls
{
    public partial class Products : UserControl
    {
        private readonly ProductManager productManger = new(new ProductDAO(), new FilterByCategory(), new SortProductByTitleAscending());

        public Products()
        {
            InitializeComponent();
            RefreshFormData();
            categoryCmbBox.DataSource = Enum.GetValues(typeof(Category));
        }

        private void RefreshFormData()
        {
            ProductsDataGrid.DataSource = productManger.GetProducts();
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
                Product product = productManger.GetProductById(selectedId);

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
            List<Product> products = productManger.GetProducts();
            products = productManger.Filter(products, categoryCmbBox.SelectedItem.ToString()!);
            products = productManger.Search(products, txtSearchQuery.Text);
            
            ProductsDataGrid.DataSource = products;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void categoryCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
