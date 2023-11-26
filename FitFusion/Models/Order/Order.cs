﻿using ProductModel = Models.Product.Product;
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
        private int _id;
        private DateTime _orderDate;
        private Customer _customer = new Customer();
        private Dictionary<ProductModel, int> _cart = new();
        private double _totalPrice;
        private int _nutriPointsReward;
        private string _note = string.Empty;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public Dictionary<ProductModel, int> Cart
        {
            get { return _cart; }
            set { _cart = value; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public int NutriPointsReward
        {
            get { return _nutriPointsReward; }
            set { _nutriPointsReward = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

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
