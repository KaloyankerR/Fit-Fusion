using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAcess;
using Models.Product;
using System;
using System.Collections.Generic;
using Services;
using Services.Filter;
using Services.Sort;
using Models.Product.Enums;
using FitFusionWeb.Converters;
using FitFusionWeb.Views;

namespace FitFusionWeb.Pages.Products
{
    public class AllModel : PageModel
    {
        [BindProperty]
        public string SearchQuery { get; set; } = string.Empty;

        [BindProperty]
        public SortParameter Sort { get; set; }
        [BindProperty]
        public string FilterByCategory { get; set; } = "All";

        public List<ProductView> Products { get; set; } = new();
        private readonly ProductManager productManager = new(new ProductDAO(), new ProductFilter(), new ProductSorter());
        private readonly ProductConverter _converter = new();

        public IActionResult OnGet()
        {
            try
            {
                Products = _converter.ToProductViews(productManager.GetProducts());
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
                var filter = new Dictionary<Enum, object>
                {
                    { FilterParameter.Category, Enum.TryParse(FilterByCategory, true, out Category result) ? result : Category.All }
                };

                List<Product> products = productManager
                    .Sort(
                        productManager
                            .Filter(
                                productManager
                                    .Search(productManager.GetProducts(), SearchQuery),
                                filter),
                        Sort);

                Products = _converter.ToProductViews(products);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }

            return Page();
        }
        
    }
}
