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
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public List<ProductModel> Products { get; set; }

        public Order() { }

        public Order(int id, DateTime date, Customer customer, List<ProductModel> products)
        {
            Id = id;
            Date = date;
            Customer = customer;
            Products = products;
        }

    }
}
