using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Controllers;

namespace FitFusionWeb.Pages.Users
{
    public class OwnerModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        public List<User> Users { get; set; }
        private UserManager userManager = new(new UserDAO());

        public void OnGet()
        {
            Users = userManager.GetUsers(new Owner());
        }

        public void OnPost()
        {
            Users = userManager.GetUsers(new Owner());
            Users = userManager.SearchFilter(Users, SearchQuery);
            Users = userManager.Sort(Users, Sort);
        }

    }
}
