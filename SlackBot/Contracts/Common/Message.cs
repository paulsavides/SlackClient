using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
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
