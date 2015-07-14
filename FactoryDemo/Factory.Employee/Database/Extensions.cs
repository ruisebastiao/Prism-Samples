using Factory.EmployeeModule;
using Factory.EmployeeModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.EmployeeModule.Database
{
    public static class Extensions
    {
        public static Employee AddEmployee(this EmployeeData employeeData, string firstName, string lastName,bool isenabled)
        {
            int customerNumber = employeeData.Any() ? employeeData.Max(m => m.EmployeeNumber) + 1 : EmployeeData.EmployeeNumberSeed;
            Employee employee = new Employee() { EmployeeNumber = customerNumber, FirstName = firstName, LastName = lastName, IsEnabled=isenabled};
            employeeData.Add(employee);
            return employee;
        }

        
    }
}
