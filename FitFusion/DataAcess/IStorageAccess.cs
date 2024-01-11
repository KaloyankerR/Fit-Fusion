using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public interface IStorageAccess
    {
        void TestConnectionString();
        void ChangeConnectionString(string newConnectionString);
    }
}
