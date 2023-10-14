using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;

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
            ProductDAO dao = new ProductDAO();

            Category sampleCategory = new Category { Name = "Electronics" };
            List<Hashtag> sampleHashtags = new List<Hashtag>
            {
                new Hashtag { Id = 1, Tag = "Tech" },
                new Hashtag { Id = 2, Tag = "Gadgets" }
            };

            // Create the mock product
            Product mockProduct = new Product
            {
                Id = 1,
                Title = "Sample Product",
                Description = "This is a mock product for testing purposes.",
                ProductCategory = sampleCategory,
                Hahstags = sampleHashtags
            };

            Product productToGet = dao.GetProductById(1);

            Console.WriteLine(productToGet.ToString());
        }
    }
}