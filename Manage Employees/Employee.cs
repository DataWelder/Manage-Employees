using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    namespace Emploees
    {
        class Employee : Person
        {
            public string WorkEmail { get; set; }
            public string Position { get; set; }
            private readonly int Id;
            public static decimal HolidayBonus { get; set; } = 1000;
            public List<Operation> Operations { get; set; } = new List<Operation>();
            public enum ContractTypes { FullTime, PartTime, Contract };

            private Employee (int id, string name, string surname, string workEmail, string position): base(name, surname)
            {
                WorkEmail = workEmail;
                Position = position;
                Id = id;
            }

            public void PrintEmployeeData()
            {
                if (Session.IsLogged())
                {
                    Messages.ColorPrintLine(GetFullName(), ConsoleColor.DarkCyan);
                    Messages.ColorPrintLine("Employee ID:" + Convert.ToString(Id), ConsoleColor.DarkYellow);
                    Messages.ColorPrint("Position: ", ConsoleColor.DarkMagenta);
                    Messages.ColorPrintLine(Position, ConsoleColor.DarkYellow);
                    Messages.ColorPrint("Email: ", ConsoleColor.DarkMagenta);
                    Messages.ColorPrintLine(WorkEmail, ConsoleColor.DarkYellow);

                }
                else
                { 
                    Messages.ColorPrintLine(GetFullName(), ConsoleColor.DarkCyan);
                    Messages.ColorPrint("Position: ", ConsoleColor.DarkMagenta);
                    Messages.ColorPrintLine(Position, ConsoleColor.DarkYellow);
                    Messages.ColorPrint("Email: ", ConsoleColor.DarkMagenta);
                    Messages.ColorPrintLine(WorkEmail, ConsoleColor.DarkYellow);
                }
            }

            public static Employee CreateEmployee(int id,string name, string surname, string workEmail, string positon)
            {
                Employee Employee = new Employee(id,name, surname, workEmail, positon);

                return Employee;
            }

            
        }

    }
    
}
