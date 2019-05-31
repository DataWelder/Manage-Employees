using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    namespace Emploees
    {
        public struct Wage
        {
            public decimal Basic { get; set; }
            public decimal Bonus { get; set; }
            public decimal Other { get; set; }

            public Wage(decimal basic, decimal bonus = 0, decimal other = 0)
            {
                Basic = basic;
                Bonus = bonus;
                Other = other;
            }

            public decimal WageTotal()
            {
                return Basic + Bonus + Other;
            }
        }
    }
    
}
