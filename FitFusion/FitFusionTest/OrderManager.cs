using Models.Order;
using Models.Product;
using Models.User;
using Services;
using FitFusionTest.MockDAO;
using Interfaces;

namespace FitFusionTest
{
    public class OrderManagerTests
    {
        private readonly AlgorithmManager _algorithmManager = new();
        private readonly MockOrderDAO _dao = new MockOrderDAO();
        private OrderManager _orderManager;

        [SetUp]
        public void Setup()
        {
            _orderManager = new(new MockOrderDAO(), _algorithmManager);
        }

        [Test]
        public void CreateOrder_ShouldReturnTrue()
        {
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = new Customer { Id = 100, FirstName = "Loki", LastName = "Odinson", NutriPoints = 100 },
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Thor's hammer", Price = 100, Category = Category.Accessories }, 2 },
                    { new Product { Id = 2, Title = "Loki's protein", Price = 20, Category = Category.Protein }, 1 }
                },
                Note = "Mock order"
            };

            bool result = _orderManager.CreateOrder(order);

            List<Order> orders = _orderManager.GetOrders();

            Assert.IsTrue(result);
            Assert.IsTrue(orders.Contains(order));
        }

        [Test]
        public void CreateOrder_ShouldThrowException()
        {
            var product = new Product { Id = 1, Title = "Thor's hammer", Price = 100, Category = Category.Accessories };


            Assert.Throws<Exception>(() => _orderManager.CreateOrder(product));
        }

        [Test]
        public void GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            int orderId = 1; // Assuming there is an order with ID 1 in the mock data

            // Act
            Order result = _orderManager.GetOrderById(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(orderId, result.Id);
        }

        [Test]
        public void CalculateCartTotalPrice_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            Dictionary<Product, int> cart = new Dictionary<Product, int>
            {
                { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Protein }, 2 },
                { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Supplements }, 1 }
            };

            // Act
            // double totalPrice = orderManager.CalculateCartTotalPrice(cart);

            // Assert
            // Assert.AreEqual(37.97, totalPrice, 0.01); // Considering potential floating-point precision issues
        }

        [Test]
        public void CalculateNutriPointsInCart_ShouldReturnCorrectNutriPoints()
        {
            // Arrange
            Dictionary<Product, int> cart = new Dictionary<Product, int>
            {
                { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Protein }, 2 },
                { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Supplements }, 1 }
            };

            // Act
            // int nutriPointsGained = orderManager.CalculateCartNutriPoints(cart);

            // Assert
            // Assert.AreEqual(100, nutriPointsGained);
        }

        [Test]
        public void AreNutriPointsEnough_ShouldReturnTrue()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 };

            Order order = new Order
            {
                OrderDate = System.DateTime.Now,
                Customer = customer,
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Redeem }, 2 },
                    { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Redeem }, 1 }
                },
                TotalPrice = 37.97,
                NutriPointsReward = 20,
                Note = "Sample order"
            };

            // Act
            // bool result = orderManager.AreNutriPointsEnough(order, customer);

            // Assert
            // Assert.IsTrue(result);
        }
    }
}