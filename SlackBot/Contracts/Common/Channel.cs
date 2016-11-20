using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class Channel
  {
    [DataMember (Name = "id")]
    public string Id { get; set; }

    [DataMember (Name = "name")]
    public string Name { get; set; }

    [DataMember (Name = "created")]
    public int Created { get; set; }

    [DataMember (Name = "creator")]
    public string Creator { get; set; }

    [DataMember (Name = "is_archived")]
    public bool IsArchived { get; set; }

    [DataMember (Name = "is_general")]
    public bool IsGeneral { get; set; }

    [DataMember (Name = "has_pins")]
    public bool HasPins { get; set; }

    [DataMember (Name = "is_member")]
    public bool IsMember { get; set; }

    [DataMember (Name = "latest")]
    public Message Latest { get; set; }

    [DataMember (Name = "unread_count")]
    public int UnreadCount { get; set; }

    [DataMember (Name = "unread_count_display")]
    public int UnreadCountDisplay { get; set; }

    [DataMember (Name = "members")]
    public List<string> Members { get; set; }

    [DataMember (Name = "topic")]
    public Topic Topic { get; set; }

    [DataMember (Name = "purpose")]
    public Purpose Purpose { get; set; }
  }
}
