using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Staff : User
    {
        public string Phone { get; set; }   

        public Staff() { }

        public Staff(string phone)
        {
            Phone = phone;
        }

    }
}
