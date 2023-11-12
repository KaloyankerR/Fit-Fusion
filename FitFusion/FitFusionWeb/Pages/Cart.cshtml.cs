using DataAcess;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Models.Product;
using Services;
using Models.User;
using System.Security.Claims;

namespace FitFusionWeb.Pages
{
    public class CartModel : PageModel
    {
        public readonly ProductManager ProductManager = new(new ProductDAO());
        public readonly UserManager UserManager = new(new UserDAO());

        public ShoppingCart cart = new();
        public List<Product> products = new List<Product>();
        public double TotalPrice { get; set; }
        public string Email = string.Empty;

        public void OnGet()
        {
            products = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            Email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = ProductManager.GetProductById(id);
            var cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            
            if (cart == null)
            {
                cart = new List<Product>
                {
                    product
                };

                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                cart.Add(product);

                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            string returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToPage("../Index");
            }

            return Redirect(returnUrl);

            // return RedirectToPage("Product");
        }




    }
}
