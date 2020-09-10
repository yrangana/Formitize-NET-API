using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Formitize.API.Response.Asset
{
    public class DeleteAssetResponse
    {
        [JsonProperty(PropertyName = "result")]
        public string Result
        {
            get; private set;
        }
    }
}