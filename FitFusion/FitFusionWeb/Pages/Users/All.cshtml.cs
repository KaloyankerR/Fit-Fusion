using DataAcess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using Services;

namespace FitFusionWeb.Pages.Users
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        public List<User> Users { get; set; }
        private readonly UserManager _userManager = new(new UserDAO());

        public void OnGet()
        {
            Users = _userManager.GetAllUsers();
        }
        
        public void OnPost()
        {
            Users = _userManager.GetAllUsers();
            Users = _userManager.Search(Users, SearchQuery);
            Users = _userManager.Sort(Users, Sort);
        }

    }
}
