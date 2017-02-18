using System.Collections.Generic;
using Pisces.Slack.Contracts.Events;

namespace Pisces.Slack.Client.Queue
{
  internal class MessageQueue : IMessageQueue
  {
    private Queue<Dictionary<string, object>> _rmsgq; // received message Queue
    private Queue<Dictionary<string, object>> _smsgq; // send message Queue
    private readonly Dictionary<string, object> _defaultmsg =
      new Dictionary<string, object> { { "type", EventTypes.NoMessage } };
    private int limit = 100;

    public MessageQueue()
    {
      _rmsgq = new Queue<Dictionary<string, object>>();
      _smsgq = new Queue<Dictionary<string, object>>();
    }

    public Dictionary<string, object> ReadMessage()
    {
      if (_rmsgq.Count <= 0) return _defaultmsg;
      return _rmsgq.Dequeue();
    }

    public void AddReceivedMessage(Dictionary<string, object> msg)
    {
      _rmsgq.Enqueue(msg);

      // Only store <limit> most recent messages
      while (_rmsgq.Count > limit)
      {
        _rmsgq.Dequeue();
      }
    }

    public Dictionary<string, object> GetSendMessage()
    {
      if (_smsgq.Count <= 0) return _defaultmsg;
      return _smsgq.Dequeue();
    }
    public void SendMessage(Dictionary<string, object> msg)
    {
      _smsgq.Enqueue(msg);

      while (_smsgq.Count > limit)
      {
        _smsgq.Dequeue();
      }
    }
  }
}
