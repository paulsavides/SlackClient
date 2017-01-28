using System;
using Pisces.Slack.Contracts.Context;

namespace Pisces.Slack.Contracts.Events
{
  public class MessageEvent : Event
  {
    public Channel Channel { get; set; }
    public User User { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
    public Team Team { get; set; }

  }
}
