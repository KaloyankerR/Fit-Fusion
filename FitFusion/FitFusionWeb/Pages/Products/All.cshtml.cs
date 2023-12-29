using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using System;
using System.Collections.Generic;
using Services;
using Services.Filter;
using Services.Sort;

namespace FitFusionWeb.Pages.Products
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; } = string.Empty;

        [BindProperty]
        public string Sort { get; set; } = "titleAsc";
        [BindProperty]
        public string FilterByCategory { get; set; } = "All";

        public List<Product> Products { get; set; } = new();
        private ProductManager productManager = new(new ProductDAO(), new ProductFilter(), new ProductSorter());

        public IActionResult OnGet()
        {
            try
            {
                Products = productManager.GetProducts();
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                Dictionary<string, object> filter = new Dictionary<string, object>();
                filter.Add("category", FilterByCategory);

                Products = productManager.GetProducts();
                Products = productManager.Search(Products, SearchQuery);
                Products = productManager.Filter(Products, filter);
                Products = productManager.Sort(Products, Sort);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }

            return Page();
        }
        
    }
}
