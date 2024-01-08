using Services;
using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Microsoft.AspNetCore.Authorization;
using Services.Filter;
using Services.Sort;
using Models.Product.Enums;
using FitFusionWeb.Views;

namespace FitFusionWeb.Pages.Stats
{
    [Authorize(Roles = "Owner")]
    public class ProductsModel : PageModel
    {
        private readonly ProductManager _productManager;
        [BindProperty]
        public int ProductsCount { get; set; } = new();
        public Dictionary<Category, int> ProductCategoriesData { get; set; } = new();
        public Dictionary<string, int> ProductTrendData { get; set; } = new();


        public ProductsModel()
        {
            _productManager = new(new ProductDAO());
        }

        public void OnGet()
        {
            ProductsCount = _productManager.GetProducts().Count();
            ProductCategoriesData = _productManager.GetCategoryStats();
            ProductTrendData = _productManager.GetTrendyProducts();
        }

    }
}
