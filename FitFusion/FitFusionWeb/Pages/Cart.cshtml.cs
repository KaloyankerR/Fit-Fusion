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
        public readonly ProductManager _productManager = new(new ProductDAO());
        private readonly UserManager _userManager = new(new UserDAO());
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
            catch (NotEnoughNutriPointsException)
            {
                return RedirectToPage("/Error", new { code = 499 });
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            
            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", new ShoppingCart());
            return RedirectToPage("/Message", new { message = "Successful order!" });
            // return RedirectToPage("/CustomPages/SuccessfulOrder");
        }

        public IActionResult OnPostAddProduct(int productId)
        {
            Product productToAdd = _productManager.GetProductById(productId);
            Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart") ?? new ShoppingCart();

            Cart.AddToCart(productToAdd);

            HttpContext.Session.SetObjectAsJson("cart", Cart);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostRemoveProduct(int productId)
        {
            Product productToRemove = _productManager.GetProductById(productId);
            Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart") ?? new ShoppingCart();

            Cart.RemoveFromCart(productToRemove);

            HttpContext.Session.SetObjectAsJson("cart", Cart);
            return RedirectToPage("/Cart");
        }

    }
}
