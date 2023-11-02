using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using Models.User;

namespace DataAcess.Mock
{
    public class UserDAOMock : IUserDAO
    {
        private readonly List<User> users;

        public UserDAOMock()
        {
            users = new List<User>
            {
                new Staff(1, "John", "Doe", "john@example.com", "hashed_password", "salt", "123 Main St", "123-456-7890"),
                new Owner(2, "Jane", "Doe", "jane@example.com", "hashed_password", "salt", "456 Oak St", "987-654-3210"),
                new Customer(3, "Alice", "Johnson", "alice@example.com", "hashed_password", "salt", "789 Elm St", 100),
            };
        }

        public User? AuthenticateUser(string email, string password)
        {
            User user = users.FirstOrDefault(u => u.Email == email);

            if (user != null && user.PasswordHash == password)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public bool IsEmailAlreadyExists(string email)
        {
            return users.Any(user => user.Email == email);
        }

        public bool CreateUser(User user)
        {
            return true;
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id, User role)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email, User role)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(User role)
        {
            // return users.Where(user => user.GetUserRole() == role.ToString()).ToList();
            return users;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
