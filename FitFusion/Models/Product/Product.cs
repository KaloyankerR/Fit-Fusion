using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Models.Product.Enums;

namespace Models.Product
{
    [Serializable]
    public class Product
    {
        [JsonProperty]
        private int _id;
        [JsonProperty]
        private string _title = string.Empty;
        [JsonProperty]
        private string? _description = string.Empty;
        [JsonProperty]
        private double _price;
        [JsonProperty]
        private Category _category;
        [JsonProperty]
        private string? _imageUrl;

        public int Id
        {
            get { return _id; }
        }

        public string Title
        {
            get { return _title; }
        }
        
        public string? Description
        {
            get { return _description; }
        }

        public double Price
        {
            get { return _price; }
        }

        public Category Category
        {
            get { return _category; }
        }

        public string? ImageUrl
        {
            get { return _imageUrl; }
        }

        public Product() { }

        public Product(int id, string title, string? description, double price, Category category, string? imageUrl)
        {
            _id = id;
            _title = title;
            _description = description;
            _price = price;
            _category = category;
            _imageUrl = imageUrl;
        }

        public override string ToString()
        {
            return $"{Title} - {Category}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product otherProduct = (Product)obj;
            return Id == otherProduct.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
