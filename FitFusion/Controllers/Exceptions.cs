using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SortException : Exception
    {
        public SortException(string message) : base(message) { }
        public SortException(string message, Exception ex) : base(message, ex) { }
    }

    public class FilterException : Exception
    {
        public FilterException(string message) : base(message) { }
        public FilterException(string message, Exception ex) : base(message, ex) { }
    }


}
