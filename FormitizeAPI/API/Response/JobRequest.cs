using System;
using System.Runtime.Serialization;
using Formitize.API.Interface;

namespace Formitize.API.Response
{
    public class JobRequest : iGetRequest
    {

        public int JobID 
        {
            get
            {
                var ret = GetHeader("id");
                if (ret == "") return 0;
                return int.Parse(ret);
            }
            set
            {
                AddHeader("id", value.ToString());
            }
        }

        public String AgentName
        {
            get
            {
                return GetHeader("AgentName");
            }
            set
            {
                AddHeader("AgentName", value);
            }
        }


        public JobRequest()
        {
        }
    }
}
