using Models.Order;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOrderDAO
    {
        bool CreateOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetCustomerOrders(int customerId);
        List<Order> GetOrders();
        Dictionary<int, Dictionary<Product, int>> GetRecommendations(int customerId);
        Product GetMerchantRecommendation(int customerId);
        bool CreateMerchantRecommendation(int customerId, Product newProduct);
    }
}
