# SlackClient
Definitely a work in progress


# Using this client
```C#
ISlackBot slackBot = new Slacker("<apikey>");
var msg = slackBot.ReadMessage();

slackBot.SendMessage(new Dictionary<string, object> {
  {"type", EventTypes.Message},
  {"id", rand.Next(1000)},
  {"channel", Context.Channels.Find((channel) => (channel.Name = "default")).Id}
  {"text", "Hello World"}
});

```

something like that ^^^^