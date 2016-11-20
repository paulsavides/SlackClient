using Newtonsoft.Json;
using SlackBot.Helpers;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using SlackBot.Contracts.Common;
using SlackBot.Init;
using System.Text;

namespace SlackBot
{
  public class Slacker : ISlackBot
  {
    private static IMessageQueue msgQueue = new MessageQueue();
    private const int sendChunkSize = 256;
    private const int receiveChunkSize = 256;
    private static ClientWebSocket ws;

    public Dictionary<string, object> ReadMessage()
    {
      return msgQueue.ReadMessage();
    }

    public void SendMessage(Dictionary<string, object> message)
    {
      msgQueue.SendMessage(message);
    }

    public void Start(string apiKey)
    {
      RTM.Start(new StartRequest
      {
        Token = apiKey
      });

      try
      {
        // Connect to the URL
        Connect(Context.Url);

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
          Context.ReconnectUri = new Uri(message.GetValueByKey("url"));
          break;
        case EventTypes.Message:
        default:
          msgQueue.AddReceivedMessage(message);
          break;
      }
    }

    private Dictionary<string, object> ReadFromSocket()
    {
     byte[] buffer = new byte[receiveChunkSize];

      // Get the promise (js term ok)
      var promise = ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

      // Wait for it to finish execution
      promise.Wait();

      // Get the result from the promise
      var result = promise.Result;
      string convertedmsg = buffer.ConvertToString();

      if (result.MessageType == WebSocketMessageType.Close)
      {
        Connect(Context.ReconnectUri);
      }

      return JsonConvert.DeserializeObject<Dictionary<string, object>>(convertedmsg);
    }

    private void ProcessSend()
    {
      while (true)
      {
        var sendmsg = msgQueue.GetSendMessage();

        if (sendmsg.GetValueByKey("type") != "no_message")
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