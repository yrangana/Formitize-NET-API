using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model.Asset
{
    [DataContract(Namespace = "")]
    public class Asset
    {

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "schemaID")]
        public int SchemaID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude
        {
            get; set;
        }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude
        {
            get; set;
        }

        [JsonProperty(PropertyName = "altitude")]
        public double Altitude
        {
            get; set;
        }

        [JsonProperty(PropertyName = "clientID")]
        public int ClientID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "client")]
        public Client NewClient
        {
            get; set;
        }

        [JsonProperty(PropertyName = "locationID")]
        public int LocationID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "zoneID")]
        public int ZoneID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "zoneValue")]
        public string ZoneValue
        {
            get; set;
        }

        [JsonProperty(PropertyName = "clientName")]
        public string ClientName
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "location")]
        public string Location
        {
            get; private set;
        }


        [JsonProperty(PropertyName = "siteName")]
        public string SiteName
        {
            get; private set;
        }


        [JsonProperty(PropertyName = "address1")]
        public string Address1
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "address2")]
        public string Address2
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "city")]
        public string City
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "postcode")]
        public string Postcode
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "country")]
        public string Country
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "number")]
        public string Number
        {
            get; set;
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get; set;
        }

        [JsonProperty(PropertyName = "char1")]
        public string char1
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char2")]
        public string char2
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char3")]
        public string char3
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char4")]
        public string char4
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char5")]
        public string char5
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char6")]
        public string char6
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char7")]
        public string char7
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char8")]
        public string char8
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char9")]
        public string char9
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char10")]
        public string char10
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char11")]
        public string char11
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char12")]
        public string char12
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char13")]
        public string char13
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char14")]
        public string char14
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char15")]
        public string char15
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char16")]
        public string char16
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char17")]
        public string char17
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char18")]
        public string char18
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char19")]
        public string char19
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char20")]
        public string char20
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char21")]
        public string char21
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char22")]
        public string char22
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char23")]
        public string char23
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char24")]
        public string char24
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char25")]
        public string char25
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char26")]
        public string char26
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char27")]
        public string char27
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char28")]
        public string char28
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char29")]
        public string char29
        {
            get; set;
        }
        [JsonProperty(PropertyName = "char30")]
        public string char30
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int1")]
        public int int1
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int2")]
        public int int2
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int3")]
        public int int3
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int4")]
        public int int4
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int5")]
        public int int5
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int6")]
        public int int6
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int7")]
        public int int7
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int8")]
        public int int8
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int9")]
        public int int9
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int10")]
        public int int10
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int11")]
        public int int11
        {
            get; set;
        }
        [JsonProperty(PropertyName = "int12")]
        public int int12
        {
            get; set;
        }

        [JsonProperty(PropertyName = "int13")]
        public int int13
        {
            get; set;
        }

        [JsonProperty(PropertyName = "int14")]
        public int int14
        {
            get; set;
        }

        [JsonProperty(PropertyName = "int15")]
        public int int15
        {
            get; set;
        }

        [JsonProperty(PropertyName = "dbl1")]
        public double dbl1
        {
            get; set;
        }

        [JsonProperty(PropertyName = "dbl2")]
        public double dbl2
        {
            get; set;
        }

        [JsonProperty(PropertyName = "dbl3")]
        public double dbl3
        {
            get; set;
        }

        [JsonProperty(PropertyName = "dbl4")]
        public double dbl4
        {
            get; set;
        }
        [JsonProperty(PropertyName = "dbl5")]
        public double dbl5
        {
            get; set;
        }
        [JsonProperty(PropertyName = "dbl6")]
        public double dbl6
        {
            get; set;
        }
        [JsonProperty(PropertyName = "dbl7")]
        public double dbl7
        {
            get; set;
        }
        [JsonProperty(PropertyName = "content")]
        public Dictionary<string, string> Content
        {
            get; set;
        }

        public Asset()
        {
            Content = new Dictionary<string, string>();
        }
    }
}
