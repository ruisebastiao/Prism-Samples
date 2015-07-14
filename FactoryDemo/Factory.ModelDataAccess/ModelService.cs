using Factory.EmployeeModule;
using Factory.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.ModelDataAccess
{
    public class ModelService : IModelService
    {
        private ModelDataEntities entities = null;

        public ModelService()
        {
            this.entities = new ModelDataEntities();
        }

    }
}
