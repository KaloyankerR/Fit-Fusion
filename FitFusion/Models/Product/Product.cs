using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Models.Product.Enums;

namespace Models.Product
{
    public class Product
    {
        private int _id;
        private string _title = string.Empty;
        private string? _description = string.Empty;
        private double _price;
        private Category _category;
        private string? _imageUrl;

        public int Id
        {
            get { return _id; }
            // private set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            //bprivate set { _title = value; }
        }
        
        public string? Description
        {
            get { return _description; }
            //private set { _description = value; }
        }

        public double Price
        {
            get { return _price; }
            //private set { _price = value; }
        }

        public Category Category
        {
            get { return _category; }
            //private set { _category = value; }
        }

        public string? ImageUrl
        {
            get { return _imageUrl; }
            //private set { _imageUrl = value; }
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

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }

        //    Product otherProduct = (Product)obj;
        //    return Id == otherProduct.Id;
        //}

        //public override int GetHashCode()
        //{
        //    return Id.GetHashCode();
        //}

    }
}
