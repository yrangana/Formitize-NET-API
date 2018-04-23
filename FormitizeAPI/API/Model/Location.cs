using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace ="")]
    public class Location
    {

        [JsonProperty(PropertyName = "id")]
        int ID
        {
            get; set;
        }



        [JsonProperty(PropertyName = "street1")]
        string Street1
        {
            get; set;
        }

        [JsonProperty(PropertyName = "street2")]
        string Street2
        {
            get; set;
        }

        [JsonProperty(PropertyName = "city")]
        string City
        {
            get; set;
        }

        [JsonProperty(PropertyName = "state")]
        string State
        {
            get; set;
        }

        [JsonProperty(PropertyName = "country")]
        string Country
        {
            get; set;
        }



        [JsonProperty(PropertyName = "custom")]
        public Dictionary<string, CRMVariableField> CustomFields
        {
            get; set;
        }


        public Location()
        {
            CustomFields = new Dictionary<string, CRMVariableField>();
        }



        private string GetIDByType(string Type)
        {
            foreach (var field in CustomFields)
            {
                if (field.Value.Type == Type)
                    return field.Key;
            }

            return null;
        }

        public CRMVariableField GetFieldByType(string Type)
        {
            foreach (var field in CustomFields)
            {
                if (field.Value.Type == Type)
                    return field.Value;
            }

            return null;
        }

        public void SetFieldByType(string Type, CRMVariableField Entry)
        {
            foreach (var field in CustomFields)
            {
                if (field.Value.Type == Type)
                {
                    CustomFields[field.Key] = Entry;
                    return;
                }
            }
            CustomFields[Entry.Type] = Entry;
        }

    }
}
