using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job
{
    public class FormitizeJobGetRequest : Formitize.API.Interface.iGetRequest
    {
        public string AgentName
        {
            get; set;
        }
        
        public FormitizeJobGetRequest()
        {
            AgentName = "";
        }

        public override string getURL()
        {
			List<string> str = new List<string>();


            if (!AgentName.Equals(""))
                str.Add("AgentName=" + AgentName);


            return "job/?" + String.Join("&", str);
        }
    }
}
