using Services;
using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Microsoft.AspNetCore.Authorization;

namespace FitFusionWeb.Pages.Stats
{
    [Authorize(Roles = "Owner")]
    public class ProductsModel : PageModel
    {
        private readonly ProductManager _productManager;
        [BindProperty]
        public List<Product> Products { get; set; } = new();
        public Dictionary<Category, int> ProductCategoriesData { get; set; } = new();
        public Dictionary<string, int> ProductTrendData { get; set; } = new();


        public ProductsModel()
        {
            _productManager = new(new ProductDAO());
        }

        public void OnGet()
        {
            Products = _productManager.GetProducts();
            ProductCategoriesData = _productManager.GetCategoryStats();
            ProductTrendData = _productManager.GetTrendyProducts();
        }

    }
}
