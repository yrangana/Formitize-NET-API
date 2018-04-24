using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class Pagination
    {
        [JsonProperty(PropertyName = "next")]
        string Next
        {
            get;  set;
        }

        [JsonProperty(PropertyName = "prev")]
        public string Prev
        {
            get;  set;
        }

        public Pagination()
        {
        }


    }
}
