using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    //internal class Exceptions
    //{ }

    public class DataAccessException : Exception 
    {
        public DataAccessException(string message) : base(message) { }
        public DataAccessException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }

}
