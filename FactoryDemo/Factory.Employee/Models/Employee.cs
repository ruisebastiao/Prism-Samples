using Factory.MVVM;
using Factory.MVVM.Bases;
using System;
using System.ComponentModel;

namespace Factory.EmployeeModule.Models
{
    public class Employee :BindableBaseEx
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

        public int Number
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

       
        
        #endregion

        #region Constructors

        public Employee()
        {
            FirstName = "Rui";
            LastName = "Sebastiao";
           
        }


        public Employee(string firstname, string lastname,bool isenabled):this()
        {
            FirstName = firstname;
            LastName = lastname;
            IsEnabled = isenabled;
        }

        #endregion
    }
}
