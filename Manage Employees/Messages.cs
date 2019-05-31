using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    class Messages
    {
        public static void ColorPrintLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        public static void ColorPrint(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void DisplayMainMenu(bool isLogin, string account)
        {
            ColorPrintLine("Employee Manager", ConsoleColor.White);
            if (isLogin)
            {
                ColorPrintLine("You are login as: " + account, ConsoleColor.DarkYellow);
                ColorPrintLine("L) Logout", ConsoleColor.Green);
                ColorPrintLine("A) Add Employee", ConsoleColor.Green);
            }
            else
            {
                ColorPrintLine("L) Login to system", ConsoleColor.Green);
            }
            ColorPrintLine("E) Display Employee list", ConsoleColor.Green);
            ColorPrintLine("ESC) Exit", ConsoleColor.Red);
        }
        
    }
}
