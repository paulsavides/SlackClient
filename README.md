# SlackClient
Definitely a work in progress


# Using this client
```C#
ISlackBot slackBot = Slacker.CreateSlackBot();
slackBot.start("<apiKey>");

MessageEvent msg = slackBot.ReadMessage();

if (SlackUtils.MessageToMe(msg))
{
  slackBot.SendMessage(new MessgeEvent
  {
    Channel = msg.Channel, // the channel the message was sent from
    Type = EventTypes.Message,
    Text = $"Hello {message.User.Name}" // respond directly to the user
                                        // that sent you this message
  });
}
```

# SlackContext
When slackBot.start() is called, Slack will give us a large amount of information about the current context we are operating in. When that information is received, this bot maps it onto the static SlackContext class. If you need information about channels in your team, users in your team, etc... look through SlackContext.

## Example
```C#
ISlackBot slackBot = Slacker.CreateSlackBot();
slackBot.start("<apiKey>");

List<User> users = SlackContext.Users;

Console.WriteLine("These are all the users in this team.");
foreach (var user in users)
{
  Console.WriteLine("{user.Name}");
}
```

As of right now, the context is only current as of starting the slackbot. In the future, I hope to have the bot keep the context current as context related messages come in.