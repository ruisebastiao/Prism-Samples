
using Factory.EmployeeModule.Events;
using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.Services;
using Factory.MVVM.Bases;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using System.Windows;
using System.Reactive;
using System.Reactive.Linq;
using System;
using System.Windows.Input;
using Factory.MVVM.Rules;

namespace Factory.EmployeeModule.ViewModels
{
    public class EmployeeViewModel : ValidatableBindableBase<EmployeeViewModel>
    {
        private IUnityContainer container = null;
        private IModelService modelService = null;
        private IEventAggregator eventAggregator = null;

        public ICommand SaveCommand { get; private set; }

        private IDisposable employeeChangedSubscription;

        private Employee _employee = null;

        public Employee Employee
        {
            get { return _employee; }
            private set
            {

                if (this.employeeChangedSubscription != null)
                {
                    this.employeeChangedSubscription.Dispose();
                    this.employeeChangedSubscription = null;
                }
                SetProperty(ref _employee, value);
                employeeChangedSubscription = _employee.WhenErrorsChanged.Subscribe(ModelHasErrors);
                
            }
        }



        private void ModelHasErrors(string paramName)
        {
            IsValid = Employee.HasErrors == false;
        }

        

        public EmployeeViewModel(IUnityContainer container)
        {
          
            this.container = container;
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this.modelService = this.container.Resolve<IModelService>();
            EnableDraggingCommand = new DelegateCommand(EnableDragging, CanEnableDragging);
            SaveCommand = new DelegateCommand(this.OnSave, this.CanSave).ObservesCanExecute((o) => IsValid);
            

          
        }

        private void OnSave()
        {
            
        }

        private bool CanSave()
        {

            return IsValid;
        }





        /// <summary> 
        ///Get/Set IsValid 
        /// </summary> 

        private bool _IsValid;

        public bool IsValid
        {

            get
            {
                return _IsValid;
            }

            private set
            {
                SetProperty(ref _IsValid, value);
            }

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

        public DelegateCommand EnableDraggingCommand { get; private set;  }

        private void EnableDragging()
        {
            IsDraggingEnabled = !IsDraggingEnabled;
        }

        private bool CanEnableDragging()
        {
            return true;
        }

        private Visibility _IsVisibleActive = Visibility.Hidden;

        public Visibility IsVisibleActive
        {
            get { return _IsVisibleActive; }
            private set {
                SetProperty(ref _IsVisibleActive, value);
            }
        }

        /// <summary> 
        ///Get/Set IsDraggingEnabled 
        /// </summary> 

        private bool _IsDraggingEnabled;

        public bool IsDraggingEnabled
        {

            get
            {
                return _IsDraggingEnabled;
            }

            set
            {
                SetProperty(ref _IsDraggingEnabled, value);
                if (value)
                {
                    IsVisibleActive = Visibility.Visible;
                }
                else
                {
                    IsVisibleActive = Visibility.Hidden;
                }
            }

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
                SetPropertyDependent(ref _isSelected, value, dependentProperties: new string[] { "Background" });
                this.eventAggregator.GetEvent<SetVisibleEmployeeViewModelEvent>().Publish(this); 
            }
        }

       
    }
}
