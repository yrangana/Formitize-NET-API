using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class Client
    {
        [JsonProperty(PropertyName = "billingName")]
        string BillingName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "primaryContactName")]
        public string PrimaryContactName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryContactPhone")]
        public string PrimaryContactPhone
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryContactEmail")]
        public string PrimaryContactEmail
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "primaryAddress")]
        public string PrimaryAddress
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "contact")]
        List<Contact> ContactList;


        [JsonProperty(PropertyName = "location")]
        List<Location> LocationList;

        public Client()
        {
            ContactList = new List<Contact>();
            LocationList = new List<Location>();
        }


    }
}
