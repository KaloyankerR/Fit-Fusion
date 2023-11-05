﻿using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IProductDAO
    {
        bool CreateProduct(Product product);
        bool UpdateProduct(Product updatedProduct);
        bool DeleteProduct(int productId);
        Product GetProductById(int productId);
        List<Product> GetProducts();
    }
}
