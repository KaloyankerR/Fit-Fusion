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
        private Customer _customer = new Customer();
        private Dictionary<ProductModel, int> _cart = new();
        private double _totalPrice;
        private int _nutriPointsReward;
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
        public Dictionary<ProductModel, int> Cart
        {
            get { return _cart; }
            private set { _cart = value; }
        }

        [Required]
        public double TotalPrice
        {
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        [Required]
        public int NutriPointsReward
        {
            get { return _nutriPointsReward; }
            private set { _nutriPointsReward = value; }
        }

        public string Note
        {
            get { return _note; }
            private set { _note = value; }
        }

        public Order() { }

        public Order(DateTime date, Customer customer, Dictionary<ProductModel, int> cart, double totalPrice, int nutriPointsReward, string note)
        {
            OrderDate = date;
            Customer = customer;
            Cart = cart;
            TotalPrice = totalPrice;
            NutriPointsReward = nutriPointsReward;
            Note = note;
        }

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
            return $"Order №{Id} - {TotalPrice}€ - {NutriPointsReward} NP";
        }

    }
}
