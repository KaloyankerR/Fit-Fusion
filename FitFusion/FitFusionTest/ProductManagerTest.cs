using Models.Order;
using Models.Product;
using Models.User;
using Services;
using FitFusionTest.MockDAO;
using Interfaces;

namespace FitFusionTest
{
    public class ProductManagerTests
    {
        private readonly AlgorithmManager _algorithmManager = new();
        private readonly MockProductDAO _dao = new MockProductDAO();
        private ProductManager _productManager;

        [SetUp]
        public void Setup()
        {
            _productManager = new(_dao);
        }

        [Test]
        public void CreateProduct_ShouldReturnTrue()
        {
            Product product = new 
            (
                id: 1,
                title: "Thor's hammer",
                description: "Odin son's weapon.",
                price: 100,
                category: Category.Accessories,
                imageUrl: "https://google.com"
            );

            bool result = _productManager.CreateProduct(product);

            List<Product> products = _productManager.GetProducts();

            Assert.IsTrue(result);
            Assert.IsTrue(products.Contains(product));
        }

        [Test]
        public void GetProductById_ShouldReturnProduct()
        {
            int productId = 1;
            Product product = _productManager.GetProductById(productId);
            Assert.NotNull(product);
            Assert.That(product.Id, Is.EqualTo(productId));
        }

        [Test]
        public void GetProductById_ShouldThrowAnError()
        {
            int productId = 100;

            Assert.Throws<InvalidOperationException>(() =>
            {
                Product result = _productManager.GetProductById(productId);
            });
        }

    }
}