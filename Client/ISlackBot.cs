using Pisces.Slack.Contracts.Events;

namespace Pisces.Slack.Client
{
  public interface ISlackBot
  {
    void Start();
    MessageEvent ReadMessage();
    void SendMessage(MessageEvent message);
  }
}
