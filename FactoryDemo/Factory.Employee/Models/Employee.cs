using Factory.MVVM;
using System;
using System.ComponentModel;

namespace Factory.EmployeeModule.Models
{
    public class Employee : BindableBaseEx, IDataErrorInfo
    {

        #region Fields

        private String _firstName;
        private String _lastName;
        private int _EmployeeNumber;


        #endregion

        #region Properties

        public String FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value, dependentProperties: new string[] { "FullName" });


            }
        }



        /// <summary> 
        ///Get/Set IsEnabled 
        /// </summary> 

        private bool _IsEnabled;

        public bool IsEnabled
        {

            get
            {
                return _IsEnabled;
            }

            set
            {
                SetProperty(ref _IsEnabled, value);
            }

        }

        

        public String LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value, dependentProperties: new string[] { "FullName" });

            }
        }

        public String FullName
        {
            get { return String.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        public int EmployeeNumber
        {
            get { return _EmployeeNumber; }
            set
            {
                SetProperty(ref _EmployeeNumber, value);
            }
        }

        public override string ToString()
        {
            return FullName;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get {
                string validationResult = null;
                switch (propertyName)
                {
                    case "FirstName":
                        if (String.IsNullOrEmpty(FirstName))
                        {
                            validationResult = "First name can't be empty";
                        }
                        
                        break;
                    case "LastName":
                         if (String.IsNullOrEmpty(LastName))
                        {
                            validationResult = "Last name can't be empty";
                        }
                        
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Employee.");
                }
                return validationResult;
            }
        }
        
        #endregion

        #region Constructors

        public Employee()
        {
            FirstName = "Rui";
            LastName = "Sebastiao";
        }


        public Employee(string firstname, string lastname,bool isenabled)
        {
            FirstName = firstname;
            LastName = lastname;
            IsEnabled = isenabled;
        }

        #endregion
    }
}
