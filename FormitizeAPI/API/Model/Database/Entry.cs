using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Database
{
    [DataContract(Namespace = "")]
    public class Entry
    {

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }

        public Dictionary<string, string> Content
        {
            get; set;
        }

        public Entry()
        {
            Content = new Dictionary<string, string>();
        }
    }
}
