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
                Order.Cart = SessionHelper.SessionHelper.GetObjectFromJson<Dictionary<Product, int>>(HttpContext.Session, "cart");
                // products = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

                return Page();
            }

            return RedirectToPage("/Authentication/Login");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = ProductManager.GetProductById(id);
            var cart = SessionHelper.SessionHelper.GetObjectFromJson<Dictionary<Product, int>>(HttpContext.Session, "cart");

            //if (cart == null)
            //{
            //    cart = new List<Product>
            //    {
            //        product
            //    };

            //    SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //}
            //else
            //{
            //    cart.Add(product);

            //    SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //}

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
