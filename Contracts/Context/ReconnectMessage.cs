using System;
using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
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
