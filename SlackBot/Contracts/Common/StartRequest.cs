using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SlackBot.Contracts.Common
{
  [DataContract]
  public class StartRequest
  {
    [DataMember(Name = "token", IsRequired = true)]
    public string Token { get; set; }

    [DataMember(Name = "simple_latest")]
    public string SimpleLatest { get; set; }

    [DataMember(Name = "no_unreads")]
    public string NoUnreads { get; set; }

    [DataMember(Name = "mpim_aware")]
    public string MpimAware { get; set; }
  }
}
