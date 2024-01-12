using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;
using System.Data.SqlClient;
using Interfaces;
using System.Data;
using System.ComponentModel.Design;
using System.Transactions;
using Models.User.Enums;

namespace DataAcess
{
    public class UserDAO : IUserDAO, IStorageAccess
    {
        private string _connectionString;

        public UserDAO()
        {
            _connectionString = Connection.DbConnection.ConnectionString;
        }

        public UserDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void TestConnectionString()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("An error occurred in the database operation.", ex);
            }
        }

        public void ChangeConnectionString(string newConnectionString)
        {
            _connectionString = newConnectionString;
            TestConnectionString();
        }

        public bool CreateUser(User user)
        {
            try
            {
                if (!DoesEmailExists(user.Email))
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        string query = "";

                        if (user is Staff)
                        {
                            query = "INSERT INTO Staff (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone) " +
                                              "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @Phone);";
                        }
                        else if (user is Owner)
                        {
                            query = "INSERT INTO Owner (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone) " +
                                              "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @Phone);";
                        }
                        else if (user is Customer)
                        {
                            query = "INSERT INTO Customer (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, NutriPoints) " +
                                              "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @NutriPoints);";
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FirstName", user.FirstName);
                            command.Parameters.AddWithValue("@LastName", user.LastName);
                            command.Parameters.AddWithValue("@Email", user.Email);
                            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                            command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
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
                                command.Parameters.AddWithValue("@NutriPoints", ((Customer)user).NutriPoints);
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    throw new DuplicateNameException("User already exists.");
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return true;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                if (DoesEmailExists(user.Email))
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        string query = "";

                        if (user is Staff)
                        {
                            query = "UPDATE Staff SET FirstName = @FirstName, " +
                                              "LastName = @LastName, Email = @Email, " +
                                              "Address = @Address, Phone = @Phone " +
                                              "WHERE Id = @Id;";
                        }
                        else if (user is Owner)
                        {
                            query = "UPDATE Owner SET FirstName = @FirstName, " +
                                              "LastName = @LastName, Email = @Email, " +
                                              "Address = @Address, Phone = @Phone " +
                                              "WHERE Id = @Id;";
                        }
                        else if (user is Customer)
                        {
                            query = "UPDATE Customer SET FirstName = @FirstName, " +
                                              "LastName = @LastName, Email = @Email, " +
                                              "Address = @Address " +
                                              "WHERE Id = @Id;";
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FirstName", user.FirstName);
                            command.Parameters.AddWithValue("@LastName", user.LastName);
                            command.Parameters.AddWithValue("@Email", user.Email);
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

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("User doesn't exist.");
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return true;
        }

        public bool DeleteUser(User user)
        {
            try
            {
                if (DoesEmailExists(user.Email))
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
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
                                    string deleteShoppingCartQuery = "DELETE FROM ShoppingCart WHERE OrderId IN (SELECT Id FROM [Order] WHERE CustomerId = @UserId);";
                                    using (SqlCommand shoppingCartCommand = new SqlCommand(deleteShoppingCartQuery, connection, transaction))
                                    {
                                        shoppingCartCommand.Parameters.AddWithValue("@UserId", user.Id);
                                        shoppingCartCommand.ExecuteNonQuery();
                                    }

                                    string deleteOrderQuery = "DELETE FROM [Order] WHERE CustomerId = @UserId;";
                                    using (SqlCommand orderCommand = new SqlCommand(deleteOrderQuery, connection, transaction))
                                    {
                                        orderCommand.Parameters.AddWithValue("@UserId", user.Id);
                                        orderCommand.ExecuteNonQuery();
                                    }

                                    deleteUserQuery = "DELETE FROM Customer WHERE Id = @Id;";
                                }

                                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Id", user.Id);
                                    command.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("User doesn't exist.");
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return true;
        }

        public User GetUserById(int id, Role role)
        {
            User user;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string getUserQuery = "";
                    string additionalProperty = "";

                    if (role is Role.Staff)
                    {
                        additionalProperty = "Phone";
                    }
                    else if (role is Role.Owner)
                    {
                        additionalProperty = "Phone";
                    }
                    else if (role is Role.Customer)
                    {
                        additionalProperty = "NutriPoints";
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
                                if (role is Role.Staff)
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
                                }
                                else if (role is Role.Owner)
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
                                }
                                else if (role is Role.Customer)
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
                                        nutriPoints: reader.GetInt32(reader.GetOrdinal("NutriPoints"))
                                    );
                                }
                                else
                                {
                                    throw new DataAccessException("An error occurred in the database operation.");
                                }
                            }
                            else
                            {
                                throw new NullReferenceException("User doesn't exist.");
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string getUserQuery = @"
                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone as AdditionalProperty, 'Owner' as Role FROM Owner
                    WHERE Email = @Email

                    UNION ALL

                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone as AdditionalProperty, 'Staff' as Role FROM Staff
                    WHERE Email = @Email

                    UNION ALL

                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, CAST(NutriPoints AS VARCHAR(16)) as AdditionalProperty, 'Customer' as Role FROM Customer
                    WHERE Email = @Email;";


                    using (SqlCommand command = new SqlCommand(getUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string retrievedEmail = reader.GetString(reader.GetOrdinal("Email"));
                                string passwordHash = reader.GetString(reader.GetOrdinal("PasswordHash"));
                                string passwordSalt = reader.GetString(reader.GetOrdinal("PasswordSalt"));
                                string address = reader.GetString(reader.GetOrdinal("Address"));

                                string role = reader.GetString(reader.GetOrdinal("Role"));

                                if (role == "Staff")
                                {
                                    string phone = reader.GetString(reader.GetOrdinal("AdditionalProperty"));
                                    user = new Staff(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, phone);
                                }
                                else if (role == "Owner")
                                {
                                    string phone = reader.GetString(reader.GetOrdinal("AdditionalProperty"));
                                    user = new Owner(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, phone);
                                }
                                else if (role == "Customer")
                                {
                                    string nutriPoints = reader.GetString(reader.GetOrdinal("AdditionalProperty"));
                                    user = new Customer(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, int.Parse(nutriPoints));
                                }
                                else
                                {
                                    throw new NullReferenceException("User doesn't exist.");
                                }
                            }
                            else
                            {
                                throw new NullReferenceException("User doesn't exist.");
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return user;
        }

        public List<User> GetUsers(User role)
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
                        additionalProperty = "NutriPoints";
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
                                        nutriPoints: reader.GetInt32(reader.GetOrdinal("NutriPoints"))
                                    );

                                    users.Add(user);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }

            return users;
        }


        public User AuthenticateUser(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
                                string storedPasswordHash = reader["PasswordHash"].ToString()!;
                                string storedPasswordSalt = reader["PasswordSalt"].ToString()!;
                                string role = reader["Role"].ToString()!;

                                if (VerifyPassword(password, storedPasswordHash, storedPasswordSalt))
                                {
                                    return GetUserByEmail(email);
                                }
                            }
                        }
                    }

                    throw new NullReferenceException("User doesn't exist.");
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }
            catch 
            {            
                throw;
            }
        }

        public bool DoesEmailExists(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
            catch (SqlException)
            {
                throw new DataAccessException("An error occurred in the database operation.");
            }
        }

        public bool ChangePassword(string email, string newPasswordHash, string newPasswordSalt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand updateProductCommand = new SqlCommand("UPDATE Owner SET PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt WHERE Email = @Email " +
                                        "UNION ALL " +
                                        "UPDATE Staff SET PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt " +
                                        "WHERE Email = @Email " +
                                        "UNION ALL " +
                                        "UPDATE Customer SET PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt " +
                                        "WHERE Email = @Email", connection))
                    {
                        updateProductCommand.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                        updateProductCommand.Parameters.AddWithValue("@PasswordSalt", newPasswordSalt);
                        updateProductCommand.Parameters.AddWithValue("@Email", email);

                        updateProductCommand.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool VerifyPassword(string entered, string hash, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(entered, salt) == hash;
        }
    }
}
