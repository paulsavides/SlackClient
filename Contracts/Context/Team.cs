using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{ 
  [DataContract]
  public class Team
  {
    [DataMember (Name = "id")]
    public string ID { get; set; }

    [DataMember (Name = "name")]
    public string Name { get; set; }

    [DataMember (Name = "email_domain")]
    public string EmailDomain { get; set; }

    [DataMember (Name = "domain")]
    public string domain { get; set; }

    [DataMember (Name = "msg_edit_window_mins")]
    public int MsgEditWindowMins { get; set; }

    [DataMember (Name = "prefs")]
    public Dictionary <string, object> Prefs { get; set; }

    [DataMember (Name = "icon")]
    public Dictionary<string, string> Icon { get; set; }

    [DataMember (Name = "over_storage_limit")]
    public bool OverStorageLimit { get; set; }

    [DataMember (Name = "plan")]
    public string Plan { get; set; }

    [DataMember (Name = "over_integrations_limit")]
    public bool OverIntegrationsLimit { get; set; }
  }
}