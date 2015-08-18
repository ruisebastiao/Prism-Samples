using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Factory.MVVM.Bases
{
    public abstract class NotifyBase : BindableBase, IDisposable
    {

      

        #region Protected Methods

        protected virtual bool SetPropertyDependent<T>(ref T storage, T value,
           [CallerMemberName] String propertyName = null,
           string[] dependentProperties = null)
        {

            var result = SetProperty<T>(storage:ref storage,value:value,propertyName:propertyName);

            if (dependentProperties != null)
            {
                foreach (String item in dependentProperties)
                {
                    OnPropertyChanged(item);
                }
            }


            return true;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose() {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose() {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~NotifyBase()
        {
            string msg = string.Format("{0} ({1}) Finalized", this.GetType().Name, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members


       
    }
}
