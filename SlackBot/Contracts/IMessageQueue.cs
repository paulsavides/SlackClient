using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackBot
{
  public interface IMessageQueue
  {
    Dictionary<string, object> ReadMessage();
    void SendMessage(Dictionary<string, object> message);
    void AddReceivedMessage(Dictionary<string, object> message);
    Dictionary<string, object> GetSendMessage();
  }
}
