using Controllers.Product;
using DataAcess;
using Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionDesktop.UserControls
{
    public partial class Users : UserControl
    {
        private readonly ProductManager productManager;

        public Users()
        {
            productManager = new(new ProductDAO());
            InitializeComponent();
            FillDataGridViewWithMockData();
        }

        private void FillDataGridViewWithMockData()
        {
            List<Product> products = productManager.GetProducts();

            UsersDataGrid.DataSource = products;
        }

        private void dungeonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dungeonComboBox1.SelectedItem.ToString() == "Owners")
            {
                MessageBox.Show($"Selected Value: Owner");
            }
            else if (dungeonComboBox1.SelectedItem.ToString() == "Staff")
            {
                MessageBox.Show($"Selected Value: Staff");
            }
            else if (dungeonComboBox1.SelectedItem.ToString() == "Customers")
            {
                MessageBox.Show($"Selected Value: Customer");
            }
        }
    }
}
