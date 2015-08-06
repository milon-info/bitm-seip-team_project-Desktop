using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductManagementApp.BLL;
using ProductManagementApp.MODEL;

namespace ProductManagementApp.UI
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }
        UserLoginManager aUserLoginManager = new UserLoginManager();
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginUserNameTextBox.Text == "" || loginPasswordTextBox.Text == "")
            {
                MessageBox.Show("please enter your username & password");
            }
            else
            {
                string userName = loginUserNameTextBox.Text;
                //passwordTextBox.PasswordChar = '*';
                string password = loginPasswordTextBox.Text;
  
                UserLogin userLogin = aUserLoginManager.GetUserNameAndPassword(userName, password);
                if (userName == userLogin.LoginUserName || password == userLogin.LoginPassword)
                {
                    MessageBox.Show("Login Successfully");
                    MainMenuUI aMainMenuUi = new MainMenuUI();
                    aMainMenuUi.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
        }

    }
}
