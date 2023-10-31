using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
// using Controllers.User;
using Models.User;
// using Controllers.Product;

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
            //UserDAO dao = new UserDAO();
            //Customer customer = new Customer
            //    (
            //    id: 0,
            //    firstName: "Troy",
            //    lastName: "Georgiev",
            //    email: "troy@gmail.com",
            //    passwordHash: "troy@gmail.com",
            //    passwordSalt: null,
            //    address: "Eindhoven",
            //    loyaltyScore: 0
            //    );

            // dao.CreateUser(customer);
            // dao.AuthenticateUser("troy@gmail.com", "troy@gmail.com"); 
        }

    }
}