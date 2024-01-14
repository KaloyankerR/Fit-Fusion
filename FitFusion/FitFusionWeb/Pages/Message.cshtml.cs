using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitFusionWeb.Pages
{
    public class MessageModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        public string PrimaryMessage = string.Empty;

        public MessageModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string message)
        {
            string descriptionMessage;
            switch (message)
            {
                default:
                    descriptionMessage = "Order created!";
                    break;
            }

            PrimaryMessage = message;
            ViewData["Message"] = descriptionMessage;
            _logger.LogError(descriptionMessage);
            return Page();
        }
    }
}
