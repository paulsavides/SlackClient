using System.Runtime.Serialization;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class TNPBase
  {
    [DataMember (Name = "value")]
    public string Value { get; set; }

    [DataMember (Name = "creator")]
    public string Creator { get; set; }

    [DataMember (Name = "last_set")]
    public int LastSet { get; set; }
  }
}
