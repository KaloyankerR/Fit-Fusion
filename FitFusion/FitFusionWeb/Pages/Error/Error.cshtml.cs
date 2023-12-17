using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages.Error
{
    public class ErrorModel : PageModel
    {
        public IActionResult OnGet(string code)
        {
            switch(code)
            {
                case "404":
                    ViewData["ErrorMessage"] = "Page not found!";
                    break;

                case "500":
                    ViewData["ErrorMessage"] = "Internal Server Error!";
                    break;

                // Add more cases as needed

                default:
                    ViewData["ErrorMessage"] = "An error occurred!";
                    break;
                }

                return Page();
            }
    }
}
