using Interfaces.Strategy;
using Models.User;
using Models.User.Enums;

namespace Services.Sort
{
    public class UserSorter : ISort<User>
    {
        public List<User> Sort(List<User> users, Enum param)
        {
            switch (param)
            {

                case SortParameter.FirstNameAscending:
                    return SortByFirstNameAscending(users);
                case SortParameter.FirstNameDescending:
                    return SortByFirstNameDescending(users);
                case SortParameter.LastNameAscending:
                    return SortByLastNameAscending(users);
                case SortParameter.LastNameDescending:
                    return SortByLastNameDescending(users);
                case SortParameter.Role:
                    return SortByRole(users);
                default:
                    return users;
            }
        }

        private List<User> SortByFirstNameAscending(List<User> users)
        {
            return users.OrderBy(x => x.FirstName).ToList();
        }

        private List<User> SortByFirstNameDescending(List<User> users)
        {
            return users.OrderByDescending(x => x.FirstName).ToList();
        }

        private List<User> SortByLastNameAscending(List<User> users)
        {
            return users.OrderBy(x => x.LastName).ToList();
        }

        private List<User> SortByLastNameDescending(List<User> users)
        {
            return users.OrderByDescending(x => x.LastName).ToList();
        }

        private List<User> SortByRole(List<User> users)
        {
            return users.OrderBy(x => x.GetUserRole()).ToList();
        }
    }
}
