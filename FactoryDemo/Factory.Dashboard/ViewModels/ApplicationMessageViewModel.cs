using Factory.Infrastructure.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Factory.Dashboard.ViewModels
{
    public class ApplicationMessageViewModel : BindableBase
    {
        private IUnityContainer container = null;
        private IEventAggregator eventAggregator = null;

        #region Message

        private string message = string.Empty;

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                SetProperty(ref message, value);
            }
        }

        #endregion Message

        #region Close Command

        private ICommand closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new DelegateCommand(this.Close);
                }
                return this.closeCommand;
            }

            set
            {
                this.closeCommand = value;
            }
        }

        public void Close()
        {
            this.eventAggregator.GetEvent<HideApplicationMessageEvent>().Publish(null);
        }

        #endregion Close Command

        public ApplicationMessageViewModel(IUnityContainer container)
        {
            this.container = container;
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
        }

        public void Initialize(string message)
        {
            this.Message = message;
        }
    }

}
