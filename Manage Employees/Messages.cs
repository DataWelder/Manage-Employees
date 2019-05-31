using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Manage_Employees.Emploees;

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
            if (Session.IsLogged())
            {
                ColorPrintLine("You are login as: " + Session.LoginAs(), ConsoleColor.DarkYellow);
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

        public static void LoginForm()
        {
            string login, password;
            ColorPrint("Login: ", ConsoleColor.Red);
            login = Console.ReadLine();
            ColorPrint("Password: ", ConsoleColor.Red);
            password = Console.ReadLine();
            Console.Clear();
            ColorPrintLine("Login: " + login, ConsoleColor.Red);
            ColorPrintLine("Password: ****", ConsoleColor.Red);
            if (Session.Loggin(login, password))
            {
                ColorPrintLine("You're loged now", ConsoleColor.Green);
            }
            else
            {
                ColorPrintLine("Login failed", ConsoleColor.DarkRed);
            }
            Thread.Sleep(1500);
            Session.Status = Session.ProgramStatus.MainMenu;
            Program.MainMenu();
        }

        public static void AddEmployeeForm()
        {
            Console.Clear();
            string name, surname, email, position;
            Messages.ColorPrintLine("Add Employee", ConsoleColor.Yellow);
            Messages.ColorPrint("Name: ", ConsoleColor.Cyan);
            name = Console.ReadLine();
            Messages.ColorPrint("Surname: ", ConsoleColor.Cyan);
            surname = Console.ReadLine();
            Messages.ColorPrint("Position: ", ConsoleColor.Cyan);
            position = Console.ReadLine();
            Messages.ColorPrint("Work E-mail: ", ConsoleColor.Cyan);
            email = Console.ReadLine();

            Messages.ColorPrint("ESC) Cancel ", ConsoleColor.Red);
            Messages.ColorPrint("Enter) Save \n", ConsoleColor.Green);
            Session.ReadOption();
            switch (Session.UserOption.Key)
            {
                case ConsoleKey.Enter:
                    if(Program.EmployeesList.CreateEmployee(name, surname, email, position))
                    {
                        Messages.ColorPrintLine("Successfull Saved", ConsoleColor.Green);
                        Messages.ColorPrintLine("Press any key to back main menu... or press N do add next Employee", ConsoleColor.DarkYellow);
                        Session.ReadOption();
                        if (Session.UserOption.Key == ConsoleKey.N)
                        {
                            AddEmployeeForm();
                        }
                    }
                    else
                    {
                        Messages.ColorPrintLine("Save Failed", ConsoleColor.Green);
                        Messages.ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
                    }
                    
                    Console.ReadKey();
                    Program.MainMenu();
                    break;
                case ConsoleKey.Escape:
                    Program.MainMenu();
                    break;
                default:
                    Console.Clear();
                    Messages.ColorPrintLine("Invalid key - reset form", ConsoleColor.Red);
                    AddEmployeeForm();
                    break;
            }


        }
    }
}
