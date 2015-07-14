using Factory.EmployeeModule.Events;
using Factory.EmployeeModule.Interfaces;
using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.ViewModels;
using Factory.EmployeeModule.Views;
using Factory.Infrastructure;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.EmployeeModule.Controllers
{
    class EmployeesController
    {
        private IUnityContainer container = null;
        private ILoggerFacade logger = null;
        private IRegionManager _regionManager = null;
        private IEventAggregator eventAggregator = null;

        public EmployeesController(IUnityContainer container)
        {
            this.container = container;
            this.logger = this.container.Resolve<ILoggerFacade>();
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this._regionManager = this.container.Resolve<IRegionManager>();

            /// ***  The controller remains active because event subscriptions(see keepSubscriberReferenceAlive) - but that is it's reason for existence. ***
            eventAggregator.GetEvent<ShowEmployeeEvent>().Subscribe(ShowEmployee, true);
            eventAggregator.GetEvent<SetVisibleEmployeeViewModelEvent>().Subscribe(SetVisibleEmployeeViewModel, true);
            
        
        }

        // Using View Injection to show the EmployeeView.
        private void ShowEmployee(Employee employee)
        {


            var region = this._regionManager.Regions[RegionNames.SelectedEmployeeRegion];
            var viewModel = this.container.Resolve<EmployeeViewModel>();
            viewModel.Initialize(employee);

            //

            EmployeeView view = region.GetView(viewModel.Employee.FirstName) as EmployeeView;


            if (view == null)
            {
                view = this.container.Resolve<EmployeeView>();
                region.Add(view, viewModel.Employee.FirstName);
                view.DataContext = viewModel;
            }

            
            region.Activate(view);

           
           
        }

        // Show View Model 
        private void SetVisibleEmployeeViewModel(EmployeeViewModel viewModel)
        {

            if (viewModel == null) return;

            var region = this._regionManager.Regions[RegionNames.SelectedEmployeeRegion];
            
            EmployeeView view = region.GetView(viewModel.Employee.FirstName) as EmployeeView;

           
            if (view == null && viewModel.IsSelected)
            {
                view = this.container.Resolve<EmployeeView>();
                region.Add(view, viewModel.Employee.FirstName);
                view.DataContext = viewModel;
            }

            if (viewModel.IsSelected)
            {
                region.Activate(view);
            }
            else if(view!=null)
            {
                region.Remove(view);
            }
            
           
           
        }

      
    }
}
