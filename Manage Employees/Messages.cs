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

        public static void MainMenu()
        {
            Console.Clear();
            Session.ChangeStatus(Session.ProgramStatus.MainMenu);
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
            Session.UserOption = Console.ReadKey();
            Program.Router();
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
                Console.Beep();
            }
            else
            {
                ColorPrintLine("Login failed", ConsoleColor.DarkRed);
            }
            Thread.Sleep(1500);
            Session.Status = Session.ProgramStatus.MainMenu;
            MainMenu();
        }

        public static void AddEmployeeForm()
        {
            Session.ChangeStatus(Session.ProgramStatus.Form);
            Console.Clear();
            string name, surname, email, position;
            ColorPrintLine("Add Employee", ConsoleColor.Yellow);
            ColorPrint("Name: ", ConsoleColor.Cyan);
            name = Console.ReadLine();
            ColorPrint("Surname: ", ConsoleColor.Cyan);
            surname = Console.ReadLine();
            ColorPrint("Position: ", ConsoleColor.Cyan);
            position = Console.ReadLine();
            ColorPrint("Work E-mail: ", ConsoleColor.Cyan);
            email = Console.ReadLine();

            ColorPrint("ESC) Cancel ", ConsoleColor.Red);
            ColorPrint("Enter) Save \n", ConsoleColor.Green);
            Session.ReadOption();
            switch (Session.UserOption.Key)
            {
                case ConsoleKey.Enter:
                    if(Program.EmployeesList.CreateEmployeeAndAdd(name, surname, email, position))
                    {
                        ColorPrintLine("Press any key to back main menu... or press N do add next Employee", ConsoleColor.DarkYellow);
                        Session.ReadOption();
                        if (Session.UserOption.Key == ConsoleKey.N)
                        {
                            AddEmployeeForm();
                        }
                    }
                    else
                    {
                        ColorPrintLine("Created Failed", ConsoleColor.Green);
                        ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
                        Console.ReadKey();
                    }
                    MainMenu();
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    ColorPrintLine("Invalid key - reset form", ConsoleColor.Red);
                    AddEmployeeForm();
                    break;
            }


        }

        public static void PrintEmployeesList()
        {
            Console.Clear();
            Session.ChangeStatus(Session.ProgramStatus.List);
            Program.EmployeesList.PrintEmployees();
            ColorPrintLine("S) Search by Name and Surname", ConsoleColor.Yellow);
            if (Session.IsLogged())
            {
                
            }
            ColorPrintLine("ESC) Main Menu", ConsoleColor.Red);
            Session.ReadOption();
            Program.Router();
        }

        public static void SearchForm()
        {
            Session.ChangeStatus(Session.ProgramStatus.Search);
            string name, surname;
            ColorPrint("Name: ", ConsoleColor.Cyan);
            name = Console.ReadLine();
            ColorPrint("Surname: ", ConsoleColor.Cyan);
            surname = Console.ReadLine();
            Employee searchedEmployee = Program.EmployeesList[name, surname];
            if (searchedEmployee == null)
            {
                ColorPrintLine("Not Employee Found", ConsoleColor.DarkRed);
            }
            else
            {
                searchedEmployee.PrintEmployeeData();
            }
            ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
            Console.ReadKey();
            MainMenu();
        }
    }
}
