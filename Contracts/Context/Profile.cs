using System;
using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class Profile
  {
    [DataMember (Name = "first_name")]
    public string FirstName { get; set; }

    [DataMember(Name = "last_name")]
    public string LastName { get; set; }

    [DataMember(Name = "image_original")]
    public Uri ImageOriginal { get; set; }

    [DataMember(Name = "fields")]
    public object Fields { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "phone")]
    public string Phone { get; set; }

    [DataMember(Name = "skype")]
    public string Skype { get; set; }

    [DataMember(Name = "real_name")]
    public string RealName { get; set; }

    [DataMember(Name = "real_name_normalized")]
    public string RealNameNormalized { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }
  }
}