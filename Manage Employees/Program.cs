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
            EmployeesList.CreateEmployeeAndAdd("Tadeusz", "Testowy", "testowy.tadek@tester.com", "tester");
            EmployeesList.CreateEmployeeAndAdd("Janusz", "Handlarz", "janusz@najlepsze-bmw.com.pl", "najlepszy handlarz");
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Session.Status = Session.ProgramStatus.MainMenu;
            Messages.DisplayMainMenu();
            Session.UserOption = Console.ReadKey();
            Analyze();
        }

        public static void Analyze()
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
                                Session.Status = Session.ProgramStatus.Form;
                                Messages.AddEmployeeForm();
                            }
                            else
                            {
                                MainMenu();
                            }
                            break;
                        case ConsoleKey.E:
                            Session.Status = Session.ProgramStatus.List;
                            EmployeesList.PrintEmployees();
                            Messages.ListMessages();
                            Session.ReadOption();
                            Analyze();
                            break;
                        case ConsoleKey.Escape:
                            Messages.ColorPrintLine("Thanks for using Application written by Sebastian Szypulski vel Sisa 2019", ConsoleColor.DarkCyan);
                            Thread.Sleep(2000);
                            Environment.Exit(1);
                            break;
                        case ConsoleKey.L:
                            if (Session.IsLogged())
                            {
                                Session.Logout();
                                MainMenu();
                            }
                            else
                            {
                                Messages.LoginForm();
                            }
                            
                            break;
                        default:
                            MainMenu();
                            break;
                    }
                    break;
                case Session.ProgramStatus.List:
                    switch (option)
                    {
                        case ConsoleKey.S:

                            break;
                        case ConsoleKey.Escape;
                            MainMenu();
                            break;
                        default:
                            EmployeesList.PrintEmployees();
                            break;
                    }
                    break;
                default:
                    MainMenu();
                    break;
            }
            
        }
    }
}
