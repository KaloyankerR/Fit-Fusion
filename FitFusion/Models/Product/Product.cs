using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class Product
    {
        protected int id;
        public int Id { get { return id; } set { id = value; } }
        protected string title = string.Empty;
        public string Title { get { return title; } set { title = value; } }
        protected string description = string.Empty;
        public string Description { get { return description; } set { description = value; } }
        protected double price;
        public double Price { get { return price; } set { price = value; } }
        protected Category category;
        public Category Category { get { return category; } set { category = value; } }
        private const string DefaultImageUrl = "https://sudbury.legendboats.com/resource/defaultProductImage";

        protected string imageUrl = DefaultImageUrl;
        public string ImageUrl { get { return imageUrl; } set { imageUrl = value ?? DefaultImageUrl; } }

        public Product() { }
        
        public Product(int id, string title, string description, double price, Category category, string imageUrl)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.price = price;
            this.category = category;
            this.imageUrl = imageUrl ?? DefaultImageUrl;
        }

        public override string ToString()
        {
            return $"{Title} - {Category}";
        }
    }
}
