using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Services;
using Models.User;
using FitFusionWeb.Pages.Products;
using Models.Order;

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
            OrderManager manager = new(new OrderDAO(), new AlgorithmManager());


        }

    }
}