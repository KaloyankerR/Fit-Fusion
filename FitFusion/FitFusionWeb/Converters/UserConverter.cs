using FitFusionWeb.Views;
using Models.User;

namespace FitFusionWeb.Converters
{
    public interface IUserConverter
    {
        UserView ToUserView(User user);
        User ToUser(UserView userView);
        List<UserView> ToUserViews(List<User> user);
        List<User> ToUsers(List<UserView> userViews);
    }

    public class UserConverter : IUserConverter
    {
        public User ToUser(UserView userView)
        {
            if (userView is OwnerView ownerView)
            {
                return new Owner
                    (
                        id: ownerView.Id,
                        firstName: ownerView.FirstName,
                        lastName: ownerView.LastName,
                        email: ownerView.Email,
                        passwordHash: ownerView.Password,
                        passwordSalt: string.Empty,
                        address: ownerView.Address,
                        phone: ownerView.Phone
                    );
            }
            else if (userView is StaffView staffView)
            {
                return new Staff
                    (
                        id: staffView.Id,
                        firstName: staffView.FirstName,
                        lastName: staffView.LastName,
                        email: staffView.Email,
                        passwordHash: staffView.Password,
                        passwordSalt: string.Empty,
                        address: staffView.Address,
                        phone: staffView.Phone
                    );
            }
            else
            {
                CustomerView customerView = (CustomerView)userView;

                return new Customer
                    (
                        id: customerView.Id,
                        firstName: customerView.FirstName,
                        lastName: customerView.LastName,
                        email: customerView.Email,
                        passwordHash: customerView.Password,
                        passwordSalt: string.Empty,
                        address: customerView.Address,
                        nutriPoints: customerView.NutriPoints
                    );
            }

            // throw new NotImplementedException();
        }

        public List<User> ToUsers(List<UserView> userViews)
        {
            List<User> users = new();

            foreach (UserView userView in userViews)
            {
                users.Add(ToUser(userView));
            }

            return users;
        }

        public UserView ToUserView(User user)
        {
            if (user is Owner owner)
            {
                return new OwnerView
                {
                    Id = owner.Id,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Email = owner.Email,
                    Password = owner.PasswordHash,
                    Address = owner.Address,
                    Phone = owner.Phone,
                };
            }
            else if (user is Staff staff)
            {
                return new StaffView
                {
                    Id = staff.Id,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Password = staff.PasswordHash,
                    Address = staff.Address,
                    Phone = staff.Phone,
                };
            }
            //else if (user is Customer customer)
            //TODO: raise an exception appropriate
            else
            {
                Customer customer = (Customer)user;

                return new CustomerView
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Password = customer.PasswordHash,
                    Address = customer.Address,
                    NutriPoints = customer.NutriPoints,
                };
            }

            // throw new NotImplementedException();
        }

        public List<UserView> ToUserViews(List<User> users)
        {
            List<UserView> userViews = new();

            foreach (User user in users)
            {
                userViews.Add(ToUserView(user));
            }

            return userViews;
        }
    }
}
