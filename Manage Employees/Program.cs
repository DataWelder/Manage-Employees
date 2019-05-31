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
        public static ConsoleKeyInfo UserOption;
        public enum ProgramStatus { MainMenu, ClientForm, EmployeeForm, List };
        public static ProgramStatus Status = ProgramStatus.MainMenu;
        public static Session session = new Session();


        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Status = ProgramStatus.MainMenu;
            Console.Clear();
            Messages.DisplayMainMenu(session.IsLogged(), session.LoginAs());
            UserOption = Console.ReadKey();
            Analyze();
        }

        static void LoginForm()
        {
            string login, password;
            Messages.ColorPrint("Login: ", ConsoleColor.Red);
            login = Console.ReadLine();
            Messages.ColorPrint("Password: ", ConsoleColor.Red);
            password = Console.ReadLine();
            Console.Clear();
            Messages.ColorPrintLine("Login: " + login, ConsoleColor.Red);
            Messages.ColorPrintLine("Password: ****", ConsoleColor.Red);
            if(session.Loggin(login, password))
            {
                Messages.ColorPrintLine("You're loged now", ConsoleColor.Green);
                Messages.ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Messages.ColorPrintLine("Login failed", ConsoleColor.DarkRed);
                Messages.ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
                Console.ReadKey();
                MainMenu();
            }
        }

        static void AddEmployeeForm()
        {
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

            Employee tempEmployee = new Employee(name, surname, email, position); 
            
            Messages.ColorPrint("ESC) Cancel ", ConsoleColor.Red);
            Messages.ColorPrint("Enter) Save \n", ConsoleColor.Green);
            UserOption = Console.ReadKey();
            switch (UserOption.Key)
            {
                case ConsoleKey.Enter:
                    Messages.ColorPrintLine("Successfull Saved", ConsoleColor.Green);
                    Messages.ColorPrintLine(tempEmployee.GetEmployeeData(session.IsLogged()), ConsoleColor.DarkYellow);
                    Messages.ColorPrintLine("Press any key to back main menu...", ConsoleColor.DarkGray);
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    Messages.ColorPrintLine("Invalid key - reset add form", ConsoleColor.Red);
                    AddEmployeeForm();
                    break;
            }
            
            
        }

        static void Analyze()
        {
            Console.Clear();
            switch (Status)
            {
                case ProgramStatus.MainMenu:
                    switch (UserOption.Key)
                    {
                        case ConsoleKey.A:
                            Status = ProgramStatus.ClientForm;
                            AddEmployeeForm();
                            break;
                        case ConsoleKey.Escape:
                            Messages.ColorPrintLine("Thanks for using Application written by Sebastian Szypulski vel Sisa 2019", ConsoleColor.DarkCyan);
                            Thread.Sleep(2000);
                            System.Environment.Exit(1);
                            break;
                        case ConsoleKey.L:
                            if (session.IsLogged())
                            {
                                session.Logout();
                                MainMenu();
                            }
                            else
                            {
                                LoginForm();
                            }
                            break;
                        default:
                            Messages.ColorPrintLine("Invalid User choice... restarting application", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            MainMenu();
                            break;
                    }
                    break;
            }
            
        }
    }
}
