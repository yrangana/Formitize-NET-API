using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AssetSchema = Formitize.API.Model.Asset.Schema;

namespace Formitize.API.Response.CRM
{
    public class PostCRMClientResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int ClientID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "billingName")]
        public string BillingName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryContactID")]
        public int PrimaryContactID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryAddressID")]
        public int PrimaryAddressID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryContactName")]
        public string PrimaryContactName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryAddress")]
        public string PrimaryAddress
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "contactIDs")]
        public List<int> ContactIDs
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "locationIDs")]
        public List<int> LocationIDs
        {
            get; private set;
        }

    }
}