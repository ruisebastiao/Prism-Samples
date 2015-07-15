using Factory.EmployeeModule.Events;
using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.Services;
using Factory.Infrastructure;
using Factory.Infrastructure.Events;
using Factory.MVVM;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Factory.EmployeeModule.ViewModels
{
    public class EmployeeViewModel : ViewModelBase<Employee>, IDataErrorInfo
    {
        private IUnityContainer container = null;
        private IModelService modelService = null;
        private IEventAggregator eventAggregator = null;

        private Employee _employee = null;

        public Employee Employee
        {
            get { return _employee; }
            private set
            {
                SetProperty(ref _employee, value);
            }
        }


        public Brush Background
        {
            get
            {
                return IsSelected ? Brushes.Pink : Brushes.LightGreen;
            }
        }

        public EmployeeViewModel(IUnityContainer container)
        {
            this.container = container;
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this.modelService = this.container.Resolve<IModelService>();
        }


        public override string ToString()
        {
            if (Employee!=null)
            {
                return Employee.ToString();
            }
            return null;
        }

        public void Initialize(Employee employee)
        {
            this.Employee = employee;
        }




        /// <summary> 
        ///Get/Set IsEnabled 
        /// </summary> 

     

        public bool IsEnabled
        {

            get
            {
                return Employee.IsEnabled;
            }

            

        }

        

        private bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected && IsEnabled; }
            set {
                SetProperty(ref _isSelected, value, dependentProperties: new string[] { "Background" });
                this.eventAggregator.GetEvent<SetVisibleEmployeeViewModelEvent>().Publish(this); 
            }
        }

        public string Error
        {
            get
            {
                return (Employee as IDataErrorInfo).Error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = (Employee as IDataErrorInfo)[columnName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
    }
}
