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
        private readonly MockOrderDAO _dao = new MockOrderDAO();
        private OrderManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new(_dao);
        }

        [Test]
        public void AddToCart_ShouldChangeShoppingCartProperties()
        {
            ShoppingCart cart = new();
           
            Product firstProduct  = new(id: 2, title: "Vitamin B12", description: null, price: 15, category: Category.Vitamins, imageUrl: null);
            Product secondProduct = new (id: 9, title: "Gym Bag", description: null, price: 50, category: Category.Redeem, imageUrl: null);

            cart.AddToCart(firstProduct);
            cart.AddToCart(secondProduct);

            Assert.NotNull(cart);
            Assert.That(cart.Products.Count, Is.EqualTo(2));
            Assert.That(cart.TotalPrice, Is.EqualTo(15.00));
            Assert.That(cart.NutriPointsReward, Is.EqualTo(24));
            Assert.That(cart.NutriPointsNeeded, Is.EqualTo(50));
        }

        [Test]
        public void RemoveFromCart_ShouldChangeShoppingCartProperties()
        {
            ShoppingCart cart = new();

            Product firstProduct = new(id: 2, title: "Vitamin B12", description: null, price: 15, category: Category.Vitamins, imageUrl: null);
            Product secondProduct = new(id: 3, title: "Gym EZ Bar", description: null, price: 35, category: Category.Accessories, imageUrl: null);
            Product thirdProduct = new(id: 9, title: "Gym Bag", description: null, price: 50, category: Category.Redeem, imageUrl: null);

            cart.AddToCart(firstProduct);
            cart.AddToCart(secondProduct);
            cart.AddToCart(thirdProduct);
            cart.RemoveFromCart(firstProduct);

            Assert.NotNull(cart);
            Assert.That(cart.Products.Count, Is.EqualTo(2));
            Assert.That(cart.TotalPrice, Is.EqualTo(35.00));
            Assert.That(cart.NutriPointsReward, Is.EqualTo(24));
            Assert.That(cart.NutriPointsNeeded, Is.EqualTo(50));
        }

        [Test]
        public void GetOrderById_ShouldReturnOrder()
        {
            Order orderToCheck = _manager.GetOrderById(0);

            Assert.NotNull(orderToCheck);
            Assert.That(orderToCheck.Cart.Products.Count, Is.EqualTo(3));
            Assert.That(orderToCheck.Cart.TotalPrice, Is.EqualTo(15.00));
            Assert.That(orderToCheck.Cart.NutriPointsReward, Is.EqualTo(56));
            Assert.That(orderToCheck.Cart.NutriPointsNeeded, Is.EqualTo(50));
            Assert.That(orderToCheck.Customer.ToString(), Is.EqualTo("Alice Johnson"));
            Assert.That(orderToCheck.Note, Is.EqualTo("Sample order 1"));
        }

        //[Test]
        //public void CreateOrder_ShouldReturnTrue()
        //{
        //    Order order = new Order
        //    {
        //        OrderDate = DateTime.Now,
        //        Customer = new Customer { Id = 100, FirstName = "Loki", LastName = "Odinson", NutriPoints = 100 },
        //        Cart = new Dictionary<Product, int>
        //        {
        //            { new Product { Id = 1, Title = "Thor's hammer", Price = 100, Category = Category.Accessories }, 2 },
        //            { new Product { Id = 2, Title = "Loki's protein", Price = 20, Category = Category.Protein }, 1 }
        //        },
        //        Note = "Mock order"
        //    };

        //    bool result = _orderManager.CreateOrder(order);

        //    List<Order> orders = _orderManager.GetOrders();

        //    Assert.IsTrue(result);
        //    Assert.IsTrue(orders.Contains(order));
        //}

        ////[Test]
        ////public void CreateOrder_ShouldThrowException()
        ////{
        ////    var product = new Product { Id = 1, Title = "Thor's hammer", Price = 100, Category = Category.Accessories };


        ////    Assert.Throws<Exception>(() => _orderManager.CreateOrder(product));
        ////}

        //[Test]
        //public void GetOrderById_ShouldReturnOrder()
        //{
        //    int orderId = 1;
        //    Order result = _orderManager.GetOrderById(orderId);
        //    Assert.NotNull(result);
        //    Assert.That(result.Id, Is.EqualTo(orderId));
        //}

        //[Test]
        //public void GetOrderById_ShouldThrowAnError()
        //{
        //    int orderId = 100;

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        Order result = _orderManager.GetOrderById(orderId);
        //    });
        //}

        //[Test]
        //public void CalculateCartTotalPrice_ShouldReturnCorrectTotalPrice()
        //{
        //    Dictionary<Product, int> cart = new Dictionary<Product, int>
        //    {
        //        { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Protein }, 2 },
        //        { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Supplements }, 1 }
        //    };

        //    // Act
        //    // double totalPrice = orderManager.CalculateCartTotalPrice(cart);

        //    // Assert
        //    // Assert.AreEqual(37.97, totalPrice, 0.01); // Considering potential floating-point precision issues
        //}

        //[Test]
        //public void CalculateNutriPointsInCart_ShouldReturnCorrectNutriPoints()
        //{
        //    // Arrange
        //    Dictionary<Product, int> cart = new Dictionary<Product, int>
        //    {
        //        { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Protein }, 2 },
        //        { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Supplements }, 1 }
        //    };

        //    // Act
        //    // int nutriPointsGained = orderManager.CalculateCartNutriPoints(cart);

        //    // Assert
        //    // Assert.AreEqual(100, nutriPointsGained);
        //}

        //[Test]
        //public void AreNutriPointsEnough_ShouldReturnTrue()
        //{
        //    // Arrange
        //    Customer customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", NutriPoints = 100 };

        //    Order order = new Order
        //    {
        //        OrderDate = System.DateTime.Now,
        //        Customer = customer,
        //        Cart = new Dictionary<Product, int>
        //        {
        //            { new Product { Id = 1, Title = "Product1", Price = 10.99, Category = Category.Redeem }, 2 },
        //            { new Product { Id = 2, Title = "Product2", Price = 15.99, Category = Category.Redeem }, 1 }
        //        },
        //        TotalPrice = 37.97,
        //        NutriPointsReward = 20,
        //        Note = "Sample order"
        //    };

        //    // Act
        //    // bool result = orderManager.AreNutriPointsEnough(order, customer);

        //    // Assert
        //    // Assert.IsTrue(result);
        //}
    }
}