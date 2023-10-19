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
        public int Id { get { return id; } protected set { id = value; } }
        protected string title;
        public string Title { get { return title; } protected set { title = value; } }
        protected string description;
        public string Description { get { return description; } protected set { description = value; } }
        protected Category category;
        public Category Category { get { return category; } protected set { category = value; } }
        protected List<Hashtag> hashtags;
        public List<Hashtag> Hahstags { get { return hashtags; } protected set { hashtags = value; } }
        protected string imageUrl;
        public string ImageUrl { get { return imageUrl; } protected set { imageUrl = value; } }

        public Product() { }
        
        public Product(int id, string title, string description, Category category, List<Hashtag> hahstags, string imageUrl)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.category = category;
            this.hashtags = hahstags ?? new List<Hashtag>();
            this.imageUrl = imageUrl ?? "https://sudbury.legendboats.com/resource/defaultProductImage";
        }

        public override string ToString()
        {
            return $"{Title} - {Category}";
        }
    }
}
