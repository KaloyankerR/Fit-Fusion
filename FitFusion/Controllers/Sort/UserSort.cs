using Interfaces.Strategy;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sort
{
    public class UserSorter : ISort<User>
    {
        public List<User> Sort(List<User> users, Enum param)
        {
            switch (param)
            {
                case SortParameter.FirstNameAscending:
                    return users.OrderBy(x => x.FirstName).ToList();
                case SortParameter.FirstNameDescending:
                    return users.OrderByDescending(x => x.FirstName).ToList();
                case SortParameter.LastNameAscending:
                    return users.OrderBy(x => x.LastName).ToList();
                case SortParameter.LastNameDescending:
                    return users.OrderByDescending(x => x.LastName).ToList();
                case SortParameter.Role:
                    return users.OrderBy(x => x.GetUserRole()).ToList();
                default:
                    return users;
            }
        }
    }

    //public class SortUserByFirstNameAscending : ISort<User> 
    //{
    //    public List<User> Sort(List<User> users)
    //    {
    //        return users.OrderBy(x => x.FirstName).ToList();
    //    }
    //}

    //public class SortUserByFirstNameDescending : ISort<User>
    //{
    //    public List<User> Sort(List<User> users)
    //    {
    //        return users.OrderByDescending(x => x.FirstName).ToList();
    //    }
    //}

    //public class SortUserByLastNameAscending : ISort<User>
    //{
    //    public List<User> Sort(List<User> users)
    //    {
    //        return users.OrderBy(x => x.LastName).ToList();
    //    }
    //}

    //public class SortUserByLastNameDescending : ISort<User>
    //{
    //    public List<User> Sort(List<User> users)
    //    {
    //        return users.OrderByDescending(x => x.LastName).ToList();
    //    }
    //}

    //public class SortUserByRole : ISort<User>
    //{
    //    public List<User> Sort(List<User> users)
    //    {
    //        return users.OrderBy(x => x.GetUserRole()).ToList();
    //    }
    //}
}
