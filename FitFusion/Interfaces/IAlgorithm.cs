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
        double CalculateCartTotalPrice(Order order);
        int CalculateCartNutriPoints(Order order);
        bool AreNutriPointsEnough(Order order);
    }
}
