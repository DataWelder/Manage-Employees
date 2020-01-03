using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_Employees.Clients;
using Manage_Employees.Emploees;
using Manage_Employees;

namespace Manage_Employees
{ 
    class Program
    {

        public static Employees EmployeesList = new Employees();

        static void Main(string[] args)
        {
            
            Messages.ColorPrintLine("loading program", ConsoleColor.Yellow);
            EmployeesList.CreateEmployeeAndAdd("Tadeusz", "Testowy", "testowy.tadek@tester.com", "tester");
            EmployeesList.CreateEmployeeAndAdd("Janusz", "Kowalski", "janusz@najlepsze-bmw.com.pl", "handlarz");
            Thread.Sleep(2000);
            Router();
        }


        public static void Router()
        {
            Console.Clear();
            var option = Session.UserOption.Key;
            switch (Session.Status)
            {
                case Session.ProgramStatus.MainMenu:
                    switch (option)
                    {
                        case ConsoleKey.A:
                            if (Session.IsLogged())
                            {
                                
                                Messages.AddEmployeeForm();
                            }
                            else
                            {
                                Messages.MainMenu();
                            }
                            break;
                        case ConsoleKey.E:
                            Messages.PrintEmployeesList();
                            break;
                        case ConsoleKey.Escape:
                            Messages.ColorPrintLine("Thanks for using Application", ConsoleColor.DarkCyan);
                            Thread.Sleep(1000);
                            Environment.Exit(1);
                            break;
                        case ConsoleKey.L:
                            if (Session.IsLogged())
                            {
                                Session.Logout();
                                Messages.MainMenu();
                            }
                            else
                            {
                                Messages.LoginForm();
                            }
                            
                            break;
                        default:
                            Messages.MainMenu();
                            break;
                    }
                    break;
                case Session.ProgramStatus.List:
                    switch (option)
                    {
                        case ConsoleKey.S:
                            Messages.SearchForm();
                            break;
                        case ConsoleKey.Escape:
                            Messages.MainMenu();
                            break;
                        default:
                            Messages.PrintEmployeesList();
                            break;
                    }
                    break;
                case Session.ProgramStatus.Search:
                    switch (option)
                    {
                        case ConsoleKey.S:

                            break;
                        case ConsoleKey.Escape:
                            Messages.MainMenu();
                            break;
                        default:
                            Messages.PrintEmployeesList();
                            break;
                    }
                    break;
                default:
                    Messages.MainMenu();
                    break;
            }
            
        }
    }
}
