using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
namespace Formitize.API.Response
{
    [DataContract]
    [JsonDictionary]
    public class JobGetList : Dictionary<String, JobGetEntry>
    {
        public JobGetList()
        {
        }


    }
}
