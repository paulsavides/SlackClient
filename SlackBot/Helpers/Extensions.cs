using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using SlackBot.Types;
using System;

namespace SlackBot.Helpers
{
  public static class Extensions
  {
    public static string ConvertToString(this byte[] buffer)
    {
      char[] c = new char[buffer.Length];
      char[] res = null;
      int i;
      for (i = 0; i < buffer.Length; i++)
      {
        if (buffer[i] == (byte)'\0') { break; }
        c[i] = ((char)buffer[i]);
      }

      res = new char[i];
      if (i != 0) for (int j = 0; j < i; j++) { res[j] = c[j]; }

      if (res == null) res = new char[] { };
      return new string(res);
    }
    public static string GetValueByKey(this Dictionary<string, object> dict, string key)
    {
      string res = "";
      object tmp;
      if (dict.TryGetValue(key, out tmp)) res = (string)tmp;
      return res;
    }
    internal static string ToHttpFormData(this object obj)
    {
      var properties = from p in obj.GetType().GetProperties()
                       where p.GetValue(obj, null) != null
                       select (p.GetCustomAttribute<DataMemberAttribute>().Name ?? p.Name)
                       + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

      return string.Join("&", properties.ToArray());
    }
    
    public static Dictionary<string, object> ToQueueFormat(this MessageEvent message)
    {
      return new Dictionary<string, object>
      {
        { "id"      , new Random().Next(10000) },
        { "type"    , message.Type },
        { "channel" , message.Channel.Id },
        { "text"    , message.Text },
        { "ts"      , message.Timestamp.ToTimestamp() }
      };
    }

    public static MessageEvent ToMessageContract(this Dictionary<string, object> msg)
    {
      var channel = SlackUtils.GetChannel(msg);
      var user = SlackUtils.GetUserSender(msg);

      return new MessageEvent
      {
        Type = msg.GetValueByKey("type"),
        Channel = channel,
        User = user,
        Text = msg.GetValueByKey("text"),
        Timestamp = msg.GetValueByKey("ts").ToDateTime()
      };
    }

    public static string ToTimestamp(this DateTime ts)
    {
      DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      TimeSpan elapsedTime = ts - Epoch;
      return ((long)elapsedTime.TotalSeconds).ToString();
    }

    public static DateTime ToDateTime(this string tsString)
    {
      double unixTimeStamp;
      double.TryParse(tsString, out unixTimeStamp);

      // Unix timestamp is seconds past epoch
      DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }
  }
}
