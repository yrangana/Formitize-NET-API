using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job
{
    public class FormitizeJobForm
    {
        private Dictionary<string, Dictionary<string, object>> content;

        public int FormID
        {
            get; set;
        }

        public FormitizeJobForm()
        {
            content = new Dictionary<string, Dictionary<string, object>>();

        }

        public Dictionary<string, Dictionary<string, object>> prepareForJobSubmission()
        {
            return content;
        }

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public FormitizeJobForm setValue(int index, string objectname, string value)
        {
            if(!content.ContainsKey(objectname))
            {
                content[objectname] = new Dictionary<string, object>();

            }

            content[objectname][index.ToString()] = value;

            return this;
        }

        /**
            param name="index" sets the current index, use 1,2,3,4,5 etc for further repeated entries.
        */
        public FormitizeJobForm setValueMultipleChoice(int index, string objectname, params string[] value)
        {
            if (!content.ContainsKey(objectname))
            {
                content[objectname] = new Dictionary<string, object>();

            }

            content[objectname][index.ToString()] = value;
            return this;
        }
    }
}
