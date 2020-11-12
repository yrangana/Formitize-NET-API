using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AssetSchema = Formitize.API.Model.Asset.Schema;

namespace Formitize.API.Response.CRM
{
    public class ClientListCustomData
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; private set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; private set; }
        [JsonProperty(PropertyName = "extra")]
        public string Extra { get; private set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; private set; }
    }



    public class Client
    {
        [JsonProperty(PropertyName = "clientID")]
        public int ClientID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "contactID")]
        public int ContactID
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "billingName")]
        public string BillingName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "name")]
        public string ContactName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "firstName")]
        public string ContactFirstName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "lastName")]
        public string ContactLastName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "status")]
        public string Status
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "clientType")]
        public string ClientType
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryAddress")]
        public string PrimaryAddress
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "latestNote")]
        public string LatestNote
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "dateModified")]
        public int UnixDateModified
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "dateCreated")]
        public int UnixDateCreated
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "cacheData")]
        public List<ClientListCustomData> CustomFields
        {
            get; private set;
        }

        public Client()
        {
            CustomFields = new List<ClientListCustomData>();
        }

    }

    public class ClientListResponse : List<Client>
    {

    }

}