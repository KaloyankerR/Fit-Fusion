using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public abstract class User
    {
        private int id;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string passwordHash = string.Empty;
        private string passwordSalt = string.Empty;
        private string address = string.Empty;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        public string PasswordSalt
        {
            get { return passwordSalt; }
            set { passwordSalt = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Address = address;
        }

        public void SetEncryptedPassword(List<string> encryptedPassword)
        {
            PasswordHash = encryptedPassword[0];
            PasswordSalt = encryptedPassword[1];
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public abstract string GetUserRole();

        public override string ToString()
        {
            return GetFullName();
        }
    }
}
