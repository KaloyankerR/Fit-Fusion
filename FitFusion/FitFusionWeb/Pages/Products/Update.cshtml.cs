using Controllers.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class UpdateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
        private readonly ProductManager _productManager = new ProductManager(new DataAcess.ProductDAO());

        public void OnGet()
        {
            Product = _productManager.GetProductById(Id);
        }

    }
}
