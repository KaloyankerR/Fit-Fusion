using Interfaces.Strategy;
using Models.Product;
using Models.User;
using Models.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class KeywordFilterStrategy : IFilter<User>
    {
        private string _searchQuery;

        public KeywordFilterStrategy(string? searchQuery)
        {
            _searchQuery = searchQuery?.ToLower() ?? "";
        }

        public List<User> Filter(List<User> users)
        {
            if (!string.IsNullOrEmpty(_searchQuery))
            {
                users = users.FindAll(u =>
                    u.FirstName.ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    u.LastName.ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    (u.Address ?? "").ToLower().Contains(_searchQuery, StringComparison.OrdinalIgnoreCase)
                );
            }

            return users;
        }
    }

    public class RoleFilterStrategy : IFilter<User>
    {
        private Role _filterValue;

        public RoleFilterStrategy(Role? filterValue)
        {
            _filterValue = filterValue ?? Role.All;
        }

        public List<User> Filter(List<User> users)
        {
            if (_filterValue == Role.All)
            {
                return users;
            }

            return users.Where(u => u.GetUserRole() == _filterValue).ToList();
        }
    }

}
