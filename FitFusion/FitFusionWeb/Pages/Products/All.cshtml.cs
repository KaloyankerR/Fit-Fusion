using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            ProductDAO dao = new ProductDAO();
            List<Product> products = dao.GetAllProducts();
        }
    }
}
