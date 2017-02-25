using System;
using System.Collections.Generic;
using Pisces.Slack.Contracts.Context;
using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class SlackContext
  {
    [DataMember(Name = "self")]
    public User Self { get; set; }

    [DataMember(Name = "team")]
    public Team Team { get; set; }

    [DataMember(Name = "channels")]
    public List<Channel> Channels { get; set; }

    [DataMember(Name = "groups")]
    public List<Group> Groups { get; set; }

    [DataMember(Name = "ims")]
    public List<IM> IMs { get; set; }

    [DataMember(Name = "subteams")]
    public Dictionary<string, string[]> Subteams { get; set; }

    [DataMember(Name = "dnd")]
    public DndSettings Dnd { get; set; }

    [DataMember(Name = "users")]
    public List<User> Users { get; set; }

    [DataMember(Name = "bots")]
    public List<User> Bots { get; set; }

    [DataMember(Name = "url")]
    public Uri Url { get; set; }

    [DataMember(Name = "reconnect_uri")]
    public Uri ReconnectUri { get; set; }
  }
}
