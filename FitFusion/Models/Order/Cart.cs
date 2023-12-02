using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductModel = Models.Product.Product;

namespace Models.Order
{
    public class Cart
    {
        private List<ProductModel> _products;
        private double _totalPrice;
        private int _nutriPointsReward;

        public List<ProductModel> Products
        {
            get { return _products; }
            private set { _products = value; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        public int NutriPoints
        {
            get { return _nutriPointsReward; }
            private set { _nutriPointsReward = value; }
        }

        public Cart()
        {

        }
    }
}
