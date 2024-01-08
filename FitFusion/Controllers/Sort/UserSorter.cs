using Interfaces.Strategy;
using Models.User;
using Models.User.Enums;

namespace Services.Sort
{
    public class FirstNameAscending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.FirstName).ToList();
        }
    }

    public class FirstNameDescending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderByDescending(x => x.FirstName).ToList();
        }
    }

    public class LastNameAscending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.LastName).ToList();
        }
    }

    public class LastNameDescending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderByDescending(x => x.LastName).ToList();
        }
    }

    public class RoleAscending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.GetUserRole()).ToList();
        }
    }

    //public class UserSorter
    //{
    //    public List<User> Sort(List<User> users, Enum param)
    //    {
    //        ISort<User> sortStrategy;

    //        switch (param)
    //        {
    //            case SortParameter.FirstNameAscending:
    //                sortStrategy = new FirstNameAscending();
    //                break;
    //            case SortParameter.FirstNameDescending:
    //                sortStrategy = new FirstNameDescending();
    //                break;
    //            case SortParameter.LastNameAscending:
    //                sortStrategy = new LastNameAscending();
    //                break;
    //            case SortParameter.LastNameDescending:
    //                sortStrategy = new LastNameDescending();
    //                break;
    //            case SortParameter.Role:
    //                sortStrategy = new RoleAscending();
    //                break;
    //            default:
    //                return users;
    //        }

    //        try
    //        {
    //            return sortStrategy.Sort(users);
    //        }
    //        catch
    //        {
    //            throw new ArgumentException("Error during the sorting process.");
    //        }
    //    }
    //}
}
