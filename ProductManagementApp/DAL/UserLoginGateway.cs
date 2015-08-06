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
    public class UserLoginGateway
    {
        public string databaseConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public UserLogin GetUserNameAndPassword(string userName, string password)
        {
            SqlConnection connection = new SqlConnection(databaseConString);
            string query = "SELECT * FROM tbl_user WHERE user_name = '" + userName + "' AND password = '" +
                           password + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            UserLogin aUserLogin = new UserLogin();

            while (reader.Read())
            {
                aUserLogin.LoginUserName = reader["user_name"].ToString();
                aUserLogin.LoginPassword = reader["password"].ToString();
            }
            reader.Close();
            connection.Close();

            return aUserLogin; 
        }
    }
}
