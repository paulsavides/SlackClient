using SlackBot.Contracts.Common;

namespace SlackBot
{
  static class InternalUtilities
  {
    public static void MapToContext(StartResponse startResponse)
    {
      Context.Bots = startResponse.Bots;
      Context.Channels = startResponse.Channels;
      Context.Dnd = startResponse.Dnd;
      Context.Groups = startResponse.Groups;
      Context.IMs = startResponse.IMs;
      Context.Self = startResponse.Self;
      Context.Subteams = startResponse.Subteams;
      Context.Team = startResponse.Team;
      Context.Url = startResponse.Url;
      Context.Users = startResponse.Users;
    }
  }
}
