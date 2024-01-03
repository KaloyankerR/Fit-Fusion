using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;
using DataAcess;
using Services.Filter;
using Services.Sort;
using Models.Product.Enums;

namespace FitFusionWeb.Pages.Products
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
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
                int id = int.Parse(Request.Form["Product.Id"]);
                string title = Request.Form["Product.Title"];
                string description = Request.Form["Product.Description"];
                decimal price = decimal.Parse(Request.Form["Product.Price"]);
                Category category = Enum.Parse<Category>(Request.Form["Product.Category"]);
                string imageUrl = Request.Form["Product.ImageUrl"];

                Product updatedProduct = new Product
                (
                    id: id,
                    title: title,
                    description: description,
                    price: Convert.ToDouble(price),
                    category: category,
                    imageUrl: imageUrl
                );

                if (_productManager.UpdateProduct(updatedProduct))
                {
                    TempData["Type"] = "success";
                    TempData["Message"] = "Product successfully updated!";
                    return RedirectToPage("./All");
                }

                TempData["Type"] = "danger";
                TempData["Message"] = "An error occurred!";
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
