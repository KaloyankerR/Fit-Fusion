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
        protected string passwordHash;
        public string PasswordHash { get { return passwordHash; } protected set { passwordHash = value; } }
        protected string passwordSalt;
        public string PasswordSalt { get { return passwordSalt; } protected set { passwordSalt = value; } }
        protected string address;
        public string Address { get { return address; } protected set { address = value; } }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string address)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.passwordHash = passwordHash;
            this.passwordSalt = passwordSalt;
            this.address = address;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
