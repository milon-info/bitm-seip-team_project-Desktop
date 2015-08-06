using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementApp.DAL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.BLL
{
    public class UserLoginManager
    {
        UserLoginGateway aUserLoginGateway = new UserLoginGateway();
        public UserLogin GetUserNameAndPassword(string userName, string password)
        {
            return aUserLoginGateway.GetUserNameAndPassword(userName,password);
        }
    }
}
