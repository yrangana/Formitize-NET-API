using System;
using System.Runtime.Serialization;

namespace Formitize.API.Response
{
    public class JobPost
    {

        [DataMember(Name = "jobID")]
        public int JobID 
        {
            get; set;
        }

        [DataMember(Name = "agentID")]
        public String AgentID
        {
            get; set; 
        }


        public JobPost()
        {
        }
    }
}
