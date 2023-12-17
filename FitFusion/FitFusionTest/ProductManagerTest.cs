using Models.Order;
using Models.Product;
using Models.User;
using Services;
using FitFusionTest.MockDAO;
using Interfaces;
using Services.Sort;

namespace FitFusionTest
{
    public class ProductManagerTests
    {
        private readonly MockProductDAO _dao = new MockProductDAO();
        private ProductManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new(_dao);
        }

        [Test]
        public void CreateProduct_ShouldReturnTrue()
        {
            Product product = new
            (
                id: 11,
                title: "Thor's hammer",
                description: "Odin son's weapon.",
                price: 100,
                category: Category.Accessories,
                imageUrl: "https://google.com"
            );

            bool result = _manager.CreateProduct(product);

            List<Product> products = _manager.GetProducts();

            Assert.IsTrue(result);
            Assert.IsTrue(products.Contains(product));
        }

        [Test]
        public void GetProductById_ShouldReturnProduct()
        {
            Product productToCheck = new Product(id: 1, title: "Protein", description: null, price: 10, category: Category.Protein, imageUrl: null);
            Product product = _manager.GetProductById(productToCheck.Id);

            Assert.NotNull(product);
            Assert.That(product.Id, Is.EqualTo(productToCheck.Id));
            Assert.That(product.Title, Is.EqualTo(productToCheck.Title));
            Assert.That(product.Description, Is.EqualTo(productToCheck.Description));
            Assert.That(product.Price, Is.EqualTo(productToCheck.Price));
            Assert.That(product.Category, Is.EqualTo(productToCheck.Category));
            Assert.That(product.ImageUrl, Is.EqualTo(productToCheck.ImageUrl));
        }

        [Test]
        public void GetProductById_ShouldThrowAnError()
        {
            int productId = 100;

            Assert.Throws<NullReferenceException>(() =>
            {
                Product result = _manager.GetProductById(productId);
            });
        }

        [Test]
        public void UpdateProduct_ExistingProduct_ShouldRemoveProduct()
        {
            Product existingProduct = new(id: 6, title: "Gym Tank Top", description: null, price: 5, category: Category.Clothing, imageUrl: null);
            _manager.UpdateProduct(existingProduct);
            Product product = _manager.GetProductById(existingProduct.Id);

            Assert.NotNull(product);
            Assert.That(product.Id, Is.EqualTo(existingProduct.Id));
            Assert.That(product.Title, Is.EqualTo(existingProduct.Title));
            Assert.That(product.Description, Is.EqualTo(existingProduct.Description));
            Assert.That(product.Price, Is.EqualTo(existingProduct.Price));
            Assert.That(product.Category, Is.EqualTo(existingProduct.Category));
            Assert.That(product.ImageUrl, Is.EqualTo(existingProduct.ImageUrl));
        }

        [Test]
        public void DeleteProduct_ExistingProduct_ShouldRemoveProduct()
        {
            Product existingProduct = new Product(id: 5, title: "Healthy Chips", description: null, price: 5, category: Category.Snacks, imageUrl: null);
            Product product = _manager.GetProductById(existingProduct.Id);

            Assert.NotNull(product);
            Assert.That(product.Id, Is.EqualTo(existingProduct.Id));
            Assert.That(product.Title, Is.EqualTo(existingProduct.Title));
            Assert.That(product.Description, Is.EqualTo(existingProduct.Description));
            Assert.That(product.Price, Is.EqualTo(existingProduct.Price));
            Assert.That(product.Category, Is.EqualTo(existingProduct.Category));
            Assert.That(product.ImageUrl, Is.EqualTo(existingProduct.ImageUrl));

            _manager.DeleteProduct(existingProduct.Id);

            Assert.Throws<NullReferenceException>(() =>
            {
                Product result = _manager.GetProductById(existingProduct.Id);
            });
        }

        [Test]
        public void FilterByCategory_ShouldReturnFilteredProducts()
        {
            List<Product> products = _manager.GetProducts();
            List<Product> firstSort = _manager.Sort(products, param: "titleAsc");
            List<Product> products2 = _manager.GetProducts();
        }

    }
}