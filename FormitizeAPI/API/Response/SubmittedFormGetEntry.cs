using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Response
{
    public class SubmittedFormAttachments
    {
        [JsonProperty(PropertyName = "url")]
        public string URL
        {
            get; set;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get; set;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get; set;
        }
    }

    [DataContract(Namespace = "")]
    public class SubmittedFormListEntry
    {
                [JsonProperty(PropertyName = "formID")]
    public int FormID
    {
        get; set;
    }

    [JsonProperty(PropertyName = "submittedFormID")]
    public int SubmittedFormID
    {
        get; set;
    }

    [JsonProperty(PropertyName = "jobID")]
    public int JobID
    {
        get; set;
    }

    [JsonProperty(PropertyName = "userName")]
    public String UserName
    {
        get; set;
    }

    [JsonProperty(PropertyName = "count")]
    public String FormCount
    {
        get; set;
    }

    [JsonProperty(PropertyName = "version")]
    public String Version
    {
        get; set;
    }

    [JsonProperty(PropertyName = "title")]
    public String Title
    {
        get; set;
    }

    [JsonProperty(PropertyName = "latitude")]
    public String Latitude
    {
        get; set;
    }

    [JsonProperty(PropertyName = "longitude")]
    public String Longitude
    {
        get; set;
    }

    [JsonProperty(PropertyName = "location")]
    public String Location
    {
        get; set;
    }
}

    [DataContract(Namespace = "")]
    public class SubmittedFormGetEntry : SubmittedFormContent
    {
        [JsonProperty(PropertyName = "formID")]
        public int FormID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "submittedFormID")]
        public int SubmittedFormID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "jobID")]
        public int JobID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "userName")]
        public String UserName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "count")]
        public String FormCount
        {
            get; set;
        }

        [JsonProperty(PropertyName = "version")]
        public String Version
        {
            get; set;
        }

        [JsonProperty(PropertyName = "title")]
        public String Title
        {
            get; set;
        }

        [JsonProperty(PropertyName = "latitude")]
        public String Latitude
        {
            get; set;
        }

        [JsonProperty(PropertyName = "longitude")]
        public String Longitude
        {
            get; set;
        }

        [JsonProperty(PropertyName = "location")]
        public String Location
        {
            get; set;
        }

        [JsonProperty(PropertyName = "attachments")]
        public Dictionary<string, SubmittedFormAttachments> Attachments
        {
            get; set;
        }

    }
}