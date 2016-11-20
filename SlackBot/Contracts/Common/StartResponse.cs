using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class StartResponse
  {
    [DataMember(Name = "ok")]
    public bool OK { get; set; }

    [DataMember(Name = "self")]
    public User Self { get; set; }

    [DataMember(Name = "team")]
    public Team Team { get; set; }

    [DataMember(Name = "latest_event_ts")]
    public string LatestEventTimestamp { get; set; }

    [DataMember(Name = "channels")]
    public List<Channel> Channels { get; set; }

    [DataMember(Name = "groups")]
    public List<Group> Groups { get; set; }

    [DataMember(Name = "ims")]
    public List<IM> IMs { get; set; }

    [DataMember(Name = "cache_ts")]
    public int CacheTimestamp { get; set; }

    [DataMember(Name = "subteams")]
    public Dictionary<string, string[]> Subteams { get; set; }

    [DataMember(Name = "dnd")]
    public DndSettings Dnd { get; set; }

    [DataMember(Name = "users")]
    public List<User> Users { get; set; }

    [DataMember(Name = "cache_version")]
    public string CacheVersion { get; set; }

    [DataMember(Name = "cache_ts_version")]
    public string CacheTimestampVersion { get; set; }

    [DataMember(Name = "bots")]
    public List<User> Bots { get; set; }

    [DataMember(Name = "url")]
    public Uri Url { get; set; }
  }
}
