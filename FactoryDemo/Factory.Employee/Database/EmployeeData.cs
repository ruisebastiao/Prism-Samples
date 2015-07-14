using Factory.EmployeeModule;
using Factory.EmployeeModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.EmployeeModule.Database
{
    public class EmployeeData : List<Employee>
    {
        public const int EmployeeNumberSeed = 1;
    }
}
