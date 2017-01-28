using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class Message
  {
    [DataMember (Name = "type")]
    public string Type { get; set; }

    [DataMember (Name = "user")]
    public string User { get; set; }

    [DataMember (Name = "text")]
    public string Text { get; set; }

    [DataMember (Name = "ts")]
    public string TimeStamp { get; set; }
  }
}
