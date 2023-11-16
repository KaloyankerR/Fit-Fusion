using Models.User;
using NUnit.Framework;
using DataAcess.Mock;

namespace FitFusionTest
{
    [TestFixture]
    public class UserManagerTests
    {
        // [Test]
        //public void UserManager_AuthenticateUser_ValidCredentials_ReturnsUser()
        //{
        //    var userManager = new UserManager(new UserDAOMock());
        //    string email = "john@example.com";
        //    string password = "hashed_password";

        //    User result = userManager.AuthenticateUser(email, password);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(email, result.Email);
        //}

        //[Test]
        //public void UserManager_AuthenticateUser_InvalidCredentials_ReturnsNull()
        //{
        //    var userManager = new UserManager(new UserDAOMock());
        //    string email = "nonexistent@example.com";
        //    string password = "wrong_password";

        //    User result = userManager.AuthenticateUser(email, password);

        //    Assert.IsNull(result);
        //}

        //[Test]
        //public void UserManager_CreateUser_ValidUser_ReturnsTrue()
        //{
        //    var userManager = new UserManager(new UserDAOMock());
        //    var user = new Customer(4, "Bob", "Smith", "bob@example.com", "hashed_password", "salt", "456 Birch St", 150);

        //    bool result = userManager.CreateUser(user);

        //    Assert.IsTrue(result);
        //}

    }
}
