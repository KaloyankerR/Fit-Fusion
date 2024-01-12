using Models.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Staff : User
    {
        private string phone = string.Empty;

        public string Phone 
        { 
            get { return phone;  }  
        }

        public Staff() { }

        public Staff(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string? address, string phone)
                    : base(id, firstName, lastName, email, passwordHash, passwordSalt, address)
        {
            this.phone = phone;
        }

        public override Role GetUserRole()
        {
            return Role.Staff;
        }

    }
}
