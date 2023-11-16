using Models.Order;
using Models.Product;
using Models.User;
using Services;
using Services.MockDAO;

namespace FitFusionTest
{
    public class OrderManagerTests
    {
        private OrderManager orderManager;

        [SetUp]
        public void Setup()
        {
            MockOrderDAO mockOrderDao = new MockOrderDAO();
            orderManager = new OrderManager(mockOrderDao);
        }

        [Test]
        public void CreateOrder_ShouldReturnTrue()
        {
            // Arrange
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 },
                Cart = new Dictionary<Product, int>
                {
                    { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Protein }, 2 },
                    { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Supplements }, 1 }
                },
                TotalPrice = 37.97,
                NutriPointsReward = 20,
                Note = "Sample order"
            };

            // Act
            bool result = orderManager.CreateOrder(order);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            int orderId = 1; // Assuming there is an order with ID 1 in the mock data

            // Act
            Order result = orderManager.GetOrderById(orderId);

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
            double totalPrice = orderManager.CalculateCartTotalPrice(cart);

            // Assert
            Assert.AreEqual(37.97, totalPrice, 0.01); // Considering potential floating-point precision issues
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
            int nutriPointsGained = orderManager.CalculateNutriPointsInCart(cart);

            // Assert
            Assert.AreEqual(100, nutriPointsGained);
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
            bool result = orderManager.AreNutriPointsEnough(order, customer);

            // Assert
            Assert.IsTrue(result);
        }
    }
}