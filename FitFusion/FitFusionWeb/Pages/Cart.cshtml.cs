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

        public Order Order { get; set; } = new();
        public List<Product> MyCart = new();

        [BindProperty]
        public Customer CurrentUser { get; set; } = new();

        public double TotalPrice { get; set; }

        public Dictionary<Product, int> GetUniqueItemsWithCounts()
        {
            return MyCart.GroupBy(item => new { item.Id })
                         .ToDictionary(group => group.First(), group => group.Count());
        }

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                CurrentUser = (Customer)_userManager.GetUserByEmail(email);
                Order.Customer = CurrentUser;
                MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
                Order.Cart = GetUniqueItemsWithCounts();
                Order.TotalPrice = _orderManager.CalculateCartTotalPrice(Order);
                Order.NutriPointsReward = _orderManager.CalculateCartNutriPoints(Order);

                return Page();
            }

            return RedirectToPage("/Authentication/Login");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            Product product = _productManager.GetProductById(id);
            MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            MyCart.Add(product);
            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", MyCart);

            return RedirectToPage("Cart");
        }

    }
}
