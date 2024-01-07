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
using Interfaces;
using Newtonsoft.Json;
using FitFusionWeb.SessionHelper;
using Services.Filter;
using Services.Sort;

namespace FitFusionWeb.Pages
{
    [Authorize(Roles = "Customer")]
    public class CartModel : PageModel
    {
        public readonly ProductManager _productManager = new(new ProductDAO(), new ProductFilter(), new ProductSorter());
        private readonly UserManager _userManager = new(new UserDAO(), new UserFilter(), new UserSorter());
        private readonly OrderManager _orderManager = new(new OrderDAO());

        [BindProperty]
        public ShoppingCart Cart { get; set; } = new();
        [BindProperty]
        public Customer CurrentUser { get; set; } = new();
        [BindProperty]
        public string Note { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToPage("/Authentication/Login");
            }

            CurrentUser = (Customer)_userManager.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email))!;

            Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart") ?? new ShoppingCart();
            Cart.CalcuteCart();

            HttpContext.Session.SetObjectAsJson("cart", Cart);

            return Page();
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = _productManager.GetProductById(id);
            Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart") ?? new ShoppingCart();

            Cart.AddToCart(product);

            HttpContext.Session.SetObjectAsJson("cart", Cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPost()
        {
            try
            {
                CurrentUser = (Customer)_userManager.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email))!;
                Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart") ?? new ShoppingCart();
                Cart.CalcuteCart();

                Order order = new(CurrentUser, Cart, Note);

                _orderManager.CreateOrder(order);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (ArithmeticException)
            {
                //TODO: Make exception for this
                return RedirectToPage("/CustomPages/NotEnoughNutriPoints");
            }

            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", new ShoppingCart());
            // TODO: Make pages for information about the data provided
            return RedirectToPage("/CustomPages/SuccessfulOrder");
        }

    }
}
