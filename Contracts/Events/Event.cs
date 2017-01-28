using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Events
{
  [DataContract]
  public class Event
  {
    public string Type { get; set; }
  }
}
