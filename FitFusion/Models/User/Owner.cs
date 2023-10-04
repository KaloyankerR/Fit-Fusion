using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Owner : User
    {
        public string Phone { get; set; }

        public Owner() { }

        public Owner(string phone)
        {
            Phone = phone;
        }

    }
}
