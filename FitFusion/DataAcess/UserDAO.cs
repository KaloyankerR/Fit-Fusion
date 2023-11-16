﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;
using System.Data.SqlClient;
using Interfaces;

namespace DataAcess
{
    public class UserDAO : IUser
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
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                        query = "INSERT INTO Customer (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, LoyaltyScore) " +
                                          "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Address, @LoyaltyScore);";
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
                            command.Parameters.AddWithValue("@LoyaltyScore", ((Customer)user).NutriPoints);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                                          "Address = @Address, LoyaltyScore = @LoyaltyScore " +
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
                        else if (user is Customer)
                        {
                            command.Parameters.AddWithValue("@LoyaltyScore", ((Customer)user).NutriPoints);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
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
                }

                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public User GetUserById(int id, User role)
        {
            try
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
            catch
            {
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getUserQuery = @"
                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone as AdditionalProperty, 'Owner' as Role FROM Owner
                    WHERE Email = @Email

                    UNION ALL

                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone as AdditionalProperty, 'Staff' as Role FROM Staff
                    WHERE Email = @Email

                    UNION ALL

                    SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, CAST(LoyaltyScore AS VARCHAR(16)) as AdditionalProperty, 'Customer' as Role FROM Customer
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
                                return new Staff(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, phone);
                            }
                            else if (role == "Owner")
                            {
                                string phone = reader.GetString(reader.GetOrdinal("AdditionalProperty"));
                                return new Owner(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, phone);
                            }
                            else if (role == "Customer")
                            {
                                string loyaltyScore = reader.GetString(reader.GetOrdinal("AdditionalProperty"));
                                return new Customer(id, firstName, lastName, retrievedEmail, passwordHash, passwordSalt, address, int.Parse(loyaltyScore));
                            }
                        }
                    }
                }

                return null;
            }
        }


        //public User GetUserByEmail(string email, User role)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string getUserQuery = "";
        //        string additionalProperty = "";

        //        if (role is Staff)
        //        {
        //            additionalProperty = "Phone";
        //        }
        //        else if (role is Owner)
        //        {
        //            additionalProperty = "Phone";
        //        }
        //        else if (role is Customer)
        //        {
        //            additionalProperty = "LoyaltyScore";
        //        }

        //        getUserQuery = $"SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, {additionalProperty} " +
        //                       $"FROM {role.GetType().Name} " +
        //                       $"WHERE Email = @Email;";

        //        using (SqlCommand command = new SqlCommand(getUserQuery, connection))
        //        {
        //            command.Parameters.AddWithValue("@Email", email);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    if (role is Staff)
        //                    {
        //                        Staff staff = new Staff
        //                        (
        //                            id: reader.GetInt32(reader.GetOrdinal("Id")),
        //                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
        //                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
        //                            email: reader.GetString(reader.GetOrdinal("Email")),
        //                            passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
        //                            passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
        //                            address: reader.GetString(reader.GetOrdinal("Address")),
        //                            phone: reader.GetString(reader.GetOrdinal("Phone"))
        //                        );

        //                        return staff;
        //                    }
        //                    else if (role is Owner)
        //                    {
        //                        Owner owner = new Owner
        //                        (
        //                            id: reader.GetInt32(reader.GetOrdinal("Id")),
        //                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
        //                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
        //                            email: reader.GetString(reader.GetOrdinal("Email")),
        //                            passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
        //                            passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
        //                            address: reader.GetString(reader.GetOrdinal("Address")),
        //                            phone: reader.GetString(reader.GetOrdinal("Phone"))
        //                        );

        //                        return owner;
        //                    }
        //                    else if (role is Customer)
        //                    {
        //                        Customer customer = new Customer
        //                        (
        //                            id: reader.GetInt32(reader.GetOrdinal("Id")),
        //                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
        //                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
        //                            email: reader.GetString(reader.GetOrdinal("Email")),
        //                            passwordHash: reader.GetString(reader.GetOrdinal("PasswordHash")),
        //                            passwordSalt: reader.GetString(reader.GetOrdinal("PasswordSalt")),
        //                            address: reader.GetString(reader.GetOrdinal("Address")),
        //                            loyaltyScore: reader.GetInt32(reader.GetOrdinal("LoyaltyScore"))
        //                        );

        //                        return customer;
        //                    }
        //                }
        //            }
        //        }

        //        return null;
        //    }
        //}

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
                                return GetUserByEmail(email);

                                //switch (role)
                                //{
                                //    case "Staff":
                                //        return GetUserByEmail(email, new Staff());
                                //    case "Owner":
                                //        return GetUserByEmail(email, new Owner());
                                //    case "Customer":
                                //        return GetUserByEmail(email, new Customer());
                                //    default:
                                //        return null;
                                //}
                            }
                        }
                    }
                }
                return null;
            }
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

        public bool ChangePassword(string email, string newPasswordHash, string newPasswordSalt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            catch (Exception ex)
            {
                throw new Exception("Failed to update user's password.", ex);
                // return fale;
            }
        }

        private bool VerifyPassword(string entered, string hash, string salt)
        {
            string passwordToCheck = BCrypt.Net.BCrypt.HashPassword(entered, salt);
            return passwordToCheck == hash;
        }
    
    }
}
