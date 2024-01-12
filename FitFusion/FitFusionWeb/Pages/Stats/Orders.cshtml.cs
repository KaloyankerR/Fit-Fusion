using Services;
using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Microsoft.AspNetCore.Authorization;
using System;

namespace FitFusionWeb.Pages.Stats
{
    [Authorize(Roles = "Owner")]
    public class OrdersModel : PageModel
    {
        private readonly OrderManager _orderManager;
        [BindProperty]
        public List<Order> Orders { get; set; } = new();
        public Dictionary<string, double> OrdersData { get; set; } = new();
        
        public OrdersModel()
        {
            _orderManager = new(new OrderDAO());
        }

        public IActionResult OnGet()
        {
            OrdersData = _orderManager.GetOrdersStats();
            return Page();
        }

    }
}
