using ProductModel = Models.Product.Product;
using Models.User;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Models.Order
{
    public class Order
    {
        private int _id;
        private DateTime _orderDate;
        private Customer _customer = new ();
        private ShoppingCart _cart = new();
        private string _note = string.Empty;

        [Key]
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            private set { _orderDate = value; }
        }

        [Required]
        public Customer Customer
        {
            get { return _customer; }
            private set { _customer = value; }
        }

        [Required]
        public ShoppingCart Cart
        {
            get { return _cart; }
            private set { _cart = value; }
        }

        public string Note
        {
            get { return _note; }
            private set { _note = value; }
        }

        public Order(Customer customer, ShoppingCart cart, string note)
        {
            OrderDate = DateTime.Now;
            Customer = customer;
            Cart = cart;
            Note = note;
        }

        public Order(int id, DateTime date, Customer customer, ShoppingCart cart, string note)
        {
            Id = id;
            OrderDate = date;
            Customer = customer;
            Cart = cart;
            Note = note;
        }

        public override string ToString()
        {
            return $"Order №{Id} - {_cart.TotalPrice}€";
        }

    }
}
