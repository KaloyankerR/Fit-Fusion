using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using System;
using System.Collections.Generic;
using Services;

namespace FitFusionWeb.Pages.Products
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; }

        [BindProperty]
        public string Sort { get; set; }
        [BindProperty]
        public string FilterByCategory { get; set; }

        public List<Product> Products { get; set; }
        private ProductManager productManager = new(new ProductDAO());

        public IActionResult OnGet()
        {
            try
            {
                Products = productManager.GetProducts();
            }
            catch (ApplicationException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            try
            {
                Products = productManager.GetProducts();
                Products = productManager.Search(Products, SearchQuery);
                Products = productManager.Sort(Products, Sort);
                Products = productManager.FilterByCategory(Products, FilterByCategory);
            }
            catch (ApplicationException)
            {
                return RedirectToPage("/CustomPages/DatabaseConnectionError");
            }

            return Page();
        }
        
    }
}
