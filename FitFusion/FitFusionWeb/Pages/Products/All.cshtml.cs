using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using System;
using System.Collections.Generic;
using Controllers;

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
            Products = productManager.Search(Products, SearchQuery);
            Products = productManager.Sort(Products, Sort);
        }
        
    }
}
