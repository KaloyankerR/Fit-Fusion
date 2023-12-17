﻿using Interfaces.Strategy;
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

    public class SortUserByFirstNameDescending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderByDescending(x => x.FirstName).ToList();
        }
    }

    public class SortUserByLastNameAscending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.LastName).ToList();
        }
    }

    public class SortUserByLastNameDescending : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderByDescending(x => x.LastName).ToList();
        }
    }

    public class SortUserByRole : ISort<User>
    {
        public List<User> Sort(List<User> users)
        {
            return users.OrderBy(x => x.GetUserRole()).ToList();
        }
    }
}