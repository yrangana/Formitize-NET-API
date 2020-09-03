using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Database
{
    [DataContract(Namespace = "")]
    public class Schema
    {

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }


        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get; private set;
        }


        [JsonProperty(PropertyName = "columns")]
        public List<string> Columns;


        public Schema()
        {
            Columns = new List<string>();
        }
    }
}
