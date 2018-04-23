using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class CRMVariableField
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

        [JsonProperty(PropertyName = "extra")]
        public string Extra
        {
            get; set;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get; set;
        }

        public CRMVariableField()
        {
        }


    }
}
