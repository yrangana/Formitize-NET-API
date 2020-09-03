using System.Collections.Generic;
using Formitize.API.Interface;
using Newtonsoft.Json;

namespace Formitize.API.Response.Database
{
    public class PostBatchResponse
    {

        [JsonProperty(PropertyName = "result")]
        public string Result
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "note")]
        public string Note
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "serviceID")]
        public string ServiceID
        {
            get; private set;
        }
    }
}
