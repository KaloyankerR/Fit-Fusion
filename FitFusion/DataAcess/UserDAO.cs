﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;

namespace DataAcess
{
    public class UserDAO
    {
        private string ConnectionString;

        public UserDAO()
        {
            ConnectionString = Connection.DbConnection.ConnectionString;
        }

        public UserDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CreateUser(User user) { return false; }

        public bool UpdateUser(User user) { return false; }
        
        public bool DeleteUser(User user) { return false; }

        public User GetUser(int id) { return new User(); }

        public List<User> GetAllUsers() {  return new List<User>(); }

    }
}
