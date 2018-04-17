using System;
using Newtonsoft.Json;

namespace Formitize.API.Response
{
    public class JobPost
    {

        [JsonProperty(PropertyName = "jobID")]
        public int JobID 
        {
            get; set;
        }

        [JsonProperty(PropertyName =  "agentID")]
        public String AgentID
        {
            get; set; 
        }


        public JobPost()
        {
        }
    }
}
