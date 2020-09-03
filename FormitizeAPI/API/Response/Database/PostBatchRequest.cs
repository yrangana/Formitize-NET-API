using System.Collections.Generic;
using Formitize.API.Interface;
using Newtonsoft.Json;

namespace Formitize.API.Response.Database
{
    public class PostBatchRequest : iGetRequest
    {

        [JsonProperty(PropertyName = "payload")]
        public List<Dictionary<string, string>> Payload
        {
            get; set;
        }

        [JsonProperty(PropertyName = "pk")]
        public List<string> PrimaryKeys
        {
            get; set;
        }

        public PostBatchRequest()
        {
            Payload = new List<Dictionary<string, string>>();
        }
    }
}
