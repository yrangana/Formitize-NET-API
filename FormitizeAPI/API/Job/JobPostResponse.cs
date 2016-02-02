using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job
{
    public class FormitizeJobPostResponse : Formitize.API.Interface.iPostResponse
    {
        public string getJobID()
        {
            return resp.ContainsKey("jobID") ? resp["jobID"].ToString() : null;
        }

        public string getAgentID()
        {
            return resp.ContainsKey("agentID") ? resp["agentID"].ToString() : null;
        }
    }
}
