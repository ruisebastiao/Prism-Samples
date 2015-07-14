using Microsoft.Practices.Prism.PubSubEvents;
namespace Factory.Infrastructure.Events
{
    public class ShowApplicationMessageEvent : PubSubEvent<string> { }
}