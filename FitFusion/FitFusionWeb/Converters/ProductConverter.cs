using FitFusionWeb.Views;
using Models.Product;

namespace FitFusionWeb.Converters
{
    public interface IProductConverter
    {
        ProductView ToProductView(Product product);
        Product ToProduct(ProductView productView);
        List<ProductView> ToProductViews(List<Product> products);
        List<Product> ToProducts(List<ProductView> productViews);
    }

    public class ProductConverter : IProductConverter
    {
        public ProductView ToProductView(Product product)
        {
            return new ProductView
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ImageUrl = product.ImageUrl
            };
        }

        public Product ToProduct(ProductView productView)
        {
            return new Product
            (
                id: productView.Id,
                title: productView.Title,
                description: productView.Description,
                price: productView.Price,
                category: productView.Category,
                imageUrl: productView.ImageUrl
            );
        }

        public List<ProductView> ToProductViews(List<Product> products)
        {
            return products.Select(p => ToProductView(p)).ToList();
        }

        public List<Product> ToProducts(List<ProductView> productViews)
        {
            return productViews.Select(pv => ToProduct(pv)).ToList();
        }
    }
}
