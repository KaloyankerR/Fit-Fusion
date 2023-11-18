using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Customer : User
    {
        protected int nutriPoints;
        public int NutriPoints { get { return nutriPoints; } set { nutriPoints = value; } }

        public Customer() { }

        public Customer(int id) 
        {
            this.id = id;
        }

        public Customer(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string address, int loyaltyScore)
            : base(id, firstName, lastName, email, passwordHash, passwordSalt, address)
        {
            this.nutriPoints = loyaltyScore;
        }

        public override string GetUserRole()
        {
            return "Customer";
        }
    }
}
