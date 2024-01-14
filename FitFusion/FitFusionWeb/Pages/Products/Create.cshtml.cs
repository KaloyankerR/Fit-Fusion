using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using DataAcess;
using Services.Filter;
using Services.Sort;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;

namespace FitFusionWeb.Pages.Products
{
    [Authorize(Roles = "Owner, Staff")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ProductView ProductView { get; set; } = new();
        private readonly ProductManager _productManager = new(new DataAcess.ProductDAO());
        private readonly ProductConverter _converter = new();

        public void OnGet()
        { }

        public IActionResult OnPost() 
        {
            try
            {
                if (!ModelState.IsValid && ProductView.Category != Models.Product.Enums.Category.All)
                {
                    TempData["Type"] = "danger";
                    TempData["Message"] = "Please, check the fields again!";
                    return Page();
                }

                if (_productManager.CreateProduct(_converter.ToProduct(ProductView)))
                {
                    TempData["Type"] = "success";
                    TempData["Message"] = "Successfully created a product!";
                }
                else
                {
                    TempData["Type"] = "danger";
                    TempData["Message"] = "Something went wrong!";
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (DuplicateNameException)
            {
                TempData["Type"] = "danger";
                TempData["Message"] = "Something went wrong!";
                // TODO: write a better message
            }


            return RedirectToPage("./All");
        }

    }
}
