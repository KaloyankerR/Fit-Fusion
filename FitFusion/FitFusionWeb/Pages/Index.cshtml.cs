using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Services;
using Models.User;
using FitFusionWeb.Pages.Products;
using Models.Order;
using Services.Filter;
using Services.Sort;

namespace FitFusionWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; } = new();
        private readonly ProductManager _productManager = new(new ProductDAO());
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Products =_productManager.GetProducts();
        }

    }
}