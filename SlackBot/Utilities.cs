using SlackBot.Contracts.Common;
using SlackBot.Helpers;
using System.Collections.Generic;
using SlackBot.Types;

namespace SlackBot
{
  public static class Utilities
  {
    public static Channel GetChannel(Dictionary<string, object> msg)
    {
      string channelId = msg.GetValueByKey("channel");
      Channel foundChannel = Context.Channels.Find((channel) => channel.Id == channelId);

      if (foundChannel == null)
      {
        // slack is sort of odd
        foundChannel = Context.Groups.Find((group) => (group.Id == channelId));
      }

      return foundChannel;
    }

    public static bool MessageToMe(MessageEvent msg)
    {
      return msg.Text.Contains(Context.Self.ID);
    }

    public static bool MessageToMe(Dictionary<string, object> msg)
    {
      bool messageToMe = false;
      if (MessageIsGivenType(msg, "message"))
      {
        if (msg.GetValueByKey("text").Contains(Context.Self.ID))
        {
          messageToMe = true;
        }
      }

      return messageToMe;
    }

    public static User GetUserSender(Dictionary<string, object> msg)
    {
      string userId = msg.GetValueByKey("user");
      return Context.Users.Find((one) => (one.ID == userId));
    }


    public static bool MessageIsGivenType(Dictionary<string, object> msg, string type)
    {
      if (msg.GetValueByKey("type") == type) return true;
      return false;
    }
  }
}
