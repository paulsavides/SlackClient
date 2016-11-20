using System;
using SlackBot.Contracts.Common;

namespace SlackBot.Types
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
