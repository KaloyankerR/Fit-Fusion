using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Models.User;
using Services;
using System.Security.Claims;

namespace FitFusionWeb.Pages
{
    [Authorize(Roles = "Customer")]
    public class HistoryModel : PageModel
    {
        [BindProperty]
        public List<Order> Orders { get; set; } = new();
        private readonly UserManager _userManager = new(new UserDAO());
        private readonly OrderManager _orderManager = new(new OrderDAO());

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    var role = User.FindFirstValue(ClaimTypes.Role);

                    User CurrentUser = _userManager.GetUserByEmail(email);
                    Orders = _orderManager.GetCustomerOrders(CurrentUser.Id);
                    return Page();
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/Error", new { code = 404 });
            }

            return RedirectToPage("/Authentication/Login");
        

        
        }
    }
}
