using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class SubmittedForm
    {
        [JsonProperty(PropertyName = "formID")]
        public int FormID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "process")]
        public bool Process
        {
            get; set;
        }

        [JsonProperty(PropertyName = "id")]
        public int SubmittedFormID
        {
            get; set;
        }


        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get; set;
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get; set;
        }

        [JsonProperty(PropertyName = "payload")]
        public Dictionary<string, Dictionary<string, object>> content
        {
            get; private set;
        }

        [JsonProperty(PropertyName = "append")]
        public bool Append
        {
            get; set;
        }

		public SubmittedForm()
		{
            content = new Dictionary<string, Dictionary<string, object>>();
            Title = "";
            Description = "";
        }

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public SubmittedForm SetValue(string index, string objectname, string value)
        {
            if (!content.ContainsKey(objectname))
            {
                content[objectname] = new Dictionary<string, object>();

            }

            content[objectname][index] = value;

            return this;
        }

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public SubmittedForm SetValues(string index, string objectname, params string[] value)
        {
            if (!content.ContainsKey(objectname))
            {
                content[objectname] = new Dictionary<string, object>();

            }

            content[objectname][index] = value;

            return this;
        }

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public SubmittedForm SetValueMultipleChoice(string index, string objectname, params string[] value)
        {
            if (!content.ContainsKey(objectname))
            {
                content[objectname] = new Dictionary<string, object>();

            }

            content[objectname][index] = value;
            return this;
        }
	}
}
