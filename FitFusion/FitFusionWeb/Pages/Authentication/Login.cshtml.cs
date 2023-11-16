using Services;
using DataAcess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace FitFusionWeb.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public bool RememberMe { get; set; }
        private readonly UserManager _userManager = new(new UserDAO());

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToPage("../Account");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var isAuthenticated = _userManager.AuthenticateUser(Email, Password);
                if (isAuthenticated != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, isAuthenticated.Id.ToString()),
                        new Claim(ClaimTypes.Email, isAuthenticated.Email),
                        new Claim(ClaimTypes.Role, isAuthenticated.GetUserRole())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    // HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    AuthenticationProperties? authProperties = null;
                    if (RememberMe)
                    {
                        authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5)
                        };
                    }

                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);
                    HttpContext.Session.SetString("Id", isAuthenticated.Id.ToString());
                    HttpContext.Session.SetString("Email", isAuthenticated.Email);
                    HttpContext.Session.SetString("Role", isAuthenticated.GetUserRole());

                    return RedirectToPage("../Index");
                }
            }

            return Page();
        }

    }
}
