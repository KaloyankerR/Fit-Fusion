using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;
using System.Data.SqlClient;
using DataAcess.Interfaces;

namespace DataAcess
{
    public class UserDAO : IUserDAO
    {
        private readonly string ConnectionString;

        public UserDAO()
        {
            ConnectionString = Connection.DbConnection.ConnectionString;
        }

        public UserDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string insertUserQuery = "";

                if (user is Staff)
                {
                    insertUserQuery = "INSERT INTO Staff (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone) " +
                                      "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @Phone);";
                }
                else if (user is Owner)
                {
                    insertUserQuery = "INSERT INTO Owner (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone) " +
                                      "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @Phone);";
                }
                else if (user is Customer)
                {
                    insertUserQuery = "INSERT INTO Customer (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, LoyaltyScore) " +
                                      "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @LoyaltyScore);";
                }

                using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    string salt = BCrypt.Net.BCrypt.GenerateSalt();
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash, salt);

                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@PasswordSalt", salt);
                    // command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    // command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                    command.Parameters.AddWithValue("@Address", user.Address);

                    if (user is Staff)
                    {
                        command.Parameters.AddWithValue("@Phone", ((Staff)user).Phone);
                    }
                    else if (user is Owner)
                    {
                        command.Parameters.AddWithValue("@Phone", ((Owner)user).Phone);
                    }
                    else if (user is Customer)
                    {
                        command.Parameters.AddWithValue("@LoyaltyScore", ((Customer)user).LoyaltyScore);
                    }

                    command.ExecuteNonQuery();
                }

                return true;
            }
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string updateUserQuery = "";

                if (user is Staff)
                {
                    updateUserQuery = "UPDATE Staff SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, Phone = @Phone " +
                                      "WHERE Id = @Id;";
                }
                else if (user is Owner)
                {
                    updateUserQuery = "UPDATE Owner SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, Phone = @Phone " +
                                      "WHERE Id = @Id;";
                }
                else if (user is Customer)
                {
                    updateUserQuery = "UPDATE Customer SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, LoyaltyScore = @LoyaltyScore " +
                                      "WHERE Id = @Id;";
                }

                using (SqlCommand command = new SqlCommand(updateUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                    command.Parameters.AddWithValue("@Address", user.Address);

                    command.Parameters.AddWithValue("@Id", user.Id);

                    if (user is Staff)
                    {
                        command.Parameters.AddWithValue("@Phone", ((Staff)user).Phone);
                    }
                    else if (user is Owner)
                    {
                        command.Parameters.AddWithValue("@Phone", ((Owner)user).Phone);
                    }
                    else if (user is Customer)
                    {
                        command.Parameters.AddWithValue("@LoyaltyScore", ((Customer)user).LoyaltyScore);
                    }

                    command.ExecuteNonQuery();
                }

                return true;
            }
        }

        public bool DeleteUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string deleteUserQuery = "";

                if (user is Staff)
                {
                    deleteUserQuery = "DELETE FROM Staff WHERE Id = @Id;";
                }
                else if (user is Owner)
                {
                    deleteUserQuery = "DELETE FROM Owner WHERE Id = @Id;";
                }
                else if (user is Customer)
                {
                    deleteUserQuery = "DELETE FROM Customer WHERE Id = @Id;";
                }

                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);

                    command.ExecuteNonQuery();
                }

                return true;
            }
        }

        public User GetUser(int id, User role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getUserQuery = "";
                string additionalProperty = "";

                if (role is Staff)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Owner)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Customer)
                {
                    additionalProperty = "LoyaltyScore";
                }

                getUserQuery = $"SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, {additionalProperty} " +
                               $"FROM {role.GetType().Name} " +
                               $"WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(getUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (role is Staff)
                            {
                                Staff staff = new Staff(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                return staff;
                            }
                            else if (role is Owner)
                            {
                                Owner owner = new Owner
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                return owner;
                            }
                            else if (role is Customer)
                            {
                                Customer customer = new Customer
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    loyaltyScore: reader.GetInt32(reader.GetOrdinal("LoyaltyScore"))
                                );

                                return customer;
                            }
                        }
                    }
                }

                return null;
            }
        }

        //public User GetUserByEmail(string email)
        //{ }

        public User GetUserByEmail(string email, User role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getUserQuery = "";
                string additionalProperty = "";

                if (role is Staff)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Owner)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Customer)
                {
                    additionalProperty = "LoyaltyScore";
                }

                getUserQuery = $"SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, {additionalProperty} " +
                               $"FROM {role.GetType().Name} " +
                               $"WHERE Email = @Email;";

                using (SqlCommand command = new SqlCommand(getUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (role is Staff)
                            {
                                Staff staff = new Staff
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                return staff;
                            }
                            else if (role is Owner)
                            {
                                Owner owner = new Owner
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                return owner;
                            }
                            else if (role is Customer)
                            {
                                Customer customer = new Customer
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    loyaltyScore: reader.GetInt32(reader.GetOrdinal("LoyaltyScore"))
                                );

                                return customer;
                            }
                        }
                    }
                }

                return null;
            }
        }

        public List<User> GetUsers(User role)
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getAllUsersQuery = "";
                string additionalProperty = "";

                if (role is Staff)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Owner)
                {
                    additionalProperty = "Phone";
                }
                else if (role is Customer)
                {
                    additionalProperty = "LoyaltyScore";
                }

                getAllUsersQuery = $"SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, {additionalProperty} " +
                                          $"FROM {role.GetType().Name};";

                using (SqlCommand command = new SqlCommand(getAllUsersQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user;

                            if (role is Staff)
                            {
                                user = new Staff(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                users.Add(user);
                            }
                            else if (role is Owner)
                            {
                                user = new Owner
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    phone: reader.GetString(reader.GetOrdinal("Phone"))
                                );

                                users.Add(user);
                            }
                            else if (role is Customer)
                            {
                                user = new Customer
                                (
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                                    lastName: reader.GetString(reader.GetOrdinal("LastName")),
                                    email: reader.GetString(reader.GetOrdinal("Email")),
                                    passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
                                    address: reader.GetString(reader.GetOrdinal("Address")),
                                    loyaltyScore: reader.GetInt32(reader.GetOrdinal("LoyaltyScore"))
                                );

                                users.Add(user);
                            }

                            // users.Add(user);
                        }
                    }
                }
            }

            return users;
        }


        public bool IsEmailAlreadyExists(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string checkEmailQuery = "SELECT SUM(EmailCount) AS TotalCount " +
                                         "FROM (" +
                                         "    SELECT COUNT(*) AS EmailCount FROM Owner WHERE Email = @Email " +
                                         "    UNION ALL " +
                                         "    SELECT COUNT(*) AS EmailCount FROM Staff WHERE Email = @Email " +
                                         "    UNION ALL " +
                                         "    SELECT COUNT(*) AS EmailCount FROM Customer WHERE Email = @Email" +
                                         ") AS Subquery";

                using (SqlCommand command = new SqlCommand(checkEmailQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    int totalCount = (int)command.ExecuteScalar();

                    return totalCount > 0;
                }
            }
        }
        //public bool ChangePassword(string email, string oldPassword, string newPassword)
        //{ }


        public User? AuthenticateUser(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectUserQuery = @"
                    SELECT Email, PasswordHash, PasswordSalt, 'Customer' as Role FROM Customer c WHERE c.Email = @Email
                    UNION
                    SELECT Email, PasswordHash, PasswordSalt, 'Owner' as Role FROM Owner o WHERE o.Email = @Email
                    UNION
                    SELECT Email, PasswordHash, PasswordSalt, 'Staff' as Role FROM Staff s WHERE s.Email = @Email";

                using (SqlCommand command = new SqlCommand(selectUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string storedPasswordHash = reader["PasswordHash"].ToString();
                            string storedPasswordSalt = reader["PasswordSalt"].ToString();
                            string role = reader["Role"].ToString();

                            if (VerifyPassword(password, storedPasswordHash, storedPasswordSalt))
                            {
                                switch (role)
                                {
                                    case "Staff":
                                        return GetUserByEmail(email, new Staff());
                                    case "Owner":
                                        return GetUserByEmail(email, new Owner());
                                    case "Customer":
                                        return GetUserByEmail(email, new Customer());
                                    default:
                                        return null;
                                }
                            }
                        }
                    }
                }
                return null;
            }
        }

        private bool VerifyPassword(string entered, string hash, string salt)
        {
            string passwordToCheck = BCrypt.Net.BCrypt.HashPassword(entered, salt);
            return passwordToCheck == hash;
        }
    }
}
