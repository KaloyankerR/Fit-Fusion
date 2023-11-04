using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Controllers;

namespace FitFusionWeb.Pages.Users
{
    public class CustomerModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        public List<User> Users { get; set; }
        private UserManager userManager = new(new UserDAO());

        public void OnGet()
        {
            Users = userManager.GetUsers(new Customer());
        }

        public void OnPost()
        {
            Users = userManager.GetUsers(new Customer());
            Users = userManager.Search(Users, SearchQuery);
            Users = userManager.Sort(Users, Sort);
        }
    }
}
