using Models.Order;
using Models.Product;
using Models.User;
using Services;
using FitFusionTest.MockDAO;
using Interfaces;
using Models.Product.Enums;

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

    }
}