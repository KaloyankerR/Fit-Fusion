﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Staff : User
    {
        protected string phone;
        public string Phone { get { return phone;  } protected set { phone = value; } }

        // public Staff() { }

        public Staff(int id, string firstName, string lastName, string email, string password, string address, string phone)
                    : base(id, firstName, lastName, email, password, address)
        {
            this.phone = phone;
        }

    }
}
