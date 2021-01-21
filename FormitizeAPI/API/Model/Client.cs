using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;


using System.Threading.Tasks;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class Client
    {

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "billingName")]
        public string BillingName
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

        public List<Contact> ContactList;


        [JsonProperty(PropertyName = "location")]
        public List<Location> LocationList;

        public Client()
        {
            ContactList = new List<Contact>();
            LocationList = new List<Location>();
        }

        public async Task<List<Location>> GetLocations(WebClient webClient)
        {
            if(this.LocationList.Count != 0)
            {
                
                return this.LocationList;
            }

            var client = await Formitize.API.Helper.CRM.GetClient(webClient, ID);

            this.LocationList = client.Payload.LocationList;

            return this.LocationList;

        }
    }
}
