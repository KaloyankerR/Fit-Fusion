using Controllers.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class ProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        private readonly ProductManager _productManager = new ProductManager(new DataAcess.ProductDAO());

        public void OnGet()
        {
            Product = _productManager.GetProductById(Id);
        }
    }
}
