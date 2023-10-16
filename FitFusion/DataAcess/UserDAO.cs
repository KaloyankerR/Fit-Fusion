using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;
using System.Data.SqlClient;

namespace DataAcess
{
    public class UserDAO
    {
        private string ConnectionString;

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
                                      "VALUES (@FirstName, @LastName, @Email, @Password, @Address, @Phone);";
                }
                else if (user is Owner)
                {
                    insertUserQuery = "INSERT INTO Owner (FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, Phone) " +
                                      "VALUES (@FirstName, @LastName, @Email, @Password, @Address, @Phone);";
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
                    // Update Staff table
                    updateUserQuery = "UPDATE Staff SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, Phone = @Phone " +
                                      "WHERE Id = @Id;";
                }
                else if (user is Owner)
                {
                    // Update Owners table
                    updateUserQuery = "UPDATE Owners SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, Phone = @Phone " +
                                      "WHERE Id = @Id;";
                }
                else if (user is Customer)
                {
                    // Update Customers table
                    updateUserQuery = "UPDATE Customers SET FirstName = @FirstName, " +
                                      "LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                      "Address = @Address, LoyaltyScore = @LoyaltyScore " +
                                      "WHERE Id = @Id;";
                }

                using (SqlCommand command = new SqlCommand(updateUserQuery, connection))
                {
                    // Set parameters based on the common properties of the User class
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                    command.Parameters.AddWithValue("@Address", user.Address);

                    // Set additional parameters based on the specific properties of the derived classes
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
                    // Delete from Staff table
                    deleteUserQuery = "DELETE FROM Staff WHERE Id = @Id;";
                }
                else if (user is Owner)
                {
                    // Delete from Owners table
                    deleteUserQuery = "DELETE FROM Owners WHERE Id = @Id;";
                }
                else if (user is Customer)
                {
                    // Delete from Customers table
                    deleteUserQuery = "DELETE FROM Customers WHERE Id = @Id;";
                }

                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    // Set parameters based on the common properties of the User class
                    command.Parameters.AddWithValue("@Id", user.Id);

                    command.ExecuteNonQuery();
                }

                return true;
            }
        }

        public User GetUser(int id, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getUserQuery = "";
                string userTypeTable = "";
                string additionalProperty = "";

                if (role == "Staff")
                {
                    userTypeTable = "Staff";
                    additionalProperty = "Phone";
                }
                else if (role == "Owner")
                {
                    userTypeTable = "Owners";
                    additionalProperty = "Phone";
                }
                else if (role == "Customer")
                {
                    userTypeTable = "Customers";
                    additionalProperty = "LoyaltyScore";
                }

                getUserQuery = $"SELECT Id, FirstName, LastName, Email, Password, Address, {additionalProperty} " +
                               $"FROM {userTypeTable} " +
                               $"WHERE Id = @Id;";

                using (SqlCommand command = new SqlCommand(getUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            //user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            //user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                            //user.Email = reader.GetString(reader.GetOrdinal("Email"));
                            //user.Password = reader.GetString(reader.GetOrdinal("Password"));
                            //user.Address = reader.GetString(reader.GetOrdinal("Address"));
                                                        
                            if (role == "Staff")
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
                            else if (role == "Owner")
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
                            else if (role == "Customer")
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

        public List<User> GetUsers(User user)
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string getAllUsersQuery = "";
                string userTypeTable = "";
                string additionalProperty = "";

                if (user is Staff)
                {
                    userTypeTable = "Staff";
                    additionalProperty = "Phone";
                }
                else if (user is Owner)
                {
                    userTypeTable = "Owners";
                    additionalProperty = "Phone";
                }
                else if (user is Customer)
                {
                    userTypeTable = "Customers";
                    additionalProperty = "LoyaltyScore";
                }

                getAllUsersQuery = $"SELECT Id, FirstName, LastName, Email, PasswordHash, PasswordSalt, Address, {additionalProperty} " +
                                          $"FROM {userTypeTable};";

                using (SqlCommand command = new SqlCommand(getAllUsersQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User newUser = null;

                            if (user is Staff staff)
                            {
                                newUser = new Staff(
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
                            else if (user is Owner owner)
                            {
                                newUser = new Owner
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
                            else if (user is Customer customer)
                            {
                                newUser = new Customer
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
                            }

                            users.Add(newUser);
                        }
                    }
                }
            }

            return users;
        }

        //public List<User> GetAllUsers()
        //{
        //    List<User> users = new List<User>();
        //}
    }
}
