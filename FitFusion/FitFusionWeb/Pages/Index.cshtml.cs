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

        //public async Task<IActionResult> OnGet()
        //{
        //    Products =_productManager.GetProducts();
        //    string idValue = HttpContext.Session.GetString("Id");

        //    if (idValue == null)
        //    {
        //        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    }

        //    return RedirectToPage("/Index");
        //}

        public async Task<IActionResult> OnGet()
        {
            string idValue = HttpContext.Session.GetString("Id");

            // Check if the user is authenticated
            if (User.Identity.IsAuthenticated && idValue == null)
            {
                // Check if the flag is not set
                bool hasSignedOut = HttpContext.Session.GetBool("HasSignedOut"); // Use an extension method to retrieve boolean value

                if (!hasSignedOut)
                {
                    // Perform sign-out logic
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.Session.SetBool("HasSignedOut", true); // Set the flag
                    return RedirectToPage("/Index");
                }
            }

            // If not authenticated or the flag is already set, continue with the normal flow
            Products = _productManager.GetProducts();
            return Page();
        }


    }
}