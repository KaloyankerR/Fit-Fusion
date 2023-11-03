using Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IOrderDAO
    {
        bool CreateOrder(Order order);
        // bool UpdateOrder(Order order);
        // bool DeleteOrder(Order order);
        Order GetOrder(int id);
        List<Order> GetOrders();
    }
}
