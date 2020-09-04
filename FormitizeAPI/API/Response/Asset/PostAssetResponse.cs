using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AssetSchema = Formitize.API.Model.Asset.Schema;

namespace Formitize.API.Response.Asset
{
    public class PostAssetResponse
    {
        [JsonProperty(PropertyName = "assetID")]
        public int AssetID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "schemaID")]
        public int SchemaID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "fieldsUpdated")]
        public Dictionary<string, string> UpdatedFields
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "schema")]
        public AssetSchema.Schema Schema
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "asset")]
        public Model.Asset.Asset Asset
        {
            get; private set;
        }


        public PostAssetResponse()
        {
            Asset = new Model.Asset.Asset();
        }

    }
}