using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Factory.EmployeeModule.Extensions;

namespace Factory.EmployeeModule.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
      
        public EmployeeView()
        {
            InitializeComponent();
          
        }

        private void employeecontrol_GotFocus(object sender, RoutedEventArgs e)
        {
            this.BringToFront();
        }

        private void employeecontrol_GotMouseCapture(object sender, MouseEventArgs e)
        {
            this.BringToFront();
        }

        private void employeecontrol_GotTouchCapture(object sender, TouchEventArgs e)
        {
            this.BringToFront();
        }

      

    }

    public class BooleanOrConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                if ((bool)value == true)
                {
                    return true;
                }
            }
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
