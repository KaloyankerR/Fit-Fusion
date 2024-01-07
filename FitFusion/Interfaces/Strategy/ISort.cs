using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Strategy
{
    public interface ISort<T>
    {
        List<T> Sort(List<T> elements);
        // List<T> Sort(List<T> elements, Enum param);
    }
}
