using Pisces.Slack.Contracts.Context;
using Pisces.Slack.Contracts.Events;

namespace Pisces.Slack.Client
{
  public interface ISlackBot
  {
    void Start();
    SlackContext Context { get; }
    MessageEvent ReadMessage();
    void SendMessage(MessageEvent message);
  }
}
