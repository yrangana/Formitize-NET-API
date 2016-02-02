using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formitize.API.Job
{
    public class FormitizeJob : Formitize.API.Interface.iPostRequest
    {
        public const string PRIORITY_NORMAL = "Normal";
        public const string PRIORITY_MEDIUM = "Medium";
        public const string PRIORITY_HIGH = "High";
        public const string PRIORITY_URGENT = "Urgent";

        public int ID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string JobNumber
        {
            get; set;
        }
	    public string OrderNumber
        {
            get; set;
        }
	    public string Notes
        {
            get; set;
        }

	    public string Agent
        {
            get; set;
        }

	    public string Priority
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }

	    public bool SendNotificaiton
        {
            get; set;
        }

        public float Duration
        {
            get; set;
        }

        public double DueDate
        {
            get; set;
        }

        public void setDueDateFromDate(DateTime dt)
        {
            DueDate = (dt - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }

        public FormitizeJob()
        {
            JobNumber = "";
            OrderNumber = "";
            Agent = "";


            SendNotificaiton = true;
            Priority = PRIORITY_NORMAL;
            Forms = new System.Collections.Generic.Dictionary<string, object>();
            AttachedForms = new Dictionary<string, FormitizeJobForm>();
        }

        private Dictionary<string, object> Forms;

        private Dictionary<string, FormitizeJobForm> AttachedForms;


        public void AttachJobForm(ref FormitizeJobForm form)
        {
            AttachedForms[form.FormID.ToString()] = form;
        }

        public string getURL()
        {
            return "job/";
        }

        /**
            summary
                This will return a parsed JSON string of 
        */
        public string getData()
        {

            Dictionary<string, object> obj = new Dictionary<string, object>();

            obj["id"] = this.ID.ToString();
            obj["title"] = this.Title;
            obj["jobNumber"] = this.JobNumber;
            obj["orderNumber"] = this.OrderNumber;
            obj["agent"] = this.Agent;
            obj["sendNotification"] = this.SendNotificaiton.ToString();
            obj["priority"] = this.Priority;
            obj["notes"] = this.Notes;

            Dictionary<string, object> entries = new Dictionary<string, object>();

            foreach(KeyValuePair<String, FormitizeJobForm> entry in this.AttachedForms)
            {
                Forms[entry.Key] = entry.Key;
                entries[entry.Key] = entry.Value.prepareForJobSubmission();
            }
            obj["form"] = Forms;
            obj["formData"] = entries;

            obj["dueDate"] = this.DueDate.ToString();
            obj["duration"] = this.Duration.ToString();

            return Formitize.API.Method.Helper.DictToJSONString(ref obj);

        }

    }
}
