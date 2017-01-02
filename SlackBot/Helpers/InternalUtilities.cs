using SlackBot.Contracts.Common;

namespace SlackBot.Helpers
{
  internal static class InternalUtilities
  {
    public static void MapToContext(StartResponse startResponse)
    {
      SlackContext.Bots = startResponse.Bots;
      SlackContext.Channels = startResponse.Channels;
      SlackContext.Dnd = startResponse.Dnd;
      SlackContext.Groups = startResponse.Groups;
      SlackContext.IMs = startResponse.IMs;
      SlackContext.Self = startResponse.Self;
      SlackContext.Subteams = startResponse.Subteams;
      SlackContext.Team = startResponse.Team;
      SlackContext.Url = startResponse.Url;
      SlackContext.Users = startResponse.Users;
    }
  }
}
