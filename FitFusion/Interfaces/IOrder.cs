using Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOrder
    {
        bool CreateOrder(Order order);
        Order GetOrder(int id);
        List<Order> GetOrders();
    }
}
