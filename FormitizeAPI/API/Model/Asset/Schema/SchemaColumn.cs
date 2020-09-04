using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Asset.Schema
{
    [DataContract(Namespace = "")]
    public class SchemaColumn
    {

        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get; private set;
        }


        [JsonProperty(PropertyName = "col")]
        public string Column
        {
            get; private set;
        }
    }
}
