using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public class Command
    {

        public string Method { get; private set; }

        internal Dictionary<string, string> _params = new Dictionary<string, string>();

        public Command(string method)
        {
            Method = method;
        }

        private void addRawParam(string param, string value)
        {
            if (_params.ContainsKey(param))
                _params[param] = value;
            else
                _params.Add(param, value);
        }

        public void addParam(string param, string value)
        {
            addRawParam(param, String.Format("\"{0}\"", value));
        }

        public void addParam(string param, int value)
        {
            addRawParam(param, value.ToString());
        }

        public void addParam(string param, double value)
        {
            addRawParam(param, value.ToString());
        }

        public void addParam(string param, bool value)
        {
            addRawParam(param, value.ToString().ToLower());
        }

        public void addParam(string param, object value)
        {
            DataContractJsonSerializerSettings settings =
                        new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;

            DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(value.GetType(), settings);

            using (MemoryStream mem = new MemoryStream())
            {
                serializer.WriteObject(mem, value);
                string json = UnicodeEncoding.UTF8.GetString(mem.ToArray());
                addRawParam(param, json);
            }
        }

        public string GetMessage(int id)
        {
            string paramString;
            if (_params.Count > 0)
            {
                paramString = String.Format(" ,\"params\": {0}", GetJsonFromDictionary(_params));
            }
            else
            {
                paramString = String.Empty;
            }

            return String.Format("{{\"id\": {0}, \"method\":\"{1}\" {2} }}", id, Method, paramString);
        }

        public static string GetJsonFromDictionary(Dictionary<string, string> dictionary)
        {
            List<string> keyValues = new List<string>();
            foreach (var p in dictionary)
            {
                keyValues.Add(String.Format("\"{0}\": {1}", p.Key, p.Value));
            }
            return String.Format("{{{0}}}", String.Join(",", keyValues));
        }
    }
}
