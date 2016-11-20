using System.Collections.Generic;
using System.Threading;
using SlackBot.Types;

namespace SlackBot
{
  public class MessageQueue : IMessageQueue
  {
    private Queue<Dictionary<string, object>> _rmsgq; // received message Queue
    private Queue<Dictionary<string, object>> _smsgq; // send message Queue
    private readonly Dictionary<string, object> _defaultmsg =
      new Dictionary<string, object> { { "type", EventTypes.NoMessage } };
    private bool _rrlocked; // Read lock
    private bool _rwlocked; // Write lock 
    private bool _srlocked; // Read lock
    private bool _swlocked; // Write lock
    private int limit = 100;

    public MessageQueue()
    {
      _rmsgq = new Queue<Dictionary<string, object>>();
      _smsgq = new Queue<Dictionary<string, object>>();
      _rrlocked = false;
      _rwlocked = false;
      _srlocked = false;
      _swlocked = false;
    }

    public Dictionary<string, object> ReadMessage()
    {
      Dictionary<string, object> res;
      while (_rrlocked)
      {
        Thread.Sleep(100);
      }
      _rrlocked = true;
      if (_rmsgq.Count > 0) res = _rmsgq.Dequeue();
      else res = _defaultmsg;
      _rrlocked = false;
      return res;
    }

    public void AddReceivedMessage(Dictionary<string, object> msg)
    {
      while (_rwlocked)
      {
        Thread.Sleep(100);
      }
      _rwlocked = true;
      _rmsgq.Enqueue(msg);

      // Only store <limit> most recent messages
      while (_rmsgq.Count > limit)
      {
        _rmsgq.Dequeue();
      }

      _rwlocked = false;
    }

    public Dictionary<string, object> GetSendMessage()
    {
      Dictionary<string, object> res;
      while (_srlocked)
      {
        Thread.Sleep(100);
      }
      _srlocked = true;
      if (_smsgq.Count > 0) res = _smsgq.Dequeue();
      else res = _defaultmsg;
      _srlocked = false;
      return res;
    }
    public void SendMessage(Dictionary<string, object> msg)
    {
      while (_swlocked)
      {
        Thread.Sleep(100);
      }
      _swlocked = true;
      _smsgq.Enqueue(msg);
      _swlocked = false;
    }
  }
}
