using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using DataAcess;
using Services.Filter;
using Services.Sort;
using FitFusionWeb.Views;
using FitFusionWeb.Converters;

namespace FitFusionWeb.Pages.Products
{
    public class ProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public ProductView ProductView { get; set; } = new();
        private readonly ProductManager _productManager = new ProductManager(new DataAcess.ProductDAO(), new ProductFilter(), new ProductSorter());
        private readonly ProductConverter _converter = new();

        public IActionResult OnGet()
        {
            try
            {
                ProductView = _converter.ToProductView(_productManager.GetProductById(Id));            
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/Error", new { code = 404 });
            }
            catch
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
