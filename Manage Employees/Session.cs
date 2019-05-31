using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    class Session
    {
        private static bool IsLogin = false;
        private static string Login = "admin";
        private static string Password = "admin";
        public static ConsoleKeyInfo UserOption;
        public enum ProgramStatus { MainMenu, Form, List };
        public static ProgramStatus Status = ProgramStatus.MainMenu;

        public static string LoginAs()
        {
            return Login;
        }
        public static bool IsLogged()
        {
            return IsLogin;
        }

        public static bool Loggin(string login, string password)
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
        public static void Logout()
        {
            IsLogin = false;
        }
        public static void ReadOption()
        {
            Session.UserOption = Console.ReadKey();
        }
    }
}
