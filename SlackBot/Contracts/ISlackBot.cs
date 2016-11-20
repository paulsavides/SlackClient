using System.Collections.Generic;
using SlackBot.Contracts;

namespace SlackBot
{
  public interface ISlackBot
  {
    void Start(string apiKey);
    Dictionary<string, object> ReadMessage();
    void SendMessage(Dictionary<string, object> message);
  }
}
