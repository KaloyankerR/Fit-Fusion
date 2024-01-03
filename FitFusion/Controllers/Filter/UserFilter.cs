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
        public List<User> Filter(List<User> users, Dictionary<Enum, object> filters)
        {
            FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

            if (filterKey == FilterParameter.Role && filters.TryGetValue(filterKey, out var filterValueObj))
            {
                if (filterValueObj is User filterValue)
                {
                    return users.Where(u => u.GetUserRole() == filterValue.ToString()).ToList();
                }
            }

            return users;
        }
    }


    public class UserFilter
    {
        public List<User> Filter(List<User> users, Dictionary<Enum, object> filters)
        {
            IFilter<User> filter;

            if (filters == null || filters.Count == 0)
            {
                return users;
            }

            FilterParameter filterKey = filters.Keys.OfType<FilterParameter>().FirstOrDefault();

            switch (filterKey)
            {
                case FilterParameter.Role:
                    filter = new RoleFilterStrategy();
                    break;
                //case FilterParameter.NutriPoints:
                //    filter = new PriceFilterStrategy();
                //    break;
                default:
                    return users;
            }

            return filter.Filter(users, filters);
        }
    }
}
