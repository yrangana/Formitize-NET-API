using System;
using Formitize.API.Response;
using Formitize.API.Model;
using Formitize.API.Serialization;

using System.Threading.Tasks;

namespace Formitize.API.Helper
{
    public class Jobs
    {

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<JobGetList>> GetJobList(WebClient client, JobRequest job)
        {
            return JSONMapper.To<Response<JobGetList>>((String)(await client.GetAsync<JobRequest>("job/", job)));
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<JobGetEntry>> GetJob(WebClient client, int jobID)
        {
            JobRequest jobRequest = new JobRequest();
            jobRequest.JobID = jobID;
            return JSONMapper.To<Response<JobGetEntry>>((String)(await client.GetAsync<JobRequest>("job/", jobRequest)));
        } 
        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<JobPost>> PostJob(WebClient client, Job job) 
        {
            return JSONMapper.To<Response<JobPost>>((String)(await client.PostAsync<Job>("job/", job)));
        }

        public static async Task<Response<JobDelete>> DeleteJob(WebClient client, int jobID)
        {
            JobRequest jobRequest = new JobRequest();
            jobRequest.JobID = jobID;
            return JSONMapper.To<Response<JobDelete>>((String)(await client.DeleteAsync<JobRequest>("job/", jobRequest)));
        }
    }
}
