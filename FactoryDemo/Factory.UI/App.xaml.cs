using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Factory.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /// Unity Bootstrapper - replaces Window.Show with a new approach.
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
