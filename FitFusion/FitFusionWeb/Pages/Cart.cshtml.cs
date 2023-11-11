using DataAcess;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Order;
using Models.Product;
using Services;

namespace FitFusionWeb.Pages
{
    public class CartModel : PageModel
    {
        public readonly ProductManager ProductManager = new ProductManager(new ProductDAO());
        public ShoppingCart cart = new();
        public List<Product> products = new List<Product>();


        public void OnGet()
        {
            
        }

        public IActionResult OnGetBuy(int id)
        {
            var product = ProductManager.GetProductById(id);
            var cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            
            if (cart == null)
            {
                cart = new List<Product>();
                cart.Add(new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                });

                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                //var index = ShoppingCartAlgorithms.ExistingItem(cart, id);
                //if (index == -1)
                //{
                //    cart.Add(new Item
                //    {
                //        ItemId = product.ItemId,
                //        ItemName = product.ItemName,
                //        ItemQuantity = +1,
                //        ItemPrice = product.ItemPrice
                //    });
                //}
                //else
                //{
                //    var newQuantity = cart[index].ItemQuantity + 1;
                //    cart[index].ItemQuantity = newQuantity;
                //}
                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Product");
        }




    }
}
