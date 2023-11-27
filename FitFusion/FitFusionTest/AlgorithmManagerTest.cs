using FitFusionTest.MockDAO;
using Models.Order;
using Models.Product;
using Models.User;
using NUnit.Framework;
using Services;

namespace FitFusionTest
{
    [TestFixture]
    public class AlgorithmManagerTest
    {
        private readonly AlgorithmManager _algorithmManager = new();
        private OrderManager _orderManager;

        [SetUp]
        public void Setup()
        {
            _orderManager = new(new MockOrderDAO(), _algorithmManager);
        }

        [Test]
        public void AreNutriPointsEnough_ShouldReturnTrue()
        {
            Order order = new Order
            {
                OrderDate = System.DateTime.Now,
                Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 },
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Product1", Price = 10, Category = Category.Redeem }, 2 },
                    { new Product { Id = 2, Title = "Product2", Price = 15, Category = Category.Redeem }, 1 }
                },
                TotalPrice = 37.97,
                NutriPointsReward = 20,
                Note = "Sample order"
            };

            bool result = _orderManager.AreNutriPointsEnough(order);

            Assert.IsTrue(result);
        }

        [Test]
        public void AreNutriPointsEnough_ShouldReturnFalse()
        {
            Order order = new Order
            {
                OrderDate = System.DateTime.Now,
                Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 },
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Product1", Price = 50, Category = Category.Redeem }, 2 },
                    { new Product { Id = 2, Title = "Product2", Price = 20, Category = Category.Redeem }, 1 }
                },
                TotalPrice = 37.97,
                NutriPointsReward = 20,
                Note = "Sample order"
            };

            bool result = _orderManager.AreNutriPointsEnough(order);

            Assert.IsFalse(result);
        }

        [Test]
        public void CalculateCartTotalPrice_ShouldReturnCorrectTotalPrice()
        {
            Order order = new Order
            {
                OrderDate = System.DateTime.Now,
                Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 },
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Product1", Price = 50, Category = Category.Redeem }, 2 },
                    { new Product { Id = 2, Title = "Product2", Price = 20, Category = Category.Redeem }, 1 }
                },
                TotalPrice = 0,
                NutriPointsReward = 20,
                Note = "Sample order"
            };
        }

    }
}
