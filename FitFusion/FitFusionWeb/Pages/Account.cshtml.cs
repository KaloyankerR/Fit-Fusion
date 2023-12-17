using Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.Security.Claims;
using DataAcess;

namespace FitFusionWeb.Pages
{
    public class AccountModel : PageModel
    {
        [BindProperty]
        public User CurrentUser { get; set; }
        private UserManager _userManager = new(new DataAcess.UserDAO());

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    var role = User.FindFirstValue(ClaimTypes.Role);
                    User newRole;

                    switch (role)
                    {
                        case "Owner":
                            newRole = new Owner();
                            break;
                        case "Staff":
                            newRole = new Staff();
                            break;
                        case "Customer":
                            newRole = new Customer();
                            break;
                    }

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
                return RedirectToPage("/Error", new { code = 404 });
            }

            return RedirectToPage("/Authentication/Login");
        }

    }
}
