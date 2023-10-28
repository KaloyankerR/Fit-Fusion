using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
using Controllers.User;
using Models.User;
using Controllers.Product;

namespace FitFusionWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // UserManager manager = new(new UserDAO());
            // var res = manager.AuthenticateUser("alice.johnson@example.com", "hashed_password_3");

        }

    }
}