using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class Group : Channel
  {
    [DataMember (Name = "is_group")]
    public bool IsGroup { get; set; }
  }
}