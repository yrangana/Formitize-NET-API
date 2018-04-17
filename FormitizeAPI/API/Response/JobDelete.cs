using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Formitize.API.Response
{
    public class JobDelete
    {

        [JsonProperty(PropertyName = "id")]
        public int JobID 
        {
            get; set;
        }

        [JsonProperty(PropertyName = "message")]
        public String Message
        {
            get; set; 
        }


        public JobDelete()
        {
        }
    }
}
