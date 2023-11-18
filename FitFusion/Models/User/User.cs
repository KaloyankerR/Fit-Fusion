﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public abstract class User
    {
        protected int id;
        public int Id { get { return id; } set { id = value; } }
        protected string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }
        protected string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }
        protected string email;
        public string Email { get { return email; } set { email = value; }  }
        protected string passwordHash;
        public string PasswordHash { get { return passwordHash; } set { passwordHash = value; } }
        protected string passwordSalt;
        public string PasswordSalt { get { return passwordSalt; } set { passwordSalt = value; } }
        protected string address;
        public string Address { get { return address; } set { address = value; } }

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

        public void SetEncryptedPassword(List<string> encryptedPassword)
        {
            PasswordHash = encryptedPassword[0];
            PasswordSalt = encryptedPassword[1];
        }

        public abstract string GetUserRole();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
