using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_Employees.Emploees;

namespace Manage_Employees
{
    namespace Clients
    {
        class Client : Person
        {
            public string Email {get; set;}

            public Client (string name, string surname, string email): base(name, surname)
            {
                Email = email;
            }

            public string GetClientData()
            {
                return "Name: " + GetFullName() + "\nEmail: " + Email; 
            }
       }
    }
}
