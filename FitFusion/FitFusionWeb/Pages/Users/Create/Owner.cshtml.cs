using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using Services.Sort;
using System.Data;

namespace FitFusionWeb.Pages.Users.Create
{
    [Authorize(Roles = "Owner, Staff")]
    public class OwnerModel : PageModel
    {
        [BindProperty]
        public Owner Owner { get; set; } = new();
        private readonly UserManager _usermanager = new(new UserDAO(), new UserSorter());

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usermanager.CreateUser(Owner);
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
