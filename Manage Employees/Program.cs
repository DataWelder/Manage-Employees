using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_Employees.Clients;
using Manage_Employees.Emploees;

namespace Manage_Employees
{ 
    class Program
    {
        public static ConsoleKeyInfo UserOption;
        public enum ProgramStatus { MainMenu, ClientForm, EmployeeForm, List };
        public static ProgramStatus Status = ProgramStatus.MainMenu;
        

        static void Main(string[] args)
        {

            MainMenu();
        }

        static void MainMenu()
        {
            Status = ProgramStatus.MainMenu;
            Console.Clear();
            Messages.DisplayMainMenu();
            UserOption = Console.ReadKey();
            Analyze();
        }

        static void AddClientForm()
        {
            string name, surname, email;
            Messages.ColorPrintLine("Add Client", ConsoleColor.Yellow);
            Messages.ColorPrint("Name: ", ConsoleColor.Cyan);
            name = Console.ReadLine();
            Messages.ColorPrint("Surname: ", ConsoleColor.Cyan);
            surname = Console.ReadLine();
            Messages.ColorPrint("E-mail: ", ConsoleColor.Cyan);
            email = Console.ReadLine();

            Client tempClient = new Client(name, surname, email); 
            
            Messages.ColorPrint("ESC) Cancel ", ConsoleColor.Red);
            Messages.ColorPrint("Enter) Save \n", ConsoleColor.Green);
            UserOption = Console.ReadKey();
            switch (UserOption.Key)
            {
                case ConsoleKey.Enter:
                    Messages.ColorPrintLine("Successfull Saved", ConsoleColor.Green);
                    Messages.ColorPrintLine(tempClient.GetClientData(), ConsoleColor.DarkYellow);
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
                    AddClientForm();
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
                        case ConsoleKey.Q:
                            Status = ProgramStatus.ClientForm;
                            AddClientForm();
                            break;
                        case ConsoleKey.Escape:
                            Messages.ColorPrintLine("Thanks for using Application written by Sebastian Szypulski vel Sisa 2019", ConsoleColor.DarkCyan);
                            Thread.Sleep(2000);
                            System.Environment.Exit(1);
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
