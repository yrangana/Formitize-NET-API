using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Asset.Schema
{
    [DataContract(Namespace = "")]
    public class Schema
    {

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }


        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get; set;
        }


        [JsonProperty(PropertyName = "columns")]
        public List<SchemaColumn> Columns
        {
            get; set;
        }

        [JsonProperty(PropertyName = "actions")]
        public Dictionary<string, string> Actions
        {
            get; set;
        }


        public Schema()
        {
            Columns = new List<SchemaColumn>();
            Actions = new Dictionary<string, string>();
        }
    }
}
