using Factory.EmployeeModule.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Factory.EmployeeModule.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    
    [ViewSortHint("02")] 
    public partial class EmployeesView : UserControl
    {
        public EmployeesView(EmployeesViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Initialize();
            this.DataContext = viewModel;// Setting the DataContext of the view to the ViewModel will enable databinding between them.
        }

        private void EmployeesListView_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
