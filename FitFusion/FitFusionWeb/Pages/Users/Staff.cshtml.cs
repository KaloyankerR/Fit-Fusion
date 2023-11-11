using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;

namespace FitFusionWeb.Pages.Users
{
    public class StaffModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        public List<User> Users { get; set; }
        private UserManager userManager = new(new UserDAO());

        public void OnGet()
        {
            Users = userManager.GetUsers(new Staff());
        }

        public void OnPost()
        {
            Users = userManager.GetUsers(new Staff());
            Users = userManager.Search(Users, SearchQuery);
            Users = userManager.Sort(Users, Sort);
        }

    }
}
