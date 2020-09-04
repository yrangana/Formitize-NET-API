using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Asset
{
    [DataContract(Namespace = "")]
    public class Entity
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


        [JsonProperty(PropertyName = "schema")]
        public Schema.Schema Schema
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "actions")]
        public List<string> Actions
        {
            get; private set;
        }


        public Entity()
        {
            this.Schema = new Schema.Schema();
        }
    }
}
