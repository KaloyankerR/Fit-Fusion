using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public abstract class User
    {
        private int _id;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _passwordHash = string.Empty;
        private string _passwordSalt = string.Empty;
        private string _address = string.Empty;

        public int Id
        {
            get { return _id; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string PasswordHash
        {
            get { return _passwordHash; }
        }

        public string PasswordSalt
        {
            get { return _passwordSalt; }
        }

        public string Address
        {
            get { return _address; }
        }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, string address)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _passwordHash = passwordHash;
            _passwordSalt = passwordSalt;
            _address = address;
        }

        public void SetEncryptedPassword(List<string> encryptedPassword)
        {
            _passwordHash = encryptedPassword[0];
            _passwordSalt = encryptedPassword[1];
        }

        public abstract string GetUserRole();

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return GetFullName();
        }
    }
}
