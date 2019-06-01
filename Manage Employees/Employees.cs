using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    namespace Emploees
    {
        class Employees
        {
            public List<Employee> EmployeesList { get; set; } = new List<Employee>();
            private int Id = 1;


            public Employee this[string name, string surname]
            {
                get
                {
                    foreach (Employee employee in EmployeesList)
                    {
                        if(employee.Name == name && employee.Surname == surname)
                        {
                            return employee;
                        }
                    }
                    return null;
                }
            }

            public bool CreateEmployeeAndAdd (string name, string surname, string workEmail, string position)
            {
                Employee Employee = Employee.CreateEmployee(Id, name, surname, workEmail, position);
                EmployeesList.Add(Employee);
                

                Id++;
                
                return true;
            }

            private void Employee_CreateInfo(string message, ConsoleColor color)
            {
                throw new NotImplementedException();
            }

            public void PrintEmployees()
            {
                if (EmployeesList.Count == 0)
                {
                    Messages.ColorPrintLine("List is empty", ConsoleColor.DarkMagenta);
                }
                foreach (Employee Employee in EmployeesList)
                {
                    Employee.PrintEmployeeData();
                }
            }
        }
    }
    
}
