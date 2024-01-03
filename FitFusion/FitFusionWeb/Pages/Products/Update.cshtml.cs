using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using DataAcess;
using Services.Filter;
using Services.Sort;
using Models.Product.Enums;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;

namespace FitFusionWeb.Pages.Products
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public ProductView ProductView { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        private readonly ProductManager _productManager = new (new DataAcess.ProductDAO(), new ProductFilter(), new ProductSorter());
        private readonly ProductConverter _converter = new();

        public IActionResult OnGet()
        {
            try
            {
                ProductView = _converter.ToProductView(_productManager.GetProductById(Id));

                //TODO:
                //if (product != null)
                //{
                //    ProductView = _converter.ToProductView(product);
                //}
                //else
                //{}
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

                if (_productManager.UpdateProduct(_converter.ToProduct(ProductView)))
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
