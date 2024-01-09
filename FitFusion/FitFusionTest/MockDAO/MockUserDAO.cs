using Interfaces;
using Models.Product;
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
        private List<User> usersMock;

        public MockUserDAO()
        {
            usersMock = new List<User>
            {
                new Owner
                (
                    id: 1,
                    firstName: "John",
                    lastName: "Doe",
                    email: "john.doe@example.com",
                    passwordHash: "john.doe@example.com",
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
                    passwordHash: "jane.smith@example.com",
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
                    passwordHash: "alice.johnson@example.com",
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
                usersMock.Add(user);
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
                int index = usersMock.FindIndex(p => p.Id == user.Id);
                
                if(index >= 0)
                {
                    usersMock[index] = user;
                    return true;
                }
            }
            
            throw new NullReferenceException("User doesn't exist.");
        }

        public bool DeleteUser(User user)
        {
            if (DoesEmailExists(user.Email))
            {
                int index = usersMock.FindIndex(p => p.Id == user.Id);

                if (index >= 0)
                {
                    usersMock.RemoveAt(index);
                    return true;
                }
            }

            throw new NullReferenceException("User doesn't exist.");
        }

        public User GetUserById(int id, User role)
        {
            User? user = usersMock.FirstOrDefault(u => u.Id == id && u.GetType() == role.GetType());

            //if (user != null)
            //{
            //    return user;
            //}
            //else
            //{
            //    throw new NullReferenceException("User doesn't exist.");
            //}

            return user ?? throw new NullReferenceException("User doesn't exist.");
        }

        public User GetUserByEmail(string email)
        {
            if (DoesEmailExists(email))
            {
                return usersMock.FirstOrDefault(u => u.Email == email)!;
            }
            else
            {
                throw new NullReferenceException("User doesn't exist.");
            }
        }

        public List<User> GetUsers(User role)
        {
            // TODO: Filter the users by role
            return usersMock.Where(user => user.GetUserRole() == role.GetUserRole()).ToList();
        }

        public List<User> GetAllUsers()
        {
            return usersMock;
        }

        public User AuthenticateUser(string email, string password)
        {
            User? authenticatedUser = usersMock.FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                user.PasswordHash.Equals(password)
            );
            // TODO remove the stringcomparison.ordinalignorecase

            return authenticatedUser ?? throw new NullReferenceException("User doesn't exist.");
        }

        public bool DoesEmailExists(string email)
        {
            return usersMock.Any(user => user.Email == email);
        }

    }
}
