using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Strategy
{
    public interface IFilter<T>
    {
        // List<T> Filter(List<T> elements, string param);
        List<T> Filter(List<T> elements, Dictionary<string, object> filters);
    }
}
