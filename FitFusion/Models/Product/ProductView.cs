using Models.Product.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class ProductView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; } = 0;

        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; } = Category.All;

        public string? ImageUrl { get; set; }

        public ProductView()
        {
        }

        public ProductView(int id, string title, string description, double price, Category category, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Category = category;
            ImageUrl = imageUrl;
        }
    }
}
