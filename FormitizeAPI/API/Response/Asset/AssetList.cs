using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AssetSchema = Formitize.API.Model.Asset.Schema;

namespace Formitize.API.Response.Asset
{
    public class AssetListResponse
    {
        [JsonProperty(PropertyName = "schema")]
        public AssetSchema.Schema Schema
        {
            get; set;
        }

        [JsonProperty(PropertyName = "results")]
        public List<Model.Asset.Asset> Assets
        {
            get; set;
        }

        public AssetListResponse()
        {
            Assets = new List<Model.Asset.Asset>();
        }
    }
}