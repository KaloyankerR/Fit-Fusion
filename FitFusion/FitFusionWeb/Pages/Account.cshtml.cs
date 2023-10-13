using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FitFusionWeb.Pages
{
    //[Authorize]
    public class AccountModel : PageModel
    {
        public string Name { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Name = User.FindFirstValue(ClaimTypes.Name);
            }
            else
            {
                Name = "idk";
            }

        }

    }
}
