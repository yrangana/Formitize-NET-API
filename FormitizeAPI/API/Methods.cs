using System;
using Formitize.API.Response;
using Formitize.API.Model;
using Formitize.API.Serialization;

using System.Threading.Tasks;

namespace Formitize.API
{
    public class Methods
    {

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<JobGetList> GetJobList(Client client, JobRequest job)
        {
            JobGetList list = JSONMapper.To<JobGetList>((String)(await client.GetAsync<JobRequest>("job/", job)));

            return list;
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<JobGetEntry> GetJob(Client client, int jobID)
        {
            JobRequest jobRequest = new JobRequest();
            jobRequest.JobID = jobID;
            return JSONMapper.To<JobGetEntry>((String)(await client.GetAsync<JobRequest>("job/", jobRequest)));
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<SubmittedFormGetEntry> GetSubmittedForm(Client client, int submittedID)
        {
            SubmittedFormRequest jobRequest = new SubmittedFormRequest();
            jobRequest.SubmittedID = submittedID;
            return JSONMapper.To<SubmittedFormGetEntry>((String)(await client.GetAsync<SubmittedFormRequest>("form/submit/", jobRequest)));
        }



        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<JobPost> PostJob(Client client, Job job) 
        {
            return JSONMapper.To<JobPost>((String)(await client.PostAsync<Job>("job/", job)));
        }

        public static async Task<JobDelete> DeleteJob(Client client, int jobID)
        {
            JobRequest jobRequest = new JobRequest();
            jobRequest.JobID = jobID;
            return JSONMapper.To<JobDelete>((String)(await client.DeleteAsync<JobRequest>("job/", jobRequest)));
        }
    }
}
