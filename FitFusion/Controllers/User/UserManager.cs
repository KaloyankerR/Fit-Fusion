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
        public UserDAO UserDao;

        public UserManager(UserDAO userDao)
        {
            UserDao = userDao;
        }

        public void CreateUser(UserModel user)
        {
            if (user is Owner owner)
            {
                Console.Write(owner.FirstName + " " + owner.LastName);
            }
            else if (user is Staff staff)
            {
                Console.WriteLine(staff.FirstName + " " + staff.LastName);
            }
            else if (user is Customer customer)
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
            else
            {
                throw new ArgumentException("Unknown user type");
            }


        }

    }
}
