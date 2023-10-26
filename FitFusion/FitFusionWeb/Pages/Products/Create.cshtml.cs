using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Product;

namespace FitFusionWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();

        public void OnGet()
        {
        }

        public void OnPost() 
        {
        }
    }
}
