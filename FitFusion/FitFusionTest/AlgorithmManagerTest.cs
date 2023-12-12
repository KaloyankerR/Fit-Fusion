//using FitFusionTest.MockDAO;
//using Models.Order;
//using Models.Product;
//using Models.User;
//using NUnit.Framework;
//using Services;

//namespace FitFusionTest
//{
//    [TestFixture]
//    public class AlgorithmManagerTest
//    {
//        private readonly AlgorithmManager _algorithmManager = new();
//        private OrderManager _orderManager;

//        [SetUp]
//        public void Setup()
//        {
//            _orderManager = new(new MockOrderDAO(), _algorithmManager);
//        }

//        [Test]
//        public void AreNutriPointsEnough_ShouldReturnTrue()
//        {
//            Order order = _orderManager.GetOrderById(4);
//            bool result = _orderManager.AreNutriPointsEnough(order);
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void AreNutriPointsEnough_ShouldReturnFalse()
//        {
//            Order order = _orderManager.GetOrderById(5);
//            bool result = _orderManager.AreNutriPointsEnough(order);
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void CalculateCartTotalPrice_ShouldReturnCorrectTotalPrice()
//        {
//            Order order = _orderManager.GetOrderById(3);
//            order.TotalPrice = _orderManager.CalculateCartTotalPrice(order);
//            Assert.That(order.TotalPrice, Is.EqualTo(35));
//        }

//        //[Test]
//        //piublic void CalculateNutriPointsInCart_ShouldReturnCorrectNutriPoints()
//        //{

//        //}

//    }
//}
