using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using DataAcess;

namespace FitFusionWeb.Pages.Products
{
    public class ProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        private readonly ProductManager _productManager = new ProductManager(new DataAcess.ProductDAO());

        public IActionResult OnGet()
        {
            try
            {
                Product = _productManager.GetProductById(Id);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/CustomPages/NotFound");
            }
            catch
            {
                return RedirectToPage("/CustomPages/SomethingWentWrong");
            }

            return Page();
        }
    }
}
