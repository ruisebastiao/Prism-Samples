using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace Factory.EmployeeModule.Services
{
    public class EmployeeDataService : IModelService
    {

         protected ModelDataEntities entities = null;

         public EmployeeDataService()
        {
            this.entities = new ModelDataEntities();
        }

         #region IModelService Members

        public Employee GetEmployee(int employeeNumber)
        {
            Employee employee = null;
            employee = this.entities.Employees.FirstOrDefault(f => f.Number == employeeNumber);
            return employee;
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            foreach (var data in this.entities.Employees)
            {
                employees.Add(data);
            }
            return employees;
        }

       
        #endregion IModelService Members
    }
}
