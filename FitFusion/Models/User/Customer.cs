using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Customer : User
    {
        public int LoyaltyScore { get; set; }

        public Customer() { }

        public Customer(int loyaltyScore)
        {
            LoyaltyScore = loyaltyScore;
        }

    }
}
