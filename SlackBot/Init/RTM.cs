using Newtonsoft.Json;
using SlackBot.Contracts.Common;
using SlackBot.Helpers;
using System.Net.Http;
using System.Text;

namespace SlackBot.Init
{
  static class RTM
  {
    public static void Start(StartRequest req)
    {
      var response = Post.Send(Constants.Endpoints.RTM.Start, req);
      var serResp = JsonConvert.DeserializeObject<StartResponse>(response);

      // The start response gives us a load of information about the context
      InternalUtilities.MapToContext(serResp);
    }
  }
}
