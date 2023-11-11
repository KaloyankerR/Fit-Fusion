﻿using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        User GetUser(int id, User role);
        User GetUserByEmail(string email, User role);
        List<User> GetUsers(User role);
        // bool IsEmailAlreadyExists(string email);
        User? AuthenticateUser(string email, string password);
    }
}
