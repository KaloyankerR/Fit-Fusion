using ProductModel = Models.Product.Product;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string Note { get; set; }

        public Order() { }

        public Order(int id, DateTime date, Customer customer, ShoppingCart shoppingCart, string note)
        {
            Id = id;
            OrderDate = date;
            Customer = customer;
            ShoppingCart = shoppingCart;
            Note = note;
        }

    }
}
