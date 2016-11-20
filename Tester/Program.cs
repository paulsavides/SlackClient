using SlackBot;
using SlackBot.Contracts.Common;
using System;
using System.Configuration;
using System.Threading;
using SlackBot.Types;

namespace Tester
{
  class Program
  {
    static void Main(string[] args)
    {
      string apiKey = ConfigurationManager.AppSettings.Get("apiKey");


      ISlackBot slackBot = new Slacker();
      slackBot.Start(apiKey);

      MessageEvent message;

      while (true)
      {
        message = slackBot.ReadMessage();

        Console.WriteLine("!!!!!!!");
        Console.WriteLine($"type: {message.Type}");
        Console.WriteLine($"user: {message.User?.ID}");
        Console.WriteLine($"channel: {message.Channel?.Id}");
        Console.WriteLine($"text: {message.Text}");
        Console.WriteLine($"timestamp: {message.Timestamp}");

        if (Utilities.MessageToMe(message))
        {
          slackBot.SendMessage(new MessageEvent
          {
            Type = EventTypes.Message,
            User = Context.Self,
            Channel = message.Channel,
            Text = $"Hello {message.User.Name}",
            Timestamp = DateTime.Now
          });
        }

        Thread.Sleep(1000);
      }
    }

  }
}
