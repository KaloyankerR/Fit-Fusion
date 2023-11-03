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
        public double TotalPrice { get; set; }
        public int Discount { get; set; }
        public string Note { get; set; }

        public Order() { }

        public Order(int id, DateTime date, Customer customer, ShoppingCart shoppingCart, int discount, string note)
        {
            Id = id;
            OrderDate = date;
            Customer = customer;
            ShoppingCart = shoppingCart;
            TotalPrice = CalculateTotalPrice();
            Discount = discount;
            Note = note;
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (ProductModel product in ShoppingCart.Products)
            {
                totalPrice += product.Price;
            }

            return totalPrice - (totalPrice * Discount);
        }

    }
}
