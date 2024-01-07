using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Models.User;
using Services;
using Services.Sort;
using System.Security.Claims;
using Services.Filter;

namespace FitFusionWeb.Pages
{
    public class RecommendationsModel : PageModel
    {
        private readonly OrderManager _orderManager = new(new OrderDAO());
        private User? CurrentUser { get; set; }
        private UserManager _userManager = new(new DataAcess.UserDAO(), new UserFilter(), new UserSorter());
        [BindProperty]
        public Product SystemRecommendation { get; set; } = new();
        [BindProperty]
        public Product MerchantRecommendation { get; set; } = new();

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    var role = User.FindFirstValue(ClaimTypes.Role);
                    
                    CurrentUser = _userManager.GetUserByEmail(email);
                    SystemRecommendation = _orderManager.GetMostTrendingProduct(CurrentUser.Id);
                    MerchantRecommendation = _orderManager.GetMerchantRecommendation(CurrentUser.Id);
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
