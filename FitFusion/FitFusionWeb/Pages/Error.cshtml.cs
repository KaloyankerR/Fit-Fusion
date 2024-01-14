using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages
{
    public class ErrorModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string code)
        {
            string errorMessage;
            switch (code)
            {
                case "400":
                    errorMessage = "Null reference";
                    break;
                case "404":
                    errorMessage = "Page not found!";
                    break;
                case "409":
                    errorMessage = "Conflict with the current state error!";
                    break;
                case "414":
                    errorMessage = "No orders were made to recommend!";
                    break;
                case "499":
                    errorMessage = "Not Enough Nutri Points!";
                    break;
                case "500":
                    errorMessage = "Internal Server Error! Database problem!";
                    break;

                // TODO: Add more cases as needed

                default:
                    errorMessage = "An error occurred!";
                    break;
            }

            ViewData["ErrorMessage"] = errorMessage;
            _logger.LogError(errorMessage);
            return Page();
        }
    }
}
