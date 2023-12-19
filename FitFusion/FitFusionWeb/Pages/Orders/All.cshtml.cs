using DataAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Services;

namespace FitFusionWeb.Pages.Orders
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public List<Order> Orders { get; set; } = new();
        private readonly OrderManager _orderManager = new(new OrderDAO());

        public void OnGet()
        {
            Orders = _orderManager.GetOrders();
        }
    }
}
