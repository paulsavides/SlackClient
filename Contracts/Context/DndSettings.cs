using System.Runtime.Serialization;

namespace Pisces.Slack.Contracts.Context
{
  [DataContract]
  public class DndSettings
  {
    [DataMember (Name = "dnd_enabled")]
    public bool DndEnabled { get; set; }

    [DataMember (Name = "next_dnd_start_ts")]
    public string NextDndStartTimestamp { get; set; }

    [DataMember (Name = "next_dnd_end_ts")]
    public string NextDndEndTimestamp { get; set; }

    [DataMember (Name = "snooze_enabled")]
    public bool SnoozeEnabled { get; set; }
  }
}