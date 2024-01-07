using Models.Product.Enums;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductModel = Models.Product.Product;

namespace Models.Order
{
    [Serializable]
    public class ShoppingCart
    {
        private List<ProductModel> _products = new();
        private double _totalPrice;
        private int _nutriPointsReward;
        private int _nutriPointsNeeded;

        [Required]
        public List<ProductModel> Products
        {
            get { return _products; }
            private set { _products = value; }
        }

        [Required]
        public double TotalPrice
        {
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        [Required]
        public int NutriPointsReward
        {
            get { return _nutriPointsReward; }
            private set { _nutriPointsReward = value; }
        }

        [Required]
        public int NutriPointsNeeded
        {
            get { return _nutriPointsNeeded; }
            private set { _nutriPointsNeeded = value; }
        }

        public ShoppingCart() { }

        // TODO: add constructor with parameter for products

        public void AddToCart(ProductModel product)
        {
            _products.Add(product);
            CalculatePrice();
            CalculateRewards();
        }

        public void RemoveFromCart(ProductModel product)
        {
            _products.Remove(product);
            CalculatePrice();
            CalculateRewards();
        }

        public void EmptyCart()
        {
            _products.Clear();
            CalculatePrice();
            CalculateRewards();
        }

        public Dictionary<ProductModel, int> GetCartDictionary()
        {
            Dictionary<ProductModel, int> productsDict = new();
            var uniqueValues = Products.Distinct().ToList();

            foreach(ProductModel p in uniqueValues)
            {
                int count = Products.Count(item => item.Equals(p));
                productsDict[p] = count;
            }

            return productsDict;
        }

        public void CalcuteCart()
        {
            CalculatePrice();
            CalculateRewards();
        }


        private void CalculatePrice()
        {
            double totalPrice = 0;
            int nutriPointsNeeded = 0;

            foreach (ProductModel product in Products)
            {
                if (product.Category != Category.Redeem)
                {
                    totalPrice += product.Price;
                }
                else
                {
                    nutriPointsNeeded += Convert.ToInt32(product.Price);
                }
            }

            _totalPrice = totalPrice;
            _nutriPointsNeeded = nutriPointsNeeded;
        }

        private void CalculateRewards()
        {
            int nutriPointsGained = 0;

            foreach (ProductModel product in Products)
            {
                switch (product.Category)
                {
                    case Category.Protein:
                        nutriPointsGained += 30;
                        break;
                    case Category.Supplements:
                        nutriPointsGained += 30;
                        break;
                    default:
                        nutriPointsGained += 10;
                        break;
                }

                int productCount = Products.Count(p => p.Id == product.Id);
                nutriPointsGained += productCount * 2;
            }

            _nutriPointsReward = nutriPointsGained;
        }

        public override string ToString()
        {
            return $"Cart: {Products.Count} products count";
        }

    }

}
