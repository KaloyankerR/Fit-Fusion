using DataAcess;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;
using Services.Sort;
using System.Data;
using Services.Filter;

namespace FitFusionWeb.Pages.Users.Update
{
    [Authorize(Roles = "Owner, Staff")]
    public class StaffModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public StaffView Staff { get; set; } = new();
        private readonly UserManager _usermanager = new(new UserDAO(), new UserFilter(), new UserSorter());
        private readonly UserConverter _converter = new();

        public void OnGet()
        {
            Staff staff = (Staff)_usermanager.GetUserById(Id, new Staff());
            Staff = (StaffView)_converter.ToUserView(staff);
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usermanager.UpdateUser(_converter.ToUser(Staff));
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
