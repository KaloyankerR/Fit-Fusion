﻿using Models.User;
using Models.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserDAO
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        User GetUserById(int id, Role role);
        User GetUserByEmail(string email);
        List<User> GetUsers(User role);
        User AuthenticateUser(string email, string password);
        bool DoesEmailExists(string email);
        // TODO bool VerifyPassword(string entered, string hash, string salt);
    }
}
