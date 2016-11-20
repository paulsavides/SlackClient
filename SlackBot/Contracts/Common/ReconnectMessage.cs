using System;
using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class ReconnectMessage
  {
    [DataMember (Name = "type")]
    public string Type { get; set; }

    [DataMember (Name = "url")]
    public Uri Url { get; set; }
  }
}
