using System;
using System.Collections.Generic;
using System.Text;
using Formitize.API.Job.Response;

namespace Formitize.API.Job
{
    public class FormitizeJobGetResponse : Formitize.API.Interface.iGetResponse
    {
        public int[] getIDList()
        {
            int[] ids = new int[resp.Count];
            int c = 0;

            foreach( var key in resp.Keys)
            {
                ids[c++] = int.Parse(key);

            }

            return ids;
        }

        public Response.FormitizeJobEntry[] getAllJobs()
        {
            FormitizeJobEntry[] list = new FormitizeJobEntry[resp.Count];


            var c = 0;

            foreach( var entry in getIDList() )
            {
                list[c++] = getJob(entry);
            }

            return list;

        }

        public Response.FormitizeJobEntry getJob(int jobID)
        {
            if(resp.ContainsKey(jobID.ToString()))
            {
                return new FormitizeJobEntry((Dictionary<string, object>)resp[jobID.ToString()]);
            }

            return null;
        }
    }
}
