using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees
{
    namespace Emploees
    {
        class Operation
        {
            public string Label { get; set; }
            public OperationTypes Type { get; set; }
            public decimal Amount { get; set; }
            public enum OperationTypes { Add, Edit, ChangeWage };

            public Operation(string label, OperationTypes type, decimal amount = 0)
            {
                Label = label;
                Type = type;
                Amount = amount;
            }

            public string GetOperationInfo()
            {
               switch (Type)
                {
                    case OperationTypes.Add:
                        return "Employee was created";
                        
                    case OperationTypes.Edit:
                        return "Employee was edited";
                        
                    case OperationTypes.ChangeWage:
                        return "Wage value changed to:  " + Amount + "$";
                        
                    default:
                        return "Invalid Type of Operation";
                        
                }
            }
        }

    }

}
