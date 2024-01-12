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
using Interfaces.Strategy;
using Models.User;
using System.ComponentModel.DataAnnotations;

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
        private readonly ProductManager productManager = new(new ProductDAO());
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
                if (MinPrice > MaxPrice)
                {
                    TempData["Type"] = "danger";
                    TempData["Message"] = "Min price should be lower than Max price!";
                }
                else
                {
                    Dictionary<IFilter<Product>, object> filter = new Dictionary<IFilter<Product>, object>
                {
                    { new ProductKeywordFilterStrategy(), SearchQuery },
                    { new CategoryFilterStrategy(), FilterByCategory },
                    { new PriceFilterStrategy(),  new List<double>{ MinPrice, MaxPrice } }
                };

                    ISort<Product> sorter;
                    switch (Sort)
                    {
                        case SortParameter.TitleAsc:
                            sorter = new TitleAscSortStrategy();
                            break;
                        case SortParameter.TitleDesc:
                            sorter = new TitleDescSortStrategy();
                            break;
                        case SortParameter.PriceAsc:
                            sorter = new PriceAscSortStrategy();
                            break;
                        case SortParameter.PriceDesc:
                            sorter = new PriceDescSortStrategy();
                            break;
                        default:
                            sorter = new TitleAscSortStrategy();
                            break;
                    }

                    List<Product> products = productManager.GetProducts();
                    products = productManager.Filter(products, filter);
                    products = productManager.Sort(products, sorter);

                    Products = _converter.ToProductViews(products);
                }
            }
            catch (DataAccessException)
            {
                return RedirectToPage("/Error", new { code = 500 });
            }
            catch (ArgumentException)
            {
                return RedirectToPage("/Error", new { code = 409 });
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
