using Services;
using DataAcess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FitFusionWeb.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
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
            try
            {
                if (ModelState.IsValid)
                {
                    User isAuthenticated = _userManager.AuthenticateUser(Email, Password);
                    SetAuthentication(isAuthenticated);
                    return RedirectToPage("../Index");
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/CustomPages/NotFound");
            }
            catch (Exception)
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
            }

            return Page();
        }

        private void SetAuthentication(User isAuthenticated)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, isAuthenticated.Id.ToString()),
                new Claim(ClaimTypes.Email, isAuthenticated.Email),
                new Claim(ClaimTypes.Role, isAuthenticated.GetUserRole())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

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
        }


    }
}
