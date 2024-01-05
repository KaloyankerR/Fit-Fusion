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
                List<User> users = _userManager
                    .Sort(
                        _userManager
                            .Search(_userManager.GetAllUsers(), SearchQuery),
                    Sort);

                Users = _converter.ToUserViews(users);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();
        }

        public IActionResult OnPostDelete(int id, string role)
        {
            //TODO implement
            try
            {
                if (role == "Owner")
                {
                    _userManager.DeleteUser(_userManager.GetUserById(id, new Owner()));
                }
                else if (role == "Staff")
                {
                    _userManager.DeleteUser(_userManager.GetUserById(id, new Staff()));
                }
                else
                {
                    _userManager.DeleteUser(_userManager.GetUserById(id, new Customer()));
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }

            return RedirectToPage();
        }

    }
}
