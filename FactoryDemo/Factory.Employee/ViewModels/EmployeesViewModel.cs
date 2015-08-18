using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.Services;
using Factory.MVVM;
using Factory.MVVM.Bases;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Factory.EmployeeModule.ViewModels
{
    public class EmployeesViewModel : ViewModelBase<EmployeesViewModel>
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
            EmployeeVMList.Filter = obj => ((EmployeeViewModel)obj).Employee.Number >10;
        }

        public EmployeesViewModel(IUnityContainer container)
        {
           
            this.container = container;
            this.logger = this.container.Resolve<ILoggerFacade>();
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this.modelService = this.container.Resolve<IModelService>();
            SubmitCommand = new DelegateCommand(this.OnSubmit,this.CanSubmit);
          

        }

        public bool CanSubmit()
        {
            var result = EmployeeVMList.SourceCollection.OfType<EmployeeViewModel>().All(vm => vm.HasErrors)==false;

            return result;
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
                EmployeeVMList.CollectionChanged += EmployeeVMList_CollectionChanged;
                
                //EmployeeVMList.Filter = o => ((EmployeeViewModel)o).Employee.EmployeeNumber < 10;
                //// Rules.Add(new DelegateRule<EmployeesViewModel>(
                ////"EmployeeVMList",
                ////"Teste",
                ////x =>EmployeeVMList.SourceCollection.ToList());

            }
        }

        void EmployeeVMList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action== System.Collections.Specialized.NotifyCollectionChangedAction.Add )
            {
                 
            }
        }
    }
}
