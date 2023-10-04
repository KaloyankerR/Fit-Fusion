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

                using(SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateUser(User user) { return false; }
        
        public bool DeleteUser(User user) { return false; }

        public User GetUser(int id) { return new User(); }

        public List<User> GetAllUsers() {  return new List<User>(); }

    }
}
