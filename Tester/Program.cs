using System;
using System.Configuration;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Pisces.Slack.Contracts.Events;
using Pisces.Slack.Client;

namespace Tester
{
  class Program
  {
    private static string commandbegin = ConfigurationManager.AppSettings.Get("commandBegin");

    static void Main(string[] args)
    {
      ISlackBot slackBot = Slacker.CreateSlackBot();
      slackBot.Start();

      MessageEvent message;

      while (true)
      {
        message = slackBot.ReadMessage();

        Console.WriteLine("`````````````````");
        Console.WriteLine($"type: {message.Type}");
        Console.WriteLine($"user: {message.User?.ID}");
        Console.WriteLine($"channel: {message.Channel?.Id}");
        Console.WriteLine($"text: {message.Text}");
        Console.WriteLine($"timestamp: {message.Timestamp}");

        if (SlackUtils.MessageToMe(message))
        {
          Command command = processCommand(message.Text);

          slackBot.SendMessage(new MessageEvent
          {
            Channel = message.Channel,
            Type = EventTypes.Message,
            Text = $"{message.User.Name} gave command <{command.Operation}> with arguments {JoinArgs(command.Args)}"
          });
        }

        Thread.Sleep(1000);
      }
    }

    private static Command processCommand(string msg)
    {
      Command comm = new Command();

      string[] elems = msg.Split(' ');

      int ix = 0;
      int comm_ix = -1;

      foreach(var elem in elems)
      {
        if (elem.StartsWith(commandbegin))
        {
          comm.Operation = elem.Remove(0,1);
          comm_ix = ix;

          break;
        }

        ix++;
      }

      if (comm_ix > 0)
      {
        List<string> subset = elems.ToList();
        subset.RemoveRange(0, comm_ix+1);
        comm.Args = subset;
      }

      return comm;
    }

    private class Command
    {
      public string Operation { get; set; }
      public List<string> Args { get; set; }
    }

    private static string JoinArgs(List<string> args)
    {
      string res = "{";

      for (int ix = 0; ix < args?.Count; ix++)
      {
        res += args[ix];

        if (ix != args.Count - 1)
        {
          res += ", ";
        }
      }

      res += "}";

      return res;
    }

  }
}
