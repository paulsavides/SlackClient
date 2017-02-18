using System;
using Pisces.Slack.Contracts.Events;
using Pisces.Slack.Client.Queue;
using System.Net.WebSockets;
using System.Collections.Generic;
using Pisces.Slack.Client.Helpers;
using Pisces.Slack.Client.Init;
using Pisces.Slack.Contracts.Context;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Text;

namespace Pisces.Slack.Client
{
  internal class SlackBot : ISlackBot
  {
    private readonly IMessageQueue _msgQueue;
    private const int receiveChunkSize = 512;
    private ClientWebSocket ws;

    private string _apiKey;

    public SlackBot(string apiKey)
    {
      _msgQueue = new MessageQueue();
      _apiKey = apiKey;
    }

    public MessageEvent ReadMessage()
    {
      return _msgQueue.ReadMessage().ToMessageContract();
    }

    public void SendMessage(MessageEvent message)
    {
      _msgQueue.SendMessage(message.ToQueueFormat());
    }

    public void Start()
    {
      RTM.Start(new StartRequest
      {
        Token = _apiKey
      });

      try
      {
        // Connect to the URL
        Connect(SlackContext.Url);

        // Fire off a task that will receive messages and add them to the queue
        Task.Factory.StartNew(() => ProcessRead());
        Task.Factory.StartNew(() => ProcessSend());
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception: {0}", e.Message);
      }
    }

    private void Connect(Uri uri)
    {
      // May not be necessary to be its own method
      ws = new ClientWebSocket();
      ws.ConnectAsync(uri, CancellationToken.None).Wait();

      // If slack doesn't send us a "hello" we're in trouble.
      var connectResp = ReadFromSocket();

      if (connectResp.GetValueByKey("type") != "hello")
      {
        throw new Exception("Connecting to the WebSocket failed.");
      }

    }

    private void ProcessRead()
    {
      // infinite loop will need to be fixed eventually
      // ReadFromSocket() only returns once a message has been read
      // so no need to 'sleep', can run as fast as it wants imo
      while (true)
      {
        var message = ReadFromSocket();
        RouteReceivedMessage(message);
      }
    }

    private void RouteReceivedMessage(Dictionary<string, object> message)
    {
      // Should add more routing...
      // Potentially, use these routes to update the context, something like
      // case "user_joined" => update the context with new user, etc...
      switch (message.GetValueByKey("type"))
      {
        case EventTypes.ReconnectUrl:
          SlackContext.ReconnectUri = new Uri(message.GetValueByKey("url"));
          break;
        case EventTypes.Message:
          _msgQueue.AddReceivedMessage(message);
          break;
        default:
          break;
      }
    }

    private Dictionary<string, object> ReadFromSocket()
    {
      string receivedMsg = "";
      Task<WebSocketReceiveResult> promise;

      do
      {
        byte[] buffer = new byte[receiveChunkSize];

        // Get the promise (js term ok)

        promise = ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        // Wait for it to finish execution
        promise.Wait();

        // Get the result from the promise
        receivedMsg += buffer.ConvertToString();

      } while (!promise.Result.EndOfMessage);

      if (promise.Result.MessageType == WebSocketMessageType.Close)
      {
        Connect(SlackContext.ReconnectUri);
      }

      return JsonConvert.DeserializeObject<Dictionary<string, object>>(receivedMsg);
    }

    private void ProcessSend()
    {
      while (true)
      {
        var sendmsg = _msgQueue.GetSendMessage();

        if (sendmsg.GetValueByKey("type") != EventTypes.NoMessage)
        {
          SendToSocket(sendmsg);
        }

        Thread.Sleep(1000);
      }
    }

    private void SendToSocket(Dictionary<string, object> message)
    {
      char[] msg = JsonConvert.SerializeObject(message).ToCharArray();
      byte[] buffer = Encoding.Default.GetBytes(msg);

      ws.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None).Wait();
    }
  }
}
