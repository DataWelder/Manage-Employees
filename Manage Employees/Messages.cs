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

        public static void DisplayMainMenu()
        {
            ColorPrintLine("Employee Manager", ConsoleColor.White);
            ColorPrintLine("L) Login to system", ConsoleColor.Green);
            ColorPrintLine("Q) Add Client", ConsoleColor.Green);
            ColorPrintLine("Z) Add Employee", ConsoleColor.Green);
            ColorPrintLine("E) Display Employee list", ConsoleColor.Green);
            ColorPrintLine("C) Display Client list", ConsoleColor.Green);
            ColorPrintLine("ESC) Exit", ConsoleColor.Red);
        }
        
    }
}
