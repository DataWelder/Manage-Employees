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

            public string GetEmployeeData()
            {
                string Data;
                if (Session.IsLogged())
                {
                    Data = Id + ") " + Name + " " + Surname + "\n" + Position + "\n" + WorkEmail;
                    return Data;
                }
                else
                {
                    Data = Id + ") " + Name + " " + Surname + "\n" + Position + "\n" + WorkEmail;
                    return Data;
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
