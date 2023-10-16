using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
using Controllers.User;
using Models.User;

namespace FitFusionWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //ProductDAO dao = new ProductDAO();

            //Category sampleCategory = new Category { Name = "Electronics" };
            //List<Hashtag> sampleHashtags = new List<Hashtag>
            //{
            //    new Hashtag { Id = 1, Tag = "Tech" },
            //    new Hashtag { Id = 2, Tag = "Gadgets" }
            //};

            //// Create the mock product
            //Product mockProduct = new Product
            //{
            //    Id = 1,
            //    Title = "Sample Product",
            //    Description = "This is a mock product for testing purposes.",
            //    ProductCategory = sampleCategory,
            //    Hahstags = sampleHashtags
            //};

            //Product productToGet = dao.GetProductById(1);

            //Console.WriteLine(productToGet.ToString());

            UserDAO dao = new UserDAO();
            UserManager manager = new UserManager(dao);

            Customer mockOwner = new Customer
            (
                id: 1,
                firstName: "John",
                lastName: "Doe Staff",
                email: "john.doe@example.com",
                password: "mockpassword",
                address: "123 Mock St",
                loyaltyScore: 69
            );

            manager.CreateUser(mockOwner);

        }
    }
}