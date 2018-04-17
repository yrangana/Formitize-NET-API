using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Formitize.API.Model
{
    [DataContract(Namespace = "")]
    public class JobFormData
    {
        [JsonProperty(PropertyName = "formID")]
        public int FormID
        {
            get; set;
        }

        [JsonProperty(PropertyName = "id")]
        public int SubmittedFormID
        {
            get; set;
        }


        [JsonProperty(PropertyName = "content")]
        public Dictionary<string, Dictionary<string, object>> content
        {
            get; private set;
        }


		public JobFormData()
		{
            content = new Dictionary<string, Dictionary<string, object>>();
		}

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public JobFormData SetValue(string index, string objectname, string value)
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
        public JobFormData SetValueMultipleChoice(string index, string objectname, params string[] value)
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
