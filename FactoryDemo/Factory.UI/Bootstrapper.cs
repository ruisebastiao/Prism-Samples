﻿using Factory.Dashboard;
using Factory.EmployeeModule.Services;
using Factory.Infrastructure.Adapters;
using Factory.Logging;
using Factory.Model;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Factory.UI
{

    /// <summary>
    /// A subclass of Unity's version of the Bootstrapper.
    /// The steps below are presented in order of how they are executed.
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        #region Method Overrides

        /// <summary>
        /// Create the Logger used by the bootstrapper. Added automatically to the container. This will be available via the container within the entire application.
        /// *Note: Prism will automatically log these bootstrapper steps to the log when in debug mode.
        /// </summary>
        /// <returns>A new logger.</returns>
        protected override ILoggerFacade CreateLogger()
        {
            return new Logger();
        }

        /// <summary>
        /// Populates the Module Catalog.
        /// </summary>
        /// <returns>A new Module Catalog.</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            /// The most direct way to create a module catalog is to create it in code.
            var moduleCatalog = new ModuleCatalog();

            //// Add the Dashboard Module to the catalog using code.
            //Type dashboardModule = typeof(DashboardModule);
            //moduleCatalog.AddModule(new ModuleInfo() { ModuleName = dashboardModule.Name, ModuleType = dashboardModule.AssemblyQualifiedName });

            // Add the Customers Module to the catalog using code.
            Type employeeModule = typeof(EmployeesModule);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleName = employeeModule.Name, ModuleType = employeeModule.AssemblyQualifiedName });

            return moduleCatalog;
        }

        /// <summary>
        /// Configures the UnityContainer/>.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            /// Registering  a service with the Container for later retrieval.
            RegisterTypeIfMissing(typeof(IModelService), typeof(EmployeeDataService), true);
        }

        /// <summary>
        /// Creates the Shell and uses it so set the UnityBootstrapper Shell property.
        /// </summary>
        /// <returns>A new Shell window.</returns>
        protected override DependencyObject CreateShell()
        {
            /// I have to tell this method which WPF Window is the Shell.
            /// Here, it is the ShellWindow.xaml that we created in the project.
            return new ShellWindow();
        }

        /// <summary>
        /// Displays the Shell window to the user.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            /// Assign the Shell which is a Window to the App's Main Window, and show it.
            /// Note that both share the base type DependencyObject.
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }


        protected override Microsoft.Practices.Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            //mappings.RegisterMapping(typeof(DockPanel), Container.TryResolve<DockPanelRegionAdapter>());
            mappings.RegisterMapping(typeof(DockingManager), new DockingManagerRegionAdapter(Container.TryResolve<RegionBehaviorFactory>()));
          

            return mappings;
        }

        #endregion Method Overrides
    }

}
