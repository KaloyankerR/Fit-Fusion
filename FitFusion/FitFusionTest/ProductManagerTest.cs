using Models.Order;
using Models.Product;
using Models.User;
using Services;
using FitFusionTest.MockDAO;
using Interfaces;
using Services.Sort;
using Models.Product.Enums;
using Interfaces.Strategy;
using Services.Filter;

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
            int productsInitialCount = _manager.GetProducts().Count();

            Product product = new
            (
                id: 100,
                title: "Thor's hammer",
                description: "Odin son's weapon.",
                price: 100,
                category: Category.Accessories,
                imageUrl: "https://google.com"
            );

            bool result = _manager.CreateProduct(product);

            int productsEndCount = _manager.GetProducts().Count();

            Assert.IsTrue(result);
            Assert.That(productsInitialCount, Is.Not.EqualTo(productsEndCount));
            Assert.That(_manager.GetProducts(), Does.Contain(product));
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
            int productId = 1234;

            Assert.Throws<NullReferenceException>(() =>
            {
                _manager.GetProductById(productId);
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

            List<IFilter<Product>> filter = new ()
                {
                    { new CategoryFilterStrategy(Category.Protein) },
                };

            products = _manager.Filter(products, filter); 

            Product firstProduct = products[0];
            Product lastProduct = products[products.Count - 1];

            Assert.NotNull(products);
            Assert.That(products.Count, Is.EqualTo(3));
            Assert.That(products[0], Is.EqualTo(firstProduct));
            Assert.That(products[products.Count - 1], Is.EqualTo(lastProduct));
        }

        [Test]
        public void FilterByKeywordCategoryAndPrice_ShouldReturnFilteredProducts()
        {
            List<Product> products = _manager.GetProducts();

            List<IFilter<Product>> filter = new()
                {
                    { new ProductKeywordFilterStrategy("drake") },
                    { new CategoryFilterStrategy(Category.Protein) },
                    { new PriceFilterStrategy(new List<double>{ 20, 50 }) }
                };

            products = _manager.Filter(products, filter);

            Product productToCheck = products[0];

            Assert.NotNull(products);
            Assert.That(products.Count, Is.EqualTo(1));
            Assert.That(products[0], Is.EqualTo(productToCheck));
        }

        [Test]
        public void SortMethods_ShouldReturnSortedProducts()
        {
            List<Product> products = _manager.GetProducts();
            int productLowestPrice = 2;
            int productHighestPrice = 100;
            string productTitleFirst = "Azov Vitamin B12";
            string productTitleLast = "ZZ Gym Bag";

            List<Product> productsPriceAsc = _manager.Sort(products, new PriceAscSortStrategy());
            List<Product> productsPriceDesc = _manager.Sort(products, new PriceDescSortStrategy());
            List<Product> productsTitleAsc = _manager.Sort(products, new TitleAscSortStrategy());
            List<Product> productsTitleDesc = _manager.Sort(products, new TitleDescSortStrategy());

            Assert.NotNull(productsPriceAsc);
            Assert.NotNull(productsPriceDesc);
            Assert.NotNull(productsTitleAsc);
            Assert.NotNull(productsTitleDesc);

            Assert.That(productLowestPrice, Is.EqualTo(productsPriceAsc[0].Price));
            Assert.That(productHighestPrice, Is.EqualTo(productsPriceDesc[0].Price));
            Assert.That(productTitleFirst, Is.EqualTo(productsTitleAsc[0].Title));
            Assert.That(productTitleLast, Is.EqualTo(productsTitleDesc[0].Title));
        }

        [Test]
        public void GetCategoryStats_ShouldReturnCategoryStats()
        {
            Dictionary<Category, int> stats = _manager.GetCategoryStats();

            int proteinCount = 3;

            Assert.NotNull(stats);
            Assert.That(proteinCount, Is.EqualTo(stats[Category.Protein]));
        }
    }
}