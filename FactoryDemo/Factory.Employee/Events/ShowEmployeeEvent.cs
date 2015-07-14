using Factory.EmployeeModule.Models;
using Factory.EmployeeModule.ViewModels;

namespace Factory.EmployeeModule.Events
{
    /// <summary>
    /// Event that requests a Customer
    /// The TPayload of the event represents the Customer which will be passed to the subscriber to the event.
    /// </summary>
    public class ShowEmployeeEvent : Microsoft.Practices.Prism.PubSubEvents.PubSubEvent<Employee> { }
    public class SetVisibleEmployeeViewModelEvent : Microsoft.Practices.Prism.PubSubEvents.PubSubEvent<EmployeeViewModel> { }
    
}
