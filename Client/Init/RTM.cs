using Newtonsoft.Json;
using Pisces.Slack.Contracts.Context;
using Pisces.Slack.Client.Helpers;
using System.Net.Http;
using System.Text;

namespace Pisces.Slack.Client.Init
{
  internal static class RTM
  {
    internal static SlackContext Start(StartRequest req)
    {
      var response = Send(Constants.Endpoints.RTM.Start, req);
      var serResp = JsonConvert.DeserializeObject<StartResponse>(response);

      // The start response gives us a load of information about the context
      return MapToContext(serResp);
    }

    private static string Send(string apiUrl, object req)
    {
      string reqData = req.ToHttpFormData();
      string response = "";
      using (var client = new HttpClient())
      {
        client.BaseAddress = Constants.BaseUri;
        var payload = new StringContent(reqData, Encoding.UTF8, "application/x-www-form-urlencoded");
        var result = client.PostAsync(apiUrl, payload).Result;
        response = result.Content.ReadAsStringAsync().Result;
      }

      return response;
    }

    private static SlackContext MapToContext(StartResponse startResponse)
    {
      SlackContext ctx = new SlackContext
      {
        Bots = startResponse.Bots,
        Channels = startResponse.Channels,
        Dnd = startResponse.Dnd,
        Groups = startResponse.Groups,
        IMs = startResponse.IMs,
        Self = startResponse.Self,
        Subteams = startResponse.Subteams,
        Team = startResponse.Team,
        Url = startResponse.Url,
        Users = startResponse.Users
      };

      return ctx;
    }
  }
}
