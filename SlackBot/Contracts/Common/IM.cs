using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class IM
  {
    [DataMember (Name = "id")]
    public string ID { get; set; }

    [DataMember (Name = "user")]
    public string User { get; set; }

    [DataMember (Name = "created")]
    public int Created { get; set; }

    [DataMember (Name = "is_im")]
    public bool IsIm { get; set; }

    [DataMember (Name = "is_org_shared")]
    public bool IsOrgShared { get; set; }

    [DataMember (Name = "has_pins")]
    public bool HasPins { get; set; }

    [DataMember (Name = "last_read")]
    public string LastRead { get; set; }

    [DataMember (Name = "latest")]
    public Message Lastest { get; set; }

    [DataMember (Name = "unread_count")]
    public int UnreadCount { get; set; }

    [DataMember (Name = "unread_count_display")]
    public int UnreadCountDisplay { get; set; }

    [DataMember (Name = "is_open")]
    public bool IsOpen { get; set; }
  }
}