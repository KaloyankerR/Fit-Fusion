﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Customer : User
    {
        protected int loyaltyScore;
        public int LoyaltyScore { get { return loyaltyScore; } protected set { loyaltyScore = value; } }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, string email, string password, string address, int loyaltyScore)
            : base(id, firstName, lastName, email, password, address)
        {
            this.loyaltyScore = loyaltyScore;
        }

    }
}
