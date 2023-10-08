using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public string ImageUrl { get; set; }
        //public List<Hashtag> Hahstags { get; set; }

        public Product() { }

        public Product(int id, string title, string description, Category productCategory, string imageUrl = "https://sudbury.legendboats.com/resource/defaultProductImage")
        {
            Id = id;
            Title = title;
            Description = description;
            ProductCategory = productCategory;
            ImageUrl = imageUrl;
            //Hahstags = hahstags ?? new List<Hashtag>();
        }

    }
}
