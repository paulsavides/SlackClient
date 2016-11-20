using SlackBot.Helpers;
using System.Text;
using System.Net.Http;

namespace SlackBot.Init
{
  static class Post
  {
    public static string Send(string apiUrl, object req)
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
