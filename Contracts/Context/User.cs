using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class User
  {
    [DataMember (Name = "id")]
    public string ID { get; set; }

    [DataMember (Name = "team_id")]
    public string TeamID { get; set; }

    [DataMember (Name = "name")]
    public string Name { get; set; }

    [DataMember (Name = "deleted")]
    public bool Deleted { get; set; }

    [DataMember (Name = "status")]
    public string Status { get; set; }

    [DataMember (Name = "color")]
    public string Color { get; set; } 

    [DataMember (Name = "real_name")]
    public string RealName { get; set; }

    [DataMember (Name = "tz")]
    public string Timezone { get; set; }

    [DataMember (Name = "tz_label")]
    public string TimezoneLabel { get; set; }

    [DataMember (Name = "tz_offset")]
    public int TimezoneOffset { get; set; }

    [DataMember (Name = "profile")]
    public Profile Profile { get; set; }

    [DataMember (Name = "is_admin")]
    public bool IsAdmin { get; set; }

    [DataMember (Name = "is_owner")]
    public bool IsOwner { get; set; }

    [DataMember (Name = "is_primary_owner")]
    public bool IsPrimaryOwner { get; set; }

    [DataMember (Name = "is_restricted")]
    public bool IsRestricted { get; set; }

    [DataMember (Name = "is_ultra_restricted")]
    public bool IsUltraRestricted { get; set; }

    [DataMember (Name = "is_bot")]
    public bool IsBot { get; set; }

    [DataMember (Name = "presence")]
    public string Presence { get; set; }
  }
}