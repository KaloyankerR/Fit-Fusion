using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using Controllers.Product;
using System;
using System.Collections.Generic;

namespace FitFusionWeb.Pages.Products
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }

        [BindProperty]
        public string Sort { get; set; }

        public List<Product> Products { get; set; }
        private ProductManager productManager = new(new ProductDAO());

        public void OnGet()
        {
            Products = productManager.GetProducts();
        }

        public void OnPost()
        {
            Products = productManager.GetProducts();

            // Apply search filter
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                Products = Products.FindAll(p => p.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(Sort))
            {
                switch (Sort.ToLower())
                {
                    case "titleasc":
                        Products.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.Ordinal));
                        break;
                    case "titledesc":
                        Products.Sort((a, b) => string.Compare(b.Title, a.Title, StringComparison.Ordinal));
                        break;
                }
            }
        }
    }
}
