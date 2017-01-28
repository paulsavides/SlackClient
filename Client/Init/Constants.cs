using System;

namespace Pisces.Slack.Client.Init
{
  class Constants
  {
    public static readonly Uri BaseUri = new Uri("https://slack.com/api/");

    public static class Endpoints
    {
      public static class RTM
      {
        public static string Start = "rtm.start";
      }
    }
  }
}
