using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;

namespace FitFusionWeb.Pages.Users
{
    public class CreateModel : PageModel
    {
        
        public User NewUser { get; set; }
            
        public void OnGet()
        { }

        public void OnPost() 
        {
            if (ModelState.IsValid)
            {
                
            }
        }

    }
}
