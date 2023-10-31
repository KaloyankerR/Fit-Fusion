using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
// using Controllers.User;
using Models.User;
using FitFusionWeb.Pages.Products;
using Models.Order;
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
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = new Customer (id: 3 ),
                Note = "Test order",
                ShoppingCart = new ShoppingCart
                {
                    Products = new List<Product>
                {
                    new Product { Id = 1 }, 
                    new Product { Id = 3 }  
                },
                    Discount = 10
                }
            };

            OrderDAO dao = new OrderDAO(); 
            bool result = dao.CreateOrder(order);

            if (result)
            {
                Console.WriteLine("Order created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create order.");
            }
        }

    }
}