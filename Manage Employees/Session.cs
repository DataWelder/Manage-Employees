using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    class Session
    {
        private bool IsLogin = false;
        private string Login = "admin";
        private string Password = "admin";

        public string LoginAs()
        {
            return Login;
        }
        public bool IsLogged()
        {
            return IsLogin;
        }

        public bool Loggin(string login, string password)
        {
            if (login == Login && password == Password)
            {
                IsLogin = true;
                return true;
            }
            else
            {
                IsLogin = false;
                return false;
            }
        }
        public void Logout()
        {
            IsLogin = false;
        }
    }
}
