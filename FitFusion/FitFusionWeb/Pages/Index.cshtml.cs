using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers;
using Controllers.User;
using Models.User;

namespace FitFusionWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var originalCategory = Category.Protein;

            var stringRes = originalCategory.ToString();
            Category parsedCategory = Enum.TryParse<Category>(stringRes, out var result) ? result : default;

            Console.WriteLine(stringRes);
        }

    }
}