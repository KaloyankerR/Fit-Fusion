using Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();
        private readonly ProductManager _productManager = new(new DataAcess.ProductDAO());

        public void OnGet()
        {
            
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                TempData["Type"] = "danger";
                TempData["Message"] = "Please check the fields again!";
                return Page();
            }

            TempData["Type"] = "success";
            TempData["Message"] = "Successfully created a product!";

            _productManager.CreateProduct(Product);
            return RedirectToPage("./All");
        }
    }
}
