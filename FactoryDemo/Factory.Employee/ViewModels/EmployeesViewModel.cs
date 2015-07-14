using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Factory.Infrastructure;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Factory.EmployeeModule.Services;
using Factory.EmployeeModule.Events;
using System.ComponentModel;
using System.Windows.Data;
using Factory.EmployeeModule.Models;

namespace Factory.EmployeeModule.ViewModels
{
    public class EmployeesViewModel : BindableBase
    {
        private IUnityContainer container = null;
        private ILoggerFacade logger = null;
        private IModelService modelService = null;
        private IEventAggregator eventAggregator = null;
        public ICommand SubmitCommand { get; private set; }

       

       
        #region Title

        private string title = "Employees";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion Title

        #region Employee List

        private ICollectionView _EmployeeList;

        public ICollectionView EmployeeVMList
        {
            get
            {
                return _EmployeeList;
            }

            private set
            {
                
                SetProperty(ref _EmployeeList, value);
            }
        }
        #endregion


        private void OnSubmit()
        {
            EmployeeVMList.Filter = obj => ((Employee)obj).EmployeeNumber <2;
        }

        public EmployeesViewModel(IUnityContainer container)
        {
            this.container = container;
            this.logger = this.container.Resolve<ILoggerFacade>();
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this.modelService = this.container.Resolve<IModelService>();
            SubmitCommand = new DelegateCommand(this.OnSubmit);
        }

        public void Initialize()
        {
            var employees = this.modelService.GetAllEmployees().OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
            ObservableCollection<EmployeeViewModel> employeeVM = new ObservableCollection<EmployeeViewModel>();
            
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var vm = this.container.Resolve<EmployeeViewModel>();
                    vm.Initialize(employee);
                    employeeVM.Add(vm);
                    
                }
                EmployeeVMList = new ListCollectionView(employeeVM);
               
                
            }
        }
    }
}
