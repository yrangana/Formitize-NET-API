using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class Zone
    {
        [JsonProperty(PropertyName = "id")]
        public string ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "value")]
        public string Value
        {
            get; set;
        }

        public Zone()
        {
        }


    }
}
