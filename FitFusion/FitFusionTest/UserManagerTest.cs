using FitFusionTest.MockDAO;
using Models.User;
using Models.User.Enums;
using NUnit.Framework;
using Services;
using System.Data;

namespace FitFusionTest
{
    [TestFixture]
    public class UserManagerTests
    {
        private readonly MockUserDAO _dao = new ();
        private UserManager _manager;

        [SetUp] 
        public void SetUp() 
        {
            _manager = new(_dao);
        }

        [Test]
        public void CreateUser_DuplicateEmail_ShouldThrowDuplicateNameException()
        {
            var existingUser = new Owner
            {
                FirstName = "Peter",
                LastName = "Parker",
                Email = "peterparker@email.com",
                PasswordHash = "peterparker@email.com",
                PasswordSalt = "salt",
                Address = "USA",
                Phone = "1234567890",
            };

            _dao.CreateUser(existingUser);

            var newUser = new Customer
            {
                FirstName = "Peter",
                LastName = "Parker",
                Email = "peterparker@email.com",
                PasswordHash = "peterparker@email.com",
                PasswordSalt = "salt",
                Address = "USA",
                NutriPoints = 0
            };

            Assert.Throws<DuplicateNameException>(() => _manager.CreateUser(newUser));
        }

        [Test]
        public void UpdateUser_ExistingUser_ShouldUpdateUser()
        {
            var existingUser = new Customer
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanivanov@email.com",
                PasswordHash = "ivanivanov@email.com",
                PasswordSalt = "salt",
                Address = "USA",
                NutriPoints = 0
            };

            _dao.CreateUser(existingUser);

            var updatedUser = new Customer
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Parker",
                Email = "ivanivanov@email.com",
                PasswordHash = "ivanivanov@email.com",
                PasswordSalt = "salt",
                Address = "Bulgaria",
                NutriPoints = 0
            };

            _manager.UpdateUser(updatedUser);

            var retrievedUser = _dao.GetUserById(updatedUser.Id, updatedUser);
            Assert.IsNotNull(retrievedUser);
            Assert.That(retrievedUser.FirstName, Is.EqualTo(updatedUser.FirstName));
            Assert.That(retrievedUser.LastName, Is.EqualTo(updatedUser.LastName));
            Assert.That(retrievedUser.Email, Is.EqualTo(updatedUser.Email));
            Assert.That(retrievedUser.PasswordHash, Is.EqualTo(updatedUser.PasswordHash));
            Assert.That(((Customer)retrievedUser).NutriPoints, Is.EqualTo(updatedUser.NutriPoints));
        }

        [Test]
        public void DeleteUser_ExistingUser_ShouldRemoveUser()
        {
            var existingUser = new Customer
            {
                Id = 1,
                FirstName = "Doom",
                LastName = "Doctor",
                Email = "doctordoom@email.com",
                PasswordHash = "doctordoom@email.com",
                PasswordSalt = "salt",
                Address = "USA",
                NutriPoints = 0
            };

            _dao.CreateUser(existingUser);

            _manager.DeleteUser(existingUser);

            Assert.IsFalse(_dao.GetAllUsers().Contains(existingUser));
        }

        [Test]
        public void GetUserById_ExistingUser_ShouldReturnUser()
        {
            var existingUser = new Owner
                (
                    id: 1,
                    firstName: "John",
                    lastName: "Doe",
                    email: "john.doe@example.com",
                    passwordHash: "hashed_password",
                    passwordSalt: "salt",
                    address: "123 Main St",
                    phone: "123-456-7890"
                );

            User retrievedUser = _manager.GetUserById(existingUser.Id, existingUser);

            Assert.IsNotNull(retrievedUser);
            Assert.That(retrievedUser.Id, Is.EqualTo(existingUser.Id));
            Assert.That(retrievedUser.FirstName, Is.EqualTo(existingUser.FirstName));
            Assert.That(retrievedUser.LastName, Is.EqualTo(existingUser.LastName));
        }

        [Test]
        public void AuthenticateUser_ExistingUser_ShouldReturnUser()
        {
            var authenticatedUser = _manager.AuthenticateUser("markgrayson@email.com", "markgrayson@email.com");

            Assert.IsNotNull(authenticatedUser);
            Assert.That(authenticatedUser.Id, Is.EqualTo(5));
            Assert.That(authenticatedUser.FirstName, Is.EqualTo("Mark"));
            Assert.That(authenticatedUser.LastName, Is.EqualTo("Grayson"));
        }

        [Test]
        public void Sort_ShouldSortUsersByLastNameInDescendingOrder()
        {
            List<User> users = _manager.GetAllUsers();

            List<User> usersToCompare = users.OrderByDescending(x => x.LastName).ToList();
            List<User> usersToCheck = _manager.Sort(users, SortParameter.LastNameDescending);

            Assert.That(usersToCheck, Is.EqualTo(usersToCompare));
        }

    }
}
