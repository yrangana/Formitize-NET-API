using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AssetSchema = Formitize.API.Model.Asset.Schema;

namespace Formitize.API.Response.Asset
{
    public class AssetResponse
    {
        public int AssetID
        {
            get; private set;
        }

        public int SchemaID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "schema")]
        public AssetSchema.Schema Schema
        {
            get; set;
        }

        [JsonProperty(PropertyName = "asset")]
        public Model.Asset.Asset Asset
        {
            get; set;
        }

        public AssetResponse()
        {
            Asset = new Model.Asset.Asset();
            Schema = new AssetSchema.Schema();
        }

    }
}