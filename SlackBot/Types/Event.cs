using System.Runtime.Serialization;
using SlackBot.Contracts.Common;
using System;

namespace SlackBot.Types
{
  [DataContract]
  public class Event
  {
    public string Type { get; set; }
  }
}
