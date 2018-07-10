using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace ="")]
    public class Job
    {
        public const string PRIORITY_NORMAL = "Normal";
        public const string PRIORITY_MEDIUM = "Medium";
        public const string PRIORITY_HIGH = "High";
        public const string PRIORITY_URGENT = "Urgent";

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "formData")]
        public Dictionary<string, Dictionary<string, Dictionary<string, object>>> FormData
        {
            get; set;
        }

        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get; set;
        }

        [JsonProperty(PropertyName = "jobType")]
        public string JobType
        {
            get; set;
        }

        [JsonProperty(PropertyName = "jobNumber")]
        public string JobNumber
        {
            get; set;
        }

        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber
        {
            get; set;
        }

        [JsonProperty(PropertyName =  "notes")]
        public string Notes
        {
            get; set;
        }

        [JsonProperty(PropertyName =  "agent")]
        public string Agent
        {
            get; set;
        }

        [JsonProperty(PropertyName = "priority")]
        public string Priority
        {
            get; set;
        }

        [JsonProperty(PropertyName =  "location")]
        public string Location
        {
            get; set;
        }

        [JsonProperty(PropertyName = "sendNotification")]
        public bool SendNotificaiton
        {
            get; set;
        }

        [JsonProperty(PropertyName = "jobDuration")]
        public float Duration
        {
            get; set;
        }

        [DataMember(Name = "dueDate")]
        [JsonProperty(PropertyName = "dueDate")]
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
                DueDateUnixtimestamp = (value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            }
        }

        public Job()
        {
            JobNumber = "";
            OrderNumber = "";
            Agent = "";
            DueDateUnixtimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            FormData = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>();

            SendNotificaiton = true;
            Priority = PRIORITY_NORMAL;            
        }

        public void AttachJobForm(JobFormData form)
        {
            FormData[form.FormID.ToString()] = form.content;
        }

    }
}
