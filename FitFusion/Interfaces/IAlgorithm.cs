using Models.Order;
using Models.Product;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAlgorithm
    {
        double CalculateCartTotalPrice(Dictionary<Product, int> cart);
        int CalculateCartNutriPoints(Dictionary<Product, int> cart);
        bool AreNutriPointsEnough(Order order, Customer customer);
    }
}
