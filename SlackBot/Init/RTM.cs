using Newtonsoft.Json;
using SlackBot.Contracts.Common;
using SlackBot.Helpers;
using System.Net.Http;
using System.Text;

namespace SlackBot.Init
{
  internal static class RTM
  {
    public static void Start(StartRequest req)
    {
      var response = Send(Constants.Endpoints.RTM.Start, req);
      var serResp = JsonConvert.DeserializeObject<StartResponse>(response);

      // The start response gives us a load of information about the context
      InternalUtilities.MapToContext(serResp);
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
  }
}
