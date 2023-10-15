using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using Models.User;
using UserModel = Models.User.User;

namespace Controllers.User
{
    public class UserManager
    {
        public UserDAO userDAO;

        public UserManager(UserDAO userDao)
        {
            userDAO = userDao;
        }

        public void CreateUser(UserModel user)
        {
            try
            {
                userDAO.CreateUser(user);
            }
            catch 
            {
                throw new Exception("Unable to add the current user.");
            }

            //if (user is Owner owner)
            //{
            //    userDAO.CreateUser(user);
            //}
            //else if (user is Staff staff)
            //{
            //    Console.WriteLine(staff.FirstName + " " + staff.LastName);
            //}
            //else if (user is Customer customer)
            //{
            //    Console.WriteLine(customer.FirstName + " " + customer.LastName);
            //}
            //else
            //{
            //    throw new ArgumentException("Unknown user type");
            //}
        }

    }
}

