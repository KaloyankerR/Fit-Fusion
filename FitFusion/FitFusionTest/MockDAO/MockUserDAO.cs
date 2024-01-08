using Interfaces;
using Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FitFusionTest.MockDAO
{
    public class MockUserDAO : IUserDAO
    {
        private readonly List<User> users = new();

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
                ),
                new Owner
                (
                    id: 4,
                    firstName: "Ozzy",
                    lastName: "Osbourne",
                    email: "ozzy@email.com",
                    passwordHash: "ozzy@email.com",
                    passwordSalt: "salt",
                    address: "USA",
                    phone: "765-432-0987"
                ),
                new Customer
                (
                    id: 5,
                    firstName: "Mark",
                    lastName: "Grayson",
                    email: "markgrayson@email.com",
                    passwordHash: "markgrayson@email.com",
                    passwordSalt: "salt",
                    address: "USA",
                    nutriPoints: 0
                ),
            };
        }

        public bool CreateUser(User user)
        {
            if (!DoesEmailExists(user.Email))
            {
                users.Add(user);
            }
            else
            {
                throw new DuplicateNameException("User already exists.");
            }

            return true;
        }

        public bool UpdateUser(User user)
        {
            if (DoesEmailExists(user.Email))
            {
                User existingUser = users.FirstOrDefault(u => u.Id == user.Id)!;

                users.Remove(existingUser);
                users.Add(user);

                return true;
            }
            else
            {
                throw new NullReferenceException("User doesn't exist.");
            }

            //TODO check
        }

        public bool DeleteUser(User user)
        {
            if (DoesEmailExists(user.Email))
            {
                users.Remove(user);
            }
            else
            {
                throw new NullReferenceException("User doesn't exist.");
            }

            return true;
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
                throw new NullReferenceException("User doesn't exist.");
            }
        }

        public User GetUserByEmail(string email)
        {
            if (DoesEmailExists(email))
            {
                User user = users.FirstOrDefault(u => u.Email == email)!;
                return user;
            }
            else
            {
                throw new NullReferenceException("User doesn't exist.");
            }
        }

        public List<User> GetUsers(User role)
        {
            // TODO: Filter the users by role
            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User AuthenticateUser(string email, string password)
        {
            User? authenticatedUser = users.FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                user.PasswordHash.Equals(password)
            );

            if (authenticatedUser != null)
            {
                return authenticatedUser;
            }
            else
            {
                throw new NullReferenceException("User doesn't exist.");
            }
        }

        public bool DoesEmailExists(string email)
        {
            return users.Any(user => user.Email == email);
        }

    }
}
