using System.Collections.Generic;
using SlackBot.Types;

namespace SlackBot
{
  public interface ISlackBot
  {
    void Start(string apiKey);
    MessageEvent ReadMessage();
    void SendMessage(MessageEvent message);
  }
}
