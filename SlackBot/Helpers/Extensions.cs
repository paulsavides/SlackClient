using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        if (buffer[i] == (byte)'\0') break;
        c[i] = ((char)buffer[i]);
      }

      res = new char[i];
      if (i != 0) for (int j = 0; j < i; j++) { res[j] = c[j]; }

      if (res == null) res = new char[] { };
      return new string(res).Trim();
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
  }
}
