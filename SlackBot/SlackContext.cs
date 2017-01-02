using System;
using System.Collections.Generic;
using SlackBot.Contracts.Common;
using System.Runtime.Serialization;

namespace SlackBot
{
  [DataContract]
  public class SlackContext
  {
    [DataMember(Name = "self")]
    public static User Self { get; set; }

    [DataMember(Name = "team")]
    public static Team Team { get; set; }

    [DataMember(Name = "channels")]
    public static List<Channel> Channels { get; set; }

    [DataMember(Name = "groups")]
    public static List<Group> Groups { get; set; }

    [DataMember(Name = "ims")]
    public static List<IM> IMs { get; set; }

    [DataMember(Name = "subteams")]
    public static Dictionary<string, string[]> Subteams { get; set; }

    [DataMember(Name = "dnd")]
    public static DndSettings Dnd { get; set; }

    [DataMember(Name = "users")]
    public static List<User> Users { get; set; }

    [DataMember(Name = "bots")]
    public static List<User> Bots { get; set; }

    [DataMember(Name = "url")]
    public static Uri Url { get; set; }

    [DataMember(Name = "reconnect_uri")]
    public static Uri ReconnectUri { get; set; }
  }
}
