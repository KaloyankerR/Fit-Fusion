using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using System.Data;

namespace FitFusionWeb.Pages.Users.Create
{
    [Authorize(Roles = "Owner, Staff")]
    public class CustomerModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = new();
        private readonly UserManager _usermanager = new(new UserDAO());

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usermanager.CreateUser(Customer);
                    return RedirectToPage("../All");
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("../CustomPages/DatabaseConnectionError");
            }
            catch (DuplicateNameException)
            {
                return RedirectToPage("../CustomPages/DatabaseConnectionError");
                // set the original page
            }

            return Page();
        }
    }
}
