using Newtonsoft.Json;
using Pisces.Slack.Contracts.Context;
using Pisces.Slack.Client.Helpers;
using System.Net.Http;
using System.Text;

namespace Pisces.Slack.Client.Init
{
  internal static class RTM
  {
    internal static void Start(StartRequest req)
    {
      var response = Send(Constants.Endpoints.RTM.Start, req);
      var serResp = JsonConvert.DeserializeObject<StartResponse>(response);

      // The start response gives us a load of information about the context
      MapToContext(serResp);
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

    private static void MapToContext(StartResponse startResponse)
    {
      SlackContext.Bots = startResponse.Bots;
      SlackContext.Channels = startResponse.Channels;
      SlackContext.Dnd = startResponse.Dnd;
      SlackContext.Groups = startResponse.Groups;
      SlackContext.IMs = startResponse.IMs;
      SlackContext.Self = startResponse.Self;
      SlackContext.Subteams = startResponse.Subteams;
      SlackContext.Team = startResponse.Team;
      SlackContext.Url = startResponse.Url;
      SlackContext.Users = startResponse.Users;
    }
  }
}
