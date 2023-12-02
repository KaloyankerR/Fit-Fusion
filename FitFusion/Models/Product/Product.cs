using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class Product
    {
        private int id;
        private string title = string.Empty;
        private string description = string.Empty;
        private double price;
        private Category category;
        private const string DefaultImageUrl = "https://sudbury.legendboats.com/resource/defaultProductImage";
        private string imageUrl = DefaultImageUrl;

        [Key]
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        [Required(ErrorMessage = "Title is required")]
        public string Title
        {
            get { return title; }
            private set { title = value; }
        }
        
        public string Description
        {
            get { return description; }
            private set { description = value; }
        }

        [Required(ErrorMessage = "Price is required")]
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        [Required(ErrorMessage = "Category is required")]
        public Category Category
        {
            get { return category; }
            private set { category = value; }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            private set { imageUrl = value ?? DefaultImageUrl; }
        }

        public Product(int id, string title, string description, double price, Category category, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Category = category;
            ImageUrl = imageUrl;
        }

        public override string ToString()
        {
            return $"{Title} - {Category}";
        }
    }
}
