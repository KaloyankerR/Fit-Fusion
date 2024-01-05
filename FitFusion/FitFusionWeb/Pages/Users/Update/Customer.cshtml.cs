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

namespace FitFusionWeb.Pages.Users.Update
{
    [Authorize(Roles = "Owner, Staff")]
    public class CustomerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public CustomerView Customer { get; set; } = new();
        private readonly UserManager _usermanager = new(new UserDAO(), new UserSorter());
        private readonly UserConverter _converter = new();

        public void OnGet()
        {
            Customer customer = (Customer)_usermanager.GetUserById(Id, new Customer());
            Customer = (CustomerView)_converter.ToUserView(customer);
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usermanager.UpdateUser(_converter.ToUser(Customer));
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
