using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

using Formitize.API.Interface;

namespace Formitize.API.Response
{
    public class JobRequest : iGetRequest
    {
        public const int STATUS_CREATED = 1;
        public const int STATUS_ASSIGNED = 2;
        public const int STATUS_ACCEPTED = 3;
        public const int STATUS_FINISHED = 4;
        public const int STATUS_REJECTED = 6;
        public const int STATUS_RESCHEDULED = 8;

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

        public string Status
        {
            get
            {
                return GetHeader("status");
            }
        }

        public void AddStatus(int StatusCode)
        {
            var ret = GetHeader("status");
            var split = ret.Split(',');

            var list = new List<string>(split);
            if(list[0] == "")
            {
                list[0] = StatusCode.ToString();
            }
            else
            {
                list.Add(StatusCode.ToString());
            }

            AddHeader("status", string.Join(",", list));
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
