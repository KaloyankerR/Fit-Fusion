using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Product;
using Models.User;
using UserModel = Models.User.User;
using Interfaces;
using Interfaces.Strategy;
using Services.Sort;

namespace Services
{
    public class UserManager : IUser
    {
        private readonly IUser dao;
        private ISort<User> _sort;

        public UserManager(IUser userDao, ISort<User> sort)
        {
            dao = userDao;
            _sort = sort;
            // _sort = new SortUserByFirstNameAscending();
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
                throw;
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
                throw; 
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
                throw;
            }
        }

        public UserModel GetUserById(int id, UserModel role)
        {
            try
            {
                return dao.GetUserById(id, role);
            }
            catch
            {
                throw;
            }
        }

        public UserModel GetUserByEmail(string email)
        {
            try
            {
                return dao.GetUserByEmail(email);
            }
            catch
            {
                throw;
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
                throw;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            try
            {
                List<UserModel> users = new();

                users.AddRange(GetUsers(new Owner()));
                users.AddRange(GetUsers(new Staff()));
                users.AddRange(GetUsers(new Customer()));

                return users;
            }
            catch
            {
                throw;
            }
        }


        public List<UserModel> Search(List<UserModel> users, string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                users = users.FindAll(u =>
                    u.FirstName.Contains(param, StringComparison.OrdinalIgnoreCase) ||
                    u.LastName.Contains(param, StringComparison.OrdinalIgnoreCase) ||
                    u.Address.Contains(param, StringComparison.OrdinalIgnoreCase)
                );
            }

            return users;
        }

        public List<UserModel> Sort(List<UserModel> users, SortParameter param)
        {
            switch (param)
            {
                case SortParameter.FirstNameAscending:
                    _sort = new SortUserByFirstNameAscending();
                    break;
                case SortParameter.LastNameAscending:
                    _sort = new SortUserByLastNameAscending();
                    break;
                case SortParameter.FirstNameDescending:
                    _sort = new SortUserByFirstNameDescending();
                    break;
                case SortParameter.LastNameDescending:
                    _sort = new SortUserByLastNameDescending();
                    break;
                default:
                    _sort = new SortUserByFirstNameAscending();
                    break;
            }

            return _sort.Sort(users);
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

        public UserModel AuthenticateUser(string email, string password)
        {
            try
            {
                return dao.AuthenticateUser(email, password);
            }
            catch
            {
                throw;
            }
        }

    }
}

