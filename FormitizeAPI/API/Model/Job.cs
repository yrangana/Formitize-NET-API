using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Formitize.API.Model
{
    [DataContract(Namespace ="")]
    public class Job
    {
        public const string PRIORITY_NORMAL = "Normal";
        public const string PRIORITY_MEDIUM = "Medium";
        public const string PRIORITY_HIGH = "High";
        public const string PRIORITY_URGENT = "Urgent";

        [DataMember(Name = "id")]
        public int ID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "formData")]
        public Dictionary<string, Dictionary<string, Dictionary<string, object>>> FormData
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "title")]
        public string Title
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "jobNumber")]
        public string JobNumber
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "orderNumber")]
        public string OrderNumber
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "notes")]
        public string Notes
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "agent")]
        public string Agent
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "priority")]
        public string Priority
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "location")]
        public string Location
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "sendNotification")]
        public bool SendNotificaiton
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "jobDuration")]
        public float Duration
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false, Name = "dueDate")]
        public DateTime DueDate
        {
            get; set;
        }

        public Job()
        {
            JobNumber = "";
            OrderNumber = "";
            Agent = "";

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
