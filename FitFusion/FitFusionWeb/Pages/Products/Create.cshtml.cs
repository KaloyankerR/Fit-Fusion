using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using DataAcess;

namespace FitFusionWeb.Pages.Products
{
    [Authorize(Roles = "Owner, Staff")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly ProductManager _productManager = new(new DataAcess.ProductDAO());

        public void OnGet()
        { }

        public IActionResult OnPost() 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Type"] = "danger";
                    TempData["Message"] = "Please, check the fields again!";
                    return Page();
                }

                if (_productManager.CreateProduct(Product))
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
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }
            catch (DuplicateNameException)
            {
                TempData["Type"] = "danger";
                TempData["Message"] = "Something went wrong!";
            }


            return RedirectToPage("./All");
        }

    }
}
