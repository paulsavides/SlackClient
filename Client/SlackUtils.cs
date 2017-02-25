using Pisces.Slack.Client.Helpers;
using Pisces.Slack.Contracts.Context;
using Pisces.Slack.Contracts.Events;
using System.Collections.Generic;

namespace Pisces.Slack.Client
{
  public static class SlackUtils
  {
    public static Channel GetChannel(this SlackContext ctx, Dictionary<string, object> msg)
    {
      string channelId = msg.GetValueByKey("channel");
      Channel foundChannel = ctx.Channels.Find((channel) => channel.Id == channelId);

      if (foundChannel == null)
      {
        // slack is sort of odd
        foundChannel = ctx.Groups.Find((group) => (group.Id == channelId));
      }

      return foundChannel;
    }

    public static bool MessageToMe(this SlackContext ctx, MessageEvent msg)
    {
      return msg.Text.Contains(ctx.Self.ID);
    }

    public static bool MessageToMe(this SlackContext ctx, Dictionary<string, object> msg)
    {
      bool messageToMe = false;
      if (MessageIsGivenType(msg, "message"))
      {
        if (msg.GetValueByKey("text").Contains(ctx.Self.ID))
        {
          messageToMe = true;
        }
      }

      return messageToMe;
    }

    public static User GetUserSender(this SlackContext ctx, Dictionary<string, object> msg)
    {
      string userId = msg.GetValueByKey("user");
      return ctx.Users.Find((one) => (one.ID == userId));
    }


    public static bool MessageIsGivenType(Dictionary<string, object> msg, string type)
    {
      if (msg.GetValueByKey("type") == type) return true;
      return false;
    }
  }
}
