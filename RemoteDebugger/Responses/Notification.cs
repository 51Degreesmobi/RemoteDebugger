using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Responses
{
    [DataContract]
    public class Notification
    {
        [DataMember(Name = "method")]
        public string Method { get; set; }
        [DataMember(Name = "params")]
        public Dictionary<string, object> Params = new Dictionary<string, object>();
    }
}
