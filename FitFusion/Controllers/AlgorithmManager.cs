using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.Order;
using Models.Product;
using Models.User;

namespace Services
{
    public class AlgorithmManager : IAlgorithm
    {
        public bool AreNutriPointsEnough(Order order, Customer customer)
        {
            int nutriPointsNeeded = 0;

            foreach (var pair in order.Cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

                if (product.Category == Category.Redeem)
                {
                    nutriPointsNeeded += Convert.ToInt32(product.Price) * quantity;
                }
            }

            return nutriPointsNeeded <= customer.NutriPoints;
        }

        public double CalculateCartTotalPrice(Dictionary<Product, int> cart)
        {
            double totalPrice = 0;

            foreach (var pair in cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

                if (product.Category != Category.Redeem)
                {
                    totalPrice += (product.Price * quantity);
                }
            }

            return totalPrice;
        }

        public int CalculateCartNutriPoints(Dictionary<Product, int> cart)
        {
            int nutriPointsGained = 0;

            foreach (var pair in cart)
            {
                Product product = pair.Key;
                int quantity = pair.Value;

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

                if (quantity > 1)
                {
                    nutriPointsGained += 20 * quantity;
                }

            }

            return nutriPointsGained;
        }
    }
}
