using System.Configuration;

namespace Pisces.Slack.Client
{
  public class Slacker
  {
    private static ISlackBot _slackBot;
    private static string _apiKey = ConfigurationManager.AppSettings.Get("SlackApiKey");

    public static ISlackBot CreateSlackBot()
    {
      if (_slackBot == null)
      {
        _slackBot = new SlackBot(_apiKey);
      }

      return _slackBot;
    }

    public static ISlackBot CreateSlackBot(string apiKey)
    {
      _apiKey = apiKey;
      return CreateSlackBot();
    }
  }
}