using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
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
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = new Customer (id: 4 ),
                Note = "Let her go test order",
                ShoppingCart = new ShoppingCart
                {
                    Products = new List<Product>
                {
                    new Product { Id = 1, Price = 10 }, 
                    new Product { Id = 3, Price = 25 }  
                }    
                },
            };

            order.TotalPrice = order.CalculateTotalPrice();

            OrderDAO dao = new OrderDAO();
            // bool result = dao.CreateOrder(order);
            var result2 = dao.GetOrders();
            
        }

    }
}