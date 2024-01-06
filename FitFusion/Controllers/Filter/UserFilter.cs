using Interfaces.Strategy;
using Models.User;
using Models.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class RoleFilterStrategy : IFilter<User>
    {
        public List<User> Filter(List<User> users, object param)
        {
            if (param is User filterValue)
            {
                return users.Where(u => u.GetUserRole() == filterValue.ToString()).ToList();
            }

            return users;
        }
    }


    public class UserFilter
    {
        public List<User> Filter(List<User> users, Dictionary<Enum, object> filters)
        {
            if (filters == null || filters.Count == 0)
            {
                return users;
            }

            List<(IFilter<User> FilterStrategy, object FilterValue)> filterStrategies = new List<(IFilter<User>, object)>();

            foreach (var filterEntry in filters)
            {
                if (filterEntry.Key is FilterParameter filterKey)
                {
                    switch (filterKey)
                    {
                        case FilterParameter.Role:
                            filterStrategies.Add((new RoleFilterStrategy(), filterEntry.Value));
                            break;
                            // TODO Add more cases for additional filters
                    }
                }
            }

            if (filterStrategies.Count == 0)
            {
                return users;
            }

            foreach (var (filterStrategy, filterValue) in filterStrategies)
            {
                users = filterStrategy.Filter(users, filterValue);
            }

            return users;
        }


        //public List<User> Filter(List<User> users, Dictionary<Enum, object> filters)
        //{
        //    IFilter<User> filter;

        //    if (filters == null || filters.Count == 0)
        //    {
        //        return users;
        //    }

        //    FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

        //    switch (filterKey)
        //    {
        //        case FilterParameter.Role:
        //            filter = new RoleFilterStrategy();
        //            break;
        //        //case FilterParameter.NutriPoints:
        //        //    filter = new PriceFilterStrategy();
        //        //    break;
        //        default:
        //            return users;
        //    }

        //    return filter.Filter(users, filters);
        //}
    }
}
