using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using System.Data;

namespace FitFusionWeb.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = new();
        private readonly UserManager _userManager = new UserManager(new UserDAO());
        private readonly ILogger<ErrorModel> _logger;

        public RegisterModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

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
                if (!ModelState.IsValid)
                {
                    _userManager.CreateUser(Customer);
                    _logger.LogInformation("Register successful");
                    return RedirectToPage("/Authentication/Login");
                }
            }
            catch (DuplicateNameException)
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
                // TODO: redirect to the correct page
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}

