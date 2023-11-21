using DataAcess;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Models.Product;
using Services;
using Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FitFusionWeb.Pages
{
    [Authorize(Roles = "Customer")]
    public class CartModel : PageModel
    {
        public readonly ProductManager ProductManager = new(new ProductDAO());
        private readonly UserManager _userManager = new(new UserDAO());

        public Order Order { get; set; } = new();
        //public ShoppingCart cart = new();
        //public List<Product> products = new List<Product>();

        [BindProperty]
        public User CurrentUser { get; set; }

        public double TotalPrice { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                CurrentUser = _userManager.GetUserByEmail(email);
                Order.Customer = (Customer)CurrentUser;
                Order.Cart = SessionHelper.SessionHelper.GetDictionaryFromJson<Product>(HttpContext.Session, "cart");

                // Order.Cart = SessionHelper.SessionHelper.GetObjectFromJson<Dictionary<Product, int>>(HttpContext.Session, "cart");

                return Page();
            }

            return RedirectToPage("/Authentication/Login");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = ProductManager.GetProductById(id);
            var cart = SessionHelper.SessionHelper.GetDictionaryFromJson<Product>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new Dictionary<Product, int>
                {
                    { product, 1 }
                };
            }
            else
            {
                if (cart.ContainsKey(product))
                {
                    cart[product] += 1;
                }
                else
                {
                    cart.Add(product, 1);
                }
            }

            SessionHelper.SessionHelper.SetDictionaryAsJson(HttpContext.Session, "cart", cart);

            return RedirectToPage("Cart");
        }




    }
}
