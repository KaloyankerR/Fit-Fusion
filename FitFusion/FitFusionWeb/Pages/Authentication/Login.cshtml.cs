using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.Security.Claims;

namespace FitFusionWeb.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string UserType { get; set; }  // New bind property for user type

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("../Account");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(UserType))
            {
                // Handle the selected user type here
                if (UserType == "Owner")
                {
                    // Your logic for owner login
                }
                else if (UserType == "Staff")
                {
                    // Your logic for staff login
                }
                else if (UserType == "Customer")
                {
                    // Your logic for customer login
                }

                // Perform authentication based on user type
                // For example, you can use the UserType property in your authentication logic

                // Example code for creating claims (customize based on your needs)
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, Email)); // Use Email or another identifier
                claims.Add(new Claim("userType", UserType));  // Add user type as a claim

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("../Index");
            }

            return Page();
        }
    }
}
