using FitFusionTest.MockDAO;
using Models.Product;
using Models.User;
using Models.User.Enums;
using NUnit.Framework;
using Services;
using Services.Sort;
using System.Data;

namespace FitFusionTest
{
    [TestFixture]
    public class UserManagerTests
    {
        private readonly MockUserDAO _dao = new();
        private UserManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new(_dao);
        }

        [Test]
        public void CreateUser_DuplicateEmail_ShouldThrowDuplicateNameException()
        {
            Owner existingUser = new
            (
                id: 24,
                firstName: "Peter",
                lastName: "Parker",
                email: "peterparker@email.com",
                passwordHash: "peterparker@email.com",
                passwordSalt: "salt",
                address: "USA",
                phone: "1234567890"
            );

            bool result = _manager.CreateUser(existingUser);

            var newUser = new Customer
            (
                id: 24,
                firstName: "Peter",
                lastName: "Parker",
                email: "peterparker@email.com",
                passwordHash: "peterparker@email.com",
                passwordSalt: "salt",
                address: "USA",
                nutriPoints: 0
            );

            List<User> users = _manager.GetAllUsers();

            Assert.IsTrue(result);
            Assert.That(users, Does.Contain(existingUser));
            Assert.Throws<DuplicateNameException>(() => _manager.CreateUser(newUser));
        }

        [Test]
        public void UpdateUser_ExistingUser_ShouldUpdateUser()
        {
            Owner updatedUser = new
            (
                id: 4,
                firstName: "OZZY",
                lastName: "Osbourne Rocks",
                email: "ozzy@email.com",
                passwordHash: "ozzy@email.com",
                passwordSalt: "salt",
                address: "USA",
                phone: "765-432-0987"
            );

            bool result = _manager.UpdateUser(updatedUser);
            User retrievedUser = _manager.GetUserById(updatedUser.Id, Role.Owner);

            Assert.IsTrue(result);
            Assert.That(retrievedUser.FirstName, Is.EqualTo(updatedUser.FirstName));
            Assert.That(retrievedUser.LastName, Is.EqualTo(updatedUser.LastName));
            Assert.That(retrievedUser.Email, Is.EqualTo(updatedUser.Email));
            Assert.That(retrievedUser.PasswordHash, Is.EqualTo(updatedUser.PasswordHash));
        }

        [Test]
        public void UpdateUser_ShouldThrowAnError()
        {
            Owner nonExisitngUser = new
            (
                id: 123,
                firstName: "Omni",
                lastName: "Man",
                email: "omniman@email.com",
                passwordHash: "omniman@email.com",
                passwordSalt: "salt",
                address: "USA",
                phone: "1234567890"
            );

            Assert.Throws<NullReferenceException>(() =>
            {
                bool result = _manager.UpdateUser(nonExisitngUser);
            });
        }

        [Test]
        public void DeleteUser_ExistingUser_ShouldRemoveUser()
        {
            User userToDelete = _manager.GetUserById(id: 5, Role.Customer);
            bool result = _manager.DeleteUser(userToDelete);

            Assert.IsNotNull(userToDelete);
            Assert.IsTrue(result);
            Assert.Throws<NullReferenceException>(() =>
            {
                _manager.GetUserById(5, Role.Customer);
            });
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

            User retrievedUser = _manager.GetUserById(existingUser.Id, Role.Owner);

            Assert.IsNotNull(retrievedUser);
            Assert.That(retrievedUser.Id, Is.EqualTo(existingUser.Id));
            Assert.That(retrievedUser.FirstName, Is.EqualTo(existingUser.FirstName));
            Assert.That(retrievedUser.LastName, Is.EqualTo(existingUser.LastName));
        }

        [Test]
        public void GetUserById_NonExistingUser_ShouldThrowAnError()
        {
            var nonExisitngUser = new Owner
                (
                    id: 123,
                    firstName: "John",
                    lastName: "NotDoe",
                    email: "john.not.doe@example.com",
                    passwordHash: "john.not.doe@example.com",
                    passwordSalt: "salt",
                    address: "Not 123 Main St",
                    phone: "123-456-7890"
                );

            Assert.Throws<NullReferenceException>(() =>
            {
                _manager.GetUserById(nonExisitngUser.Id, Role.Owner);
            });
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
            List<User> usersToCheck = _manager.Sort(users, new LastNameDescending());

            Assert.That(usersToCheck, Is.EqualTo(usersToCompare));
        }

        [Test]
        public void SortMethods_ShouldReturnSortedUsers()
        {
            List<User> users = _manager.GetAllUsers();
            string userFirstNameAsc = "Alice";
            string userFirstNameDesc = "Peter";
            string userLastNameAsc = "Doe";
            string userLastNameDesc = "Smith";

            List<User> usersFirstNameAsc = _manager.Sort(users, new FirstNameAscending());
            List<User> usersFirstNameDesc = _manager.Sort(users, new FirstNameDescending());
            List<User> usersLastNameAsc = _manager.Sort(users, new LastNameAscending());
            List<User> usersLastNameDesc = _manager.Sort(users, new LastNameDescending());

            Assert.NotNull(usersFirstNameAsc);
            Assert.NotNull(usersFirstNameDesc);
            Assert.NotNull(usersLastNameAsc);
            Assert.NotNull(usersLastNameDesc);

            Assert.That(userFirstNameAsc, Is.EqualTo(usersFirstNameAsc[0].FirstName));
            Assert.That(userFirstNameDesc, Is.EqualTo(usersFirstNameDesc[0].FirstName));
            Assert.That(userLastNameAsc, Is.EqualTo(usersLastNameAsc[0].LastName));
            Assert.That(userLastNameDesc, Is.EqualTo(usersLastNameDesc[0].LastName));
        }

    }
}
