using Interfaces.Strategy;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sort
{
    //internal class UserSort
    //{
    //}

    public class SortUserByFirstNameAscending : ISort<User> 
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.FirstName).ToList();
        }
    }

}
