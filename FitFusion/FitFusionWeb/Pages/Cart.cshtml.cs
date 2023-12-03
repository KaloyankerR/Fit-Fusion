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
        public readonly ProductManager _productManager = new(new ProductDAO());
        private readonly UserManager _userManager = new(new UserDAO());
        private readonly OrderManager _orderManager = new(new OrderDAO(), new AlgorithmManager());

        [BindProperty]
        public Order Order { get; set; } = new ();

        [BindProperty]
        public Customer CurrentUser { get; set; } = new();

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                CurrentUser = (Customer)_userManager.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email))!;

                Order = _orderManager.SetupOrder(
                    customer: CurrentUser,
                    cart: SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart")
                    );

                return Page();
            }

            return RedirectToPage("/Authentication/Login");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = _productManager.GetProductById(id);            
            List<Product> cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            cart.Add(product);
            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToPage("Cart");
        }

        public IActionResult OnPost()
        {
            //Console.WriteLine(Order);
            //Console.WriteLine(CurrentUser);
            // Displaying null values

            try
            {
                CurrentUser = (Customer)_userManager.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email))!;

                Order = _orderManager.SetupOrder(
                    customer: CurrentUser,
                    cart: SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart")
                    );

                _orderManager.CreateOrder(Order);
            }
            catch (ApplicationException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }
            catch (ArithmeticException)
            {
                return RedirectToPage("/CustomPages/NotEnoughNutriPoints");
            }

            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", new List<Product>());

            return RedirectToPage("/CustomPages/SuccessfulOrder");
        }

    }
}
