using System.Collections.Generic;

namespace SlackBot
{
  internal interface IMessageQueue
  {
    Dictionary<string, object> ReadMessage();
    void SendMessage(Dictionary<string, object> message);
    void AddReceivedMessage(Dictionary<string, object> message);
    Dictionary<string, object> GetSendMessage();
  }
}
