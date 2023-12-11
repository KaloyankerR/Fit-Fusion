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
                    return RedirectToPage("/Authentication/Login");
                }
            }
            catch (DuplicateNameException)
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
                // redirect to the correct page
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
                // redirect to the correct page
            }
            catch (Exception)
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
            }

            return Page();
        }
    }
}

