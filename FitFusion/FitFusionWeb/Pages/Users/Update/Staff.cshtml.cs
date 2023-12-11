using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using System.Data;

namespace FitFusionWeb.Pages.Users.Update
{
    [Authorize(Roles = "Owner, Staff")]
    public class StaffModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Staff Staff { get; set; } = new();
        private readonly UserManager _usermanager = new(new UserDAO());

        public void OnGet()
        {
            Staff = (Staff)_usermanager.GetUserById(Id, Staff);
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // _usermanager.CreateUser(Owner);
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
