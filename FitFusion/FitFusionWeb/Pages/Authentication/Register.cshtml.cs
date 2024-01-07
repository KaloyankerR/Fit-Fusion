using DataAcess;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using Services.Filter;
using Services.Sort;
using System.Data;

namespace FitFusionWeb.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public CustomerView Customer { get; set; } = new();
        private readonly UserManager _userManager = new UserManager(new UserDAO(), new UserFilter(), new UserSorter());
        private readonly UserConverter _converter = new();
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
                    _userManager.CreateUser(_converter.ToUser(Customer));
                    _logger.LogInformation("Register successful");
                    return RedirectToPage("/Authentication/Login");
                }
            }
            catch (DuplicateNameException)
            {
                return RedirectToPage("/Error", new { code = 409 });
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

