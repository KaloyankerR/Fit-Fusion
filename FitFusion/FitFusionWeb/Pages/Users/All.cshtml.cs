using DataAcess;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;
using Interfaces.Strategy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Models.User;
using Models.User.Enums;
using Services;
using Services.Filter;
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
        private readonly UserManager _userManager = new(new UserDAO());
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
                List<IFilter<User>> filters = new()
                {
                    { new KeywordFilterStrategy(SearchQuery) },
                    // TODO add the role filter
                    //{ new RoleFilterStrategy(), Enum.TryParse(roleCmbBox.SelectedItem?.ToString(), true, out Role result) ? result : Role.All }
                };

                ISort<User> sorter;
                switch (Sort)
                {
                    case SortParameter.FirstNameAscending:
                        sorter = new FirstNameAscending();
                        break;
                    case SortParameter.FirstNameDescending:
                        sorter = new FirstNameDescending();
                        break;
                    case SortParameter.LastNameAscending:
                        sorter = new LastNameAscending();
                        break;
                    case SortParameter.LastNameDescending:
                        sorter = new LastNameDescending();
                        break;
                    default:
                        sorter = new FirstNameAscending();
                        break;
                }

                List<User> users = _userManager.GetAllUsers();
                users = _userManager.Filter(users, filters);
                users = _userManager.Sort(users, sorter);

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
                    _userManager.DeleteUser(_userManager.GetUserById(id, Role.Owner));
                }
                else if (role == "Staff")
                {
                    _userManager.DeleteUser(_userManager.GetUserById(id, Role.Staff));
                }
                else
                {
                    _userManager.DeleteUser(_userManager.GetUserById(id, Role.Customer));
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
