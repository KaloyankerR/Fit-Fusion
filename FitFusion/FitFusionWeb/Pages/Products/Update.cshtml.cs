using Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class UpdateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Product Product { get; set; } = new Product();
        private readonly ProductManager _productManager = new ProductManager(new DataAcess.ProductDAO());

        public void OnGet()
        {
            Product = _productManager.GetProductById(Id);
        }

        public IActionResult OnPost()
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
            return RedirectToPage("./All");
        }

    }
}
