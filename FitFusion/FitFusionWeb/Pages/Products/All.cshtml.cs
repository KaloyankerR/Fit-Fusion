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
        public Category FilterByCategory { get; set; } = Category.All;
        [BindProperty]
        public double MinPrice { get; set; }

        [BindProperty]
        public double MaxPrice { get; set; }

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
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                var filter = new Dictionary<Enum, object>
                {
                    { FilterParameter.Category, FilterByCategory },
                    { FilterParameter.Price,  new List<double>{ MinPrice, MaxPrice } }
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
            catch (ArgumentException)
            {
                return RedirectToPage("/Error", new { code = 409});
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                productManager.DeleteProduct(id);
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage();
        }

    }
}
