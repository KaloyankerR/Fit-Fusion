using Interfaces;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFusionTest.MockDAO
{
    public class MockUserDAO : IUser
    {
        private readonly List<User> users;

        public MockUserDAO()
        {
            users = new List<User>
            {
                new Owner
                (
                    id: 1,
                    firstName: "John",
                    lastName: "Doe",
                    email: "john.doe@example.com",
                    passwordHash: "hashed_password",
                    passwordSalt: "salt",
                    address: "123 Main St",
                    phone: "123-456-7890"
                ),
                new Staff
                (
                    id: 2,
                    firstName: "Jane",
                    lastName: "Smith",
                    email: "jane.smith@example.com",
                    passwordHash: "hashed_password",
                    passwordSalt: "salt",
                    address: "456 Oak St",
                    phone: "987-654-3210"
                ),
                new Customer
                (
                    id: 3,
                    firstName: "Alice",
                    lastName: "Johnson",
                    email: "alice.johnson@example.com",
                    passwordHash: "hashed_password",
                    passwordSalt: "salt",
                    address: "789 Pine St",
                    nutriPoints: 100
                )
            };
        }

        public bool IsEmailAlreadyExists(string email)
        {
            return users.Any(user => user.Email == email);
        }


        public User? AuthenticateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(User user)
        {
            if (!IsEmailAlreadyExists(user.Email))
            {
                users.Add(user);
                return true;
            } 
            else
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            if (!IsEmailAlreadyExists(user.Email))
            {
                users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            User? user = users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }

        public User GetUserById(int id, User role)
        {
            User? user = users.FirstOrDefault(u => u.Id == id && u.GetType() == role.GetType());

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }

        public List<User> GetUsers(User role)
        {
            return users;
        }

        public bool UpdateUser(User user)
        {
            User? existingUser = users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.PasswordSalt = user.PasswordSalt;

                if (user is Staff)
                {
                    ((Staff)existingUser).Phone = ((Staff)user).Phone;
                }
                else if (user is Owner)
                {
                    ((Owner)existingUser).Phone = ((Owner)user).Phone;
                }
                else if (user is Customer)
                {
                    ((Customer)existingUser).NutriPoints = ((Customer)user).NutriPoints;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
