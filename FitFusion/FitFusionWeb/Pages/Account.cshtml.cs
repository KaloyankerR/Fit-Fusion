using Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.Security.Claims;
using DataAcess;
using Services.Sort;
using Services.Filter;
using Microsoft.AspNetCore.Http;

namespace FitFusionWeb.Pages
{
    public class AccountModel : PageModel
    {
        [BindProperty]
        public User? CurrentUser { get; set; }
        private UserManager _userManager = new(new DataAcess.UserDAO());

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    var role = User.FindFirstValue(ClaimTypes.Role);

                    CurrentUser = _userManager.GetUserByEmail(email);
                    return Page();
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (NullReferenceException)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage("/Error", new { code = 404 });
            }

            return RedirectToPage("/Authentication/Login");
        }

    }
}
