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
            public static decimal HolidayBonus { get; set; } = 1000;
            public List<Operation> Operations { get; set; } = new List<Operation>();
            public enum ContractTypes { FullTime, PartTime, Contract };

            public Employee (string name, string surname, string workEmail, string position): base(name, surname)
            {
                WorkEmail = workEmail;
                Position = position;
            }

            public string GetEmployeeData(bool isLogin)
            {
                string Data;
                if (isLogin)
                {
                    Data = Name + " " + Surname + "\n" + Position + "\n" + WorkEmail;
                    return Data;
                }
                else
                {
                    Data = Name + " " + Surname + "\n" + Position + "\n" + WorkEmail;
                    return Data;
                }
            }
        }

    }
    
}
