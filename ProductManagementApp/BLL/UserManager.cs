using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.DAL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.BLL
{
    public class UserManager
    {
        UserGateway aUserGateway = new UserGateway();
        public bool IsUserExists(string userName)
        {
            User IsUserName = aUserGateway.GetUserName(userName);
            if (IsUserName != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string AddUser(User aUser)
        {
            bool checkUser = IsUserExists(aUser.UserName);
            if (checkUser)
            {
                return "User Allready Exists!";
            }
            if (aUserGateway.AddUser(aUser) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Could Not Added!";
            }
        }
        public static List<User> GetAllUsers()
        {
            return UserGateway.GetAllUsers();
        }

    }
}
