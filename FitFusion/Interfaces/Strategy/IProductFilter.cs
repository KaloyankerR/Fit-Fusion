using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Strategy
{
    public interface IProductFilter
    {
        List<Product> Filter(List<Product> products, string param);
    }
}
