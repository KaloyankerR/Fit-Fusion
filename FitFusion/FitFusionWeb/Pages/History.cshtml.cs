using DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Services;

namespace FitFusionWeb.Pages
{
    [Authorize(Roles = "Customer")]
    public class HistoryModel : PageModel
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
