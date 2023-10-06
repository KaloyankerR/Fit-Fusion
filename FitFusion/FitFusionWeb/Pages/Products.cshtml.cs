using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products { get; set; }

        public class Product
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; }
        }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { Name = "Product 1", ImageUrl = "https://www.example.com/product1.jpg", Description = "This is a sample product description for Product 1." },
                new Product { Name = "Product 2", ImageUrl = "https://www.example.com/product2.jpg", Description = "This is a sample product description for Product 2." },
                new Product { Name = "Product 3", ImageUrl = "https://www.example.com/product3.jpg", Description = "This is a sample product description for Product 3." },
                new Product { Name = "Product 4", ImageUrl = "https://www.example.com/product4.jpg", Description = "This is a sample product description for Product 4." },
                new Product { Name = "Product 5", ImageUrl = "https://www.example.com/product5.jpg", Description = "This is a sample product description for Product 5." },
                new Product { Name = "Product 6", ImageUrl = "https://www.example.com/product6.jpg", Description = "This is a sample product description for Product 6." }
            };
        }

    }
}
