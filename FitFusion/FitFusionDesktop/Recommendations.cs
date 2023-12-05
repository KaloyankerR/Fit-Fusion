using DataAcess;
using Models.Product;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFusionDesktop
{
    public partial class Recommendations : Form
    {
        private readonly OrderManager _orderManager = new(new OrderDAO());
        private readonly Dictionary<int, Dictionary<Product, int>> recommendations;
        private readonly int _customerId;

        public Recommendations(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            recommendations = _orderManager.GetRecommendations(customerId);
            FillListBoxes();
        }

        private void FillListBoxes()
        {
            try
            {
                List<int> months = recommendations.Keys.OrderByDescending(m => m).ToList();

                if (months.Count > 0)
                {
                    for (int i = 0; i < Math.Min(months.Count, 3); i++)
                    {
                        int currentMonthValue = months[i];
                        ListBox currentListBox = null;

                        switch (i)
                        {
                            case 0:
                                currentListBox = listBox3;
                                break;
                            case 1:
                                currentListBox = listBox2;
                                break;
                            case 2:
                                currentListBox = listBox1;
                                break;
                        }

                        if (currentListBox != null)
                        {
                            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonthValue);
                            currentListBox.Items.Add(monthName);
                            AddProductsToListBox(currentListBox, recommendations[currentMonthValue]);
                        }
                    }

                    Product mostTrendingProduct = _orderManager.GetMostTrendingProduct(_customerId);
                    listBox4.Items.Add($"Most Trending Product: {mostTrendingProduct.Title}");
                }
                else
                {
                    throw new NullReferenceException("No products were bought.");
                }
            }
            catch
            {
                throw;
            }
        }





        private void AddProductsToListBox(ListBox listBox, Dictionary<Product, int> productCounts)
        {
            foreach (var kvp in productCounts)
            {
                Product product = kvp.Key;
                int quantity = kvp.Value;

                listBox.Items.Add($"{product.Title} - {quantity}");
            }
        }





    }
}
