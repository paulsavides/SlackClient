using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class Group : Channel
  {
    [DataMember (Name = "is_group")]
    public bool IsGroup { get; set; }
  }
}