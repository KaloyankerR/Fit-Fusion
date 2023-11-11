using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Product;
using Models.User;
using UserModel = Models.User.User;
using Interfaces;

namespace Controllers
{
    public class UserManager : IUser
    {
        public readonly IUser dao;

        public UserManager(IUser userDao)
        {
            dao = userDao;
        }

        public bool CreateUser(UserModel user)
        {
            try
            {
                user.SetEncryptedPassword(EncryptPassword(user.PasswordHash));
                
                return dao.CreateUser(user);
            }
            catch
            {
                throw new Exception("Unable to add the current user.");
            }
        }

        public List<string> EncryptPassword(string password)
        {
            List<string> encryptedPassword = new();

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            encryptedPassword.Add(hash);
            encryptedPassword.Add(salt);

            return encryptedPassword;
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

        public UserModel GetUserByEmail(string email, UserModel role)
        {
            try
            {
                return dao.GetUserByEmail(email, role);
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

        public List<UserModel> Search(List<UserModel> users, string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                users = users.FindAll(u =>
                    u.FirstName.Contains(param, StringComparison.OrdinalIgnoreCase) ||
                    u.LastName.Contains(param, StringComparison.OrdinalIgnoreCase)
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

        public UserModel? AuthenticateUser(string email, string password)
        {
            try
            {
                return dao.AuthenticateUser(email, password);
            }
            catch
            {
                return null;
            }
        }

    }
}

