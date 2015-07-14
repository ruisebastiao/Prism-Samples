using Factory.EmployeeModule.Controllers;
using Factory.EmployeeModule.Interfaces;
using Factory.EmployeeModule.Views;
using Factory.Infrastructure;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Factory.Model
{
    public class EmployeesModule : IModule
        {
            private IUnityContainer container = null;
            private EmployeesController controller = null;

            public EmployeesModule(IUnityContainer container)
            {
                this.container = container;
            }

            #region IModule Members

            /// <summary>
            /// Notifies the module that it has be initialized.
            /// </summary>
            /// <remarks>
            /// We are using the Initialize method to do two things:
            /// 1. Create a controller that will listen for any events to which this module wants to respond.
            /// 2. Register a view with the BodyRegion of the Shell.
            /// </remarks>
            public void Initialize()
            {
                /// Creating a controller for the module
                /// We are using the IOC container to get us a new CustomerController.
                this.controller = this.container.Resolve<EmployeesController>();

                /// Using View Discovery
                /// 1. Get a reference to the RegionManager from the IOC Container.
                /// 2. Register the desired view(UserControl) with the region.
                /// See the code-behind of CustomerListView for setting the DataContext = ViewModel.
                var regionManager = this.container.Resolve<IRegionManager>();
                regionManager.RegisterViewWithRegion(RegionNames.EmployeesRegion, typeof(EmployeesView));
                

#if DEBUG
                var logger = this.container.Resolve<ILoggerFacade>();
                logger.Log("Employees Module Initialized", Category.Debug, Priority.None);
#endif
            }

            #endregion IModule Members
        }
}
