using Pisces.Slack.Client.Helpers;
using Pisces.Slack.Contracts.Context;
using Pisces.Slack.Contracts.Events;
using System.Collections.Generic;

namespace Pisces.Slack.Client
{
  public static class SlackUtils
  {
    public static Channel GetChannel(Dictionary<string, object> msg)
    {
      string channelId = msg.GetValueByKey("channel");
      Channel foundChannel = SlackContext.Channels.Find((channel) => channel.Id == channelId);

      if (foundChannel == null)
      {
        // slack is sort of odd
        foundChannel = SlackContext.Groups.Find((group) => (group.Id == channelId));
      }

      return foundChannel;
    }

    public static bool MessageToMe(MessageEvent msg)
    {
      return msg.Text.Contains(SlackContext.Self.ID);
    }

    public static bool MessageToMe(Dictionary<string, object> msg)
    {
      bool messageToMe = false;
      if (MessageIsGivenType(msg, "message"))
      {
        if (msg.GetValueByKey("text").Contains(SlackContext.Self.ID))
        {
          messageToMe = true;
        }
      }

      return messageToMe;
    }

    public static User GetUserSender(Dictionary<string, object> msg)
    {
      string userId = msg.GetValueByKey("user");
      return SlackContext.Users.Find((one) => (one.ID == userId));
    }


    public static bool MessageIsGivenType(Dictionary<string, object> msg, string type)
    {
      if (msg.GetValueByKey("type") == type) return true;
      return false;
    }
  }
}
