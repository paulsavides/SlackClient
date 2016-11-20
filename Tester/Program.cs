using SlackBot;
using SlackBot.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tester
{
  class Program
  {
    static void Main(string[] args)
    {
      Random rand = new Random();

      ISlackBot slackBot = new Slacker();

      slackBot.Start("apiKey");
      Dictionary<string, object> message;

      while (true)
      {
        message = slackBot.ReadMessage();
        PrintMessage(message);

        if (Utilities.MessageToMe(message))
        {
          User user = Utilities.GetUserSender(message);
          if (user == null) continue; // this shouldn't happen but it's possible

          Channel channel = Utilities.GetChannel(message);

          slackBot.SendMessage(new Dictionary<string, object>
          {
            {"id" , rand.Next(1000) },
            {"type", EventTypes.Message },
            {"channel", channel.Id },
            {"text" , $"Hello, {user.Name}"}
          });
        }
        Thread.Sleep(1000);
      }
    }

    private static void PrintMessage(Dictionary<string, object> message)
    {
      Console.WriteLine("----------------");

      foreach (var part in message)
      {
        Console.WriteLine(part.Key.ToString() + ": " + part.Value.ToString());
      }
    }
  }
}
