using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace ="")]
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        int ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "firstName")]
        string FirstName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "id")]
        int ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "lastName")]
        string LastName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "custom")]
        public Dictionary<string, CRMVariableField> CustomFields
        {
            get; set;
        }

        [JsonProperty(PropertyName = "email")]
        string Email
        {
            get; set;
        }


        [JsonProperty(PropertyName = "mobile")]
        string Mobile
        {
            get; set;
        }

        [JsonProperty(PropertyName = "mobileAreaCode")]
        string MobileAreaCode
        {
            get; set;
        }

        [JsonProperty(PropertyName = "workPhone")]
        string WorkPhone
        {
            get; set;

        }

        [JsonProperty(PropertyName = "homePhoneAreaCode")]
        string HomePhoneeAreaCode
        {
            get; set;
        }

        [JsonProperty(PropertyName = "homePhone")]
        string HomePhone
        {
            get; set;

        }

        [JsonProperty(PropertyName = "workPhoneAreaCode")]
        string WorkPhoneeAreaCode
        {
            get; set;
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

        public Contact()
        {
            CustomFields = new Dictionary<string, CRMVariableField>();
        }

    }
}
