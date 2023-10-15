using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class User
    {
        protected int id;
        public int Id { get { return id; } protected set { id = value; } }
        protected string firstName;
        public string FirstName { get { return firstName; } protected set { firstName = value; } }
        protected string lastName;
        public string LastName { get { return lastName; } protected set { lastName = value; } }
        protected string email;
        public string Email { get { return email; } protected set { email = value; }  }
        protected string password;
        public string Password { get { return password; } protected set { password = value; } }

        // protected string salt;
        // public string Salt { get { return salt; } protected set { salt = value; } }

        protected string address;
        public string Address { get { return address; } protected set { address = value; } }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string password, string address)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.address = address;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
