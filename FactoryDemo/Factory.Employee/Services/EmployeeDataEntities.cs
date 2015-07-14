
using Factory.EmployeeModule.Database;
namespace Factory.EmployeeModule.Services
{

    public class ModelDataEntities
    {
        public EmployeeData Employees { get; private set; }

       
        public ModelDataEntities()
        {
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            this.Employees = new EmployeeData();
           
            var rs = this.Employees.AddEmployee("Rui", "Sebastião",true);



            var rv = this.Employees.AddEmployee("Renato", "Vale",false);

            var no = this.Employees.AddEmployee("Nune", "Olaio",false);
           
        }
    }
}
