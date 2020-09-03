using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Response.Database
{
    [DataContract]
    [JsonDictionary]
    public class ListResponse : Dictionary<String, Formitize.API.Model.Database.Schema>
    {
        public ListResponse()
        {

        }
    }
}