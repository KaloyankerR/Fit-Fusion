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
            Product mockProduct = new Product
            (
                id: 123,
                title: "Creatine booster",
                description: "Water holding",
                category: Category.Creatine,
                hahstags: new List<Hashtag> { Hashtag.MuscleGrowth, Hashtag.Maintenance},
                imageUrl: "https://example.com/mock-product-image"
            );

            ProductDAO dao = new();

            var result = dao.GetProductById(1);
            Console.WriteLine( result );

            // dao.DeleteProduct(3);
            // dao.CreateProduct(mockProduct);
            
        }

    }
}