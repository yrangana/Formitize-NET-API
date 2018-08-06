using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Response
{
    public class JobGetEntryForm
    {
        [JsonProperty(PropertyName = "id")]
        public int FormID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "title")]
        public String Title
        {
            get; set;
        }

    }

    public class JobGetEntry
    {
        [JsonProperty(PropertyName = "id")]
        public int JobID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "maintenanceID")]
        public int MaintenanceID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "jobNumber")]
        public String JobNumber
        {
            get; set;
        }

        [JsonProperty(PropertyName = "orderNumber")]
        public String OrderNumber
        {
            get; set;
        }

        [JsonProperty(PropertyName = "title")]
        public String Title
        {
            get; set;
        }

        [JsonProperty(PropertyName = "location")]
        public String Location
        {
            get; set;
        }

        [JsonProperty(PropertyName = "deliveryLocation")]
        public String DeliveryLocation
        {
            get; set;
        }

        [JsonProperty(PropertyName = "siteName")]
        public String DeliverySiteName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "status")]
        public int Status
        {
            get; set;
        }

        [JsonProperty(PropertyName = "statusLabel")]
        public string StatusLabel
        {
            get; set;
        }

        [DataMember(Name = "queueGroups")]
        public Dictionary<int, string> QueueGroups
        {
            get; set;
        }

        [JsonProperty(PropertyName = "deliveryContact")]
        public String DeliveryContact
        {
            get; set;
        }

        [JsonProperty(PropertyName = "deliveryNotes")]
        public String DeliveryNotes
        {
            get; set;
        }

        [JsonProperty(PropertyName = "deliveryPhone")]
        public String DeliveryPhone
        {
            get; set;
        }

        [JsonProperty(PropertyName = "assignedTo")]
        public String AgentID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "forms")]
        public Dictionary<int, JobGetEntryForm> Forms
        {
            get; set;
        }


        [DataMember(Name = "deliveryDate")]
        [JsonProperty(PropertyName = "deliveryDate")]
        public double DeliveryDateUnixtimestamp
        {
            get; set;
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public DateTime DeliveryDate
        {
            get
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(DeliveryDateUnixtimestamp).ToLocalTime();
                return dtDateTime;

            }
            set
            {
                DeliveryDateUnixtimestamp = (value.ToLocalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local)).TotalSeconds;
            }
        }

        [DataMember(Name ="dueDate")]
        [JsonProperty(PropertyName ="dueDate")]
        public double DueDateUnixtimestamp
        {
            get; set;
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public DateTime DueDate
        {
            get
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(DueDateUnixtimestamp).ToLocalTime();
                return dtDateTime;

            }
            set
            {
                DueDateUnixtimestamp = (value.ToLocalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local)).TotalSeconds;
            }
        }

        public JobGetEntry()
        {
            QueueGroups = new Dictionary<int, string>();
        }
    }
}
