using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages
{
    public class MessageModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        public string PrimaryMessage;

        public MessageModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string message)
        {
            string descriptionMessage;
            switch (message)
            {
                case "400":
                    descriptionMessage = "Null reference";
                    break;
                case "404":
                    descriptionMessage = "Page not found!";
                    break;
                case "409":
                    descriptionMessage = "Conflict with the current state error!";
                    break;
                case "499":
                    descriptionMessage = "Not Enough Nutri Points!";
                    break;
                case "500":
                    descriptionMessage = "Internal Server Error! Database problem!";
                    break;

                // TODO: Add more cases as needed

                default:
                    descriptionMessage = "An error occurred!";
                    break;
            }

            PrimaryMessage = message;
            ViewData["Message"] = descriptionMessage;
            _logger.LogError(descriptionMessage);
            return Page();
        }
    }
}
