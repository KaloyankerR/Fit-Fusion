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
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Metadata;

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

        public IActionResult OnGet()
        {
            //if (User.Identity?.IsAuthenticated ?? false)
            //{
            //    Products = _productManager.GetProducts();
            //    return Page();
            //}
            //else
            //{
            //    bool hasSignedOut = HttpContext.Session.GetBool("HasSignedOut"); // Use an extension method to retrieve boolean value

            //    if (hasSignedOut)
            //    {

            //    }
            //    if (HttpContext.Session.GetString("Id") == null)
            //    {
            //        return Redirect("/Authentication/Logout");
            //    }
            //    else
            //    {
            // }

            Products = _productManager.GetProducts();
            return Page();
        }

    }
}