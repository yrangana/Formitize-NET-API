using System;
using Newtonsoft.Json;
using Formitize.API.Model;

namespace Formitize.API.Response
{
    public class Response<T>
    {

        [JsonProperty(PropertyName = "payload")]
        public T Payload
        {
            get; set;
        }

        [JsonProperty(PropertyName =  "paging")]
        public Pagination Paging
        {
            get; set; 
        }


        public Response()
        {
        }
    }
}
