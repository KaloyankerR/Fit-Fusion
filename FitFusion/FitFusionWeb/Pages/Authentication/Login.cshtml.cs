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
using Services.Sort;
using Services.Filter;

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

        private readonly ILogger<ErrorModel> _logger;

        public LoginModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                // _logger.LogInformation("User has already logged in!");
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
                    _logger.LogInformation("Login successful!");
                    User isAuthenticated = _userManager.AuthenticateUser(Email, Password);
                    SetAuthentication(isAuthenticated);
                    return RedirectToPage("../Index");
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
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        private void SetAuthentication(User isAuthenticated)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, isAuthenticated.Id.ToString()),
                new Claim(ClaimTypes.Email, isAuthenticated.Email),
                new Claim(ClaimTypes.Role, isAuthenticated.GetUserRole().ToString()) // TODO check 
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
            HttpContext.Session.SetString("Role", isAuthenticated.GetUserRole().ToString());
        }


    }
}
