using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Factory.EmployeeModule;
using Factory.EmployeeModule.Models;

namespace Factory.EmployeeModule.Services
{
    public interface IModelService
    {
        Employee GetEmployee(int employeeNumber);
        ObservableCollection<Employee> GetAllEmployees();
    }
}
