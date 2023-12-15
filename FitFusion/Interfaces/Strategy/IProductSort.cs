using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Strategy
{
    public interface IProductSort
    {
        List<Product> Sort(List<Product> products);
    }
}
