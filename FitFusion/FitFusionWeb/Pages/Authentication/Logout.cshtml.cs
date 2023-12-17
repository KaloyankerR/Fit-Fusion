using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;

        public LogoutModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("Log out successful!");
            return RedirectToPage("/Index");
        }

    }
}
