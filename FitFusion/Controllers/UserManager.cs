using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Product;
using Models.User;
using UserModel = Models.User.User;
using Interfaces;

namespace Services
{
    public class UserManager : IUser
    {
        public readonly IUser dao;

        public UserManager(IUser userDao)
        {
            dao = userDao;
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


        public bool CreateUser(UserModel user)
        {
            user.SetEncryptedPassword(EncryptPassword(user.PasswordHash));

            if (dao.CreateUser(user))
            {
                return true;
            }
            else
            {
                throw new Exception("Unable to add the current user.");
            }
        }

        public bool UpdateUser(UserModel user)
        {
            if (dao.UpdateUser(user))
            {
                return true;
            }
            else
            {
                throw new Exception("Unable to update current user.");
            }
        }

        public bool DeleteUser(UserModel user)
        {
            if (dao.DeleteUser(user))
            {
                return true;
            }
            else
            {
                throw new Exception("Unable to delete current user.");
            }
        }

        public UserModel? GetUserById(int id, UserModel role)
        {
            UserModel? user = dao.GetUserById(id, role);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Unable to get current user.");
            }
        }

        public UserModel? GetUserByEmail(string email)
        {
            UserModel? user = dao.GetUserByEmail(email);

            if (user != null) 
            { 
                return user; 
            }
            else 
            { 
                throw new Exception("Unable to get current user."); 
            }
        }

        public List<UserModel> GetUsers(UserModel role)
        {
            return dao.GetUsers(role);
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            users.AddRange(GetUsers(new Owner()));
            users.AddRange(GetUsers(new Staff()));
            users.AddRange(GetUsers(new Customer()));

            return users;
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

