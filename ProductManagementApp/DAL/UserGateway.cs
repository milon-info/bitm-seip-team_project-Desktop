using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.DAL
{
    public class UserGateway
    {
        public static string databaseConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        
        public int AddUser(User aUser)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "INSERT INTO tbl_user VALUES('" + aUser.FullName + "','" + aUser.Email + "','" +
                           aUser.MobileNo + "','" + aUser.UserName + "','" + aUser.Password + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
        public User GetUserName(string userName)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_user WHERE user_name = '" + userName + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            User user = null;

            while (reader.Read())
            {
                if (user == null)
                {
                    user = new User();
                }
                user.UserName = reader["user_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return user;
        }

        public static List<User> GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_user";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<User> userList = new List<User>();

            while (reader.Read())
            {
                User user = new User();
                //user.Id = int.Parse(reader["id"].ToString());
                user.UserName = reader["user_name"].ToString();
                user.Password = reader["password"].ToString();
                user.Email = reader["email"].ToString();

                userList.Add(user);
            }
            reader.Close();
            connection.Close();

            return userList;
        }
    }
}
