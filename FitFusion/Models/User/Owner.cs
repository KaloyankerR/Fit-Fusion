using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Owner : User
    {
        protected string phone;
        public string Phone { get { return phone; } protected set { phone = value; } }

        public Owner() { }

        public Owner(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string address, string phone)
            : base(id, firstName, lastName, email, passwordHash, passwordSalt, address)
        {
            this.phone = phone;
        }

        public override string GetUserRole()
        {
            return "Owner";
        }
    }
}

