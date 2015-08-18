using Factory.Dashboard.ViewModels;
using Factory.Dashboard.Views;
using Factory.Infrastructure;
using Factory.Infrastructure.Events;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Dashboard.Controllers
{
    public class DashboardController
    {
        private IUnityContainer container = null;
        private ILoggerFacade logger = null;
        private IRegionManager regionManager = null;
        private IEventAggregator eventAggregator = null;

        public DashboardController(IUnityContainer container)
        {
            this.container = container;
            this.logger = this.container.Resolve<ILoggerFacade>();
            this.eventAggregator = this.container.Resolve<IEventAggregator>();
            this.regionManager = this.container.Resolve<IRegionManager>();

            /// ***  The controller remains active because event subscriptions(see keepSubscriberReferenceAlive) - but that is it's reason for existence. ***
            this.eventAggregator.GetEvent<ShowApplicationMessageEvent>().Subscribe(ShowApplicationMessage, true);
            this.eventAggregator.GetEvent<HideApplicationMessageEvent>().Subscribe(HideApplicationMessage, true);
        }

        // Using View Injection to show a message.
        private void ShowApplicationMessage(string message)
        {
            var region = this.regionManager.Regions[RegionNames.ModalRegion];
            var viewModel = this.container.Resolve<ApplicationMessageViewModel>();
            viewModel.Initialize(message);
            var view = this.container.Resolve<ApplicationMessageView>();
            if (!region.Views.Contains(view))
            {
                region.Add(view, typeof(ApplicationMessageView).Name);
            }
            view.DataContext = viewModel;
            region.Activate(view);
        }

        private void HideApplicationMessage(object obj)
        {
            var region = this.regionManager.Regions[RegionNames.ModalRegion];
            var view = region.GetView(typeof(ApplicationMessageView).Name);
            if (region.Views.Contains(view))
            {
                region.Remove(view);
            }
        }
    }
}
