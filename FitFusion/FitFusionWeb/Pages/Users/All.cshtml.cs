using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;

namespace FitFusionWeb.Pages.Users
{
    [Authorize(Roles = "Owner, Staff")]
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        public List<User> Users { get; set; }
        private readonly UserManager _userManager = new(new UserDAO());

        public IActionResult OnGet()
        {
            try
            {
                Users = _userManager.GetAllUsers();
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();
        }
        
        public IActionResult OnPost()
        {
            try
            {
                Users = _userManager.GetAllUsers();
                Users = _userManager.Search(Users, SearchQuery);
                Users = _userManager.Sort(Users, Sort);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();
        }


    }
}
