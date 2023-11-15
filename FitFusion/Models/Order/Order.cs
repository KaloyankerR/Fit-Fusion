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
        public Customer Customer { get; set; } = new Customer();
        // public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
        public Dictionary<ProductModel, int> Cart { get; set; } = new(); 
        public double TotalPrice { get; set; }
        public int NutriPointsReward { get; set; }
        public string Note { get; set; } = string.Empty;

        public Order() { }

        public Order(int id, DateTime date, Customer customer, Dictionary<ProductModel, int> cart, double totalPrice, int nutriPointsReward, string note)
        {
            Id = id;
            OrderDate = date;
            Customer = customer;
            Cart = cart;
            TotalPrice = totalPrice;
            NutriPointsReward = nutriPointsReward;
            Note = note;
        }

        public override string ToString()
        {
            return $"Order №{Id} - {TotalPrice}€";
            // Add nutri points additionally 
        }

    }
}
