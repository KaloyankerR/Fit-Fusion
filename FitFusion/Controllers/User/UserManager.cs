using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using Models.Product;
using Models.User;
using UserModel = Models.User.User;

namespace Controllers.User
{
    public class UserManager
    {
        public UserDAO dao;

        public UserManager(UserDAO userDao)
        {
            dao = userDao;
        }

        public bool CreateUser(UserModel user)
        {
            try
            {
                return dao.CreateUser(user);
            }
            catch
            {
                throw new Exception("Unable to add the current user.");
            }
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                return dao.UpdateUser(user);
            }
            catch
            {
                throw new Exception("Unable to update current user.");
            }
        }

        public bool DeleteUser(UserModel user)
        {
            try
            {
                return dao.DeleteUser(user);
            }
            catch
            {
                throw new Exception("Unable to delete current user.");
            }
        }

        public UserModel GetUser(int id, UserModel role)
        {
            try
            {
                return dao.GetUser(id, role);
            }
            catch
            {
                throw new Exception("Unable to get current user.");
            }
        }

        public List<UserModel> GetUsers(UserModel role)
        {
            try
            {
                return dao.GetUsers(role);
            }
            catch
            {
                throw new Exception("Unable to get current users.");
            }
        }

        public List<UserModel> SearchFilter(List<UserModel> users, string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                users = users.FindAll(u =>
                    u.FirstName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    u.LastName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return users;
        }

        public List<UserModel> Sort(List<UserModel> users, string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                switch (param.ToLower())
                {
                    case "asc":
                        users.Sort((a, b) => string.Compare(a.FirstName, b.FirstName, StringComparison.Ordinal));
                        break;
                    case "desc":
                        users.Sort((a, b) => string.Compare(b.FirstName, a.FirstName, StringComparison.Ordinal));
                        break;
                }
            }
            return users;
        }

    }
}

