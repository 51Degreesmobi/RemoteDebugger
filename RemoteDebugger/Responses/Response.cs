using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Responses
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        [DataMember(Name = "error")]
        public object Error { get; set; }
        [DataMember(Name = "result")]
        public Dictionary<string, object> Result = new Dictionary<string, object>();

    }
}
