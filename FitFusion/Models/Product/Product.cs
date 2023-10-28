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
        protected string title;
        public string Title { get { return title; } set { title = value; } }
        protected string description;
        public string Description { get { return description; } set { description = value; } }
        protected double price;
        public double Price { get { return price; } set { price = value; } }
        protected Category category;
        public Category Category { get { return category; } set { category = value; } }
        protected List<Hashtag> hashtags;
        public List<Hashtag> Hashtags { get { return hashtags; } set { hashtags = value; } }
        protected string imageUrl;
        public string ImageUrl { get { return imageUrl; } set { imageUrl = value; } }

        public Product() { }
        
        public Product(int id, string title, string description, double price, Category category, List<Hashtag> hashtags, string imageUrl)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.price = price;
            this.category = category;
            this.hashtags = hashtags ?? new List<Hashtag>();
            this.imageUrl = imageUrl ?? "https://sudbury.legendboats.com/resource/defaultProductImage";
        }

        public override string ToString()
        {
            return $"{Title} - {Category}";
        }
    }
}
