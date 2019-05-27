using System;
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
        static void Main(string[] args)
        {
            Client newClient = new Client("Jan", "Kowalski", "jan@onet.pl");
            Messages.ColorPrint(newClient.GetClientData(),ConsoleColor.Blue);
            Console.ReadKey();
        }
    }
}
