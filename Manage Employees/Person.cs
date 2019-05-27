using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    namespace Emploees
    {
        abstract class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public Person(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }

            public string GetFullName()
            {
                return Name + " " + Surname;
            }
        }
    }
}
