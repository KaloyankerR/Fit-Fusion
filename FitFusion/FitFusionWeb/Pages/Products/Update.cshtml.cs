using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using DataAcess;
using Services.Filter;
using Services.Sort;

namespace FitFusionWeb.Pages.Products
{
    public class UpdateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Product Product { get; set; } = new();
        private readonly ProductManager _productManager = new (new DataAcess.ProductDAO(), new ProductFilter(), new ProductSorter());

        public IActionResult OnGet()
        {
            try
            {
                Product = _productManager.GetProductById(Id);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/Error", new { code = 404 });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Please check the fields again!";
                    return Page();
                }

                if (_productManager.UpdateProduct(Product))
                {
                    TempData["Type"] = "success";
                    TempData["Message"] = "Product successfully updated!";
                    return RedirectToPage("./All");
                }

                TempData["Type"] = "danger";
                TempData["Message"] = "An error occured!";
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }
            catch (NullReferenceException)
            {
                return RedirectToPage("/CustomPages/NotFound");
            }

            return RedirectToPage("./All");
        }

    }
}
