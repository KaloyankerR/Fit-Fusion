using DataAcess;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Models.User.Enums;
using Services;
using Services.Sort;

namespace FitFusionWeb.Pages.Users
{
    [Authorize(Roles = "Owner, Staff")]
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; } = string.Empty;
        [BindProperty]
        public SortParameter Sort { get; set; }

        public List<UserView> Users { get; set; } = new();
        // public List<User> Users { get; set; } = new List<User>();
        private readonly UserManager _userManager = new(new UserDAO(), new UserSorter());
        private readonly UserConverter _converter = new();

        public IActionResult OnGet()
        {
            try
            {
                List<User> users = _userManager.GetAllUsers();
                Users = _converter.ToUserViews(users);            
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
                List<User> users = new();

                users = _userManager.GetAllUsers();
                users = _userManager.Search(users, SearchQuery);
                users = _userManager.Sort(users, Sort);

                Users = _converter.ToUserViews(users);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();
        }


    }
}
