using Pisces.Slack.Contracts.Context;
using System;
using System.Collections.Generic;


namespace Pisces.Slack.Client
{
  public static class SlackContext
  {
    public static User Self { get; internal set; }

    public static Team Team { get; internal set; }

    public static List<Channel> Channels { get; internal set; }

    public static List<Group> Groups { get; internal set; }

    public static List<IM> IMs { get; set; }

    public static Dictionary<string, string[]> Subteams { get; internal set; }

    public static DndSettings Dnd { get; internal set; }

    public static List<User> Users { get; internal set; }

    public static List<User> Bots { get; internal set; }

    public static Uri Url { get; set; }

    public static Uri ReconnectUri { get; internal set; }
  }
}

