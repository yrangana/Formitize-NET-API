using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;
using Formitize.API.Response;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobList
    {
        [Test(Description = "Get Job List")]
        public async void get_job_list()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            var APIResponse = await FormitizeHelper.Jobs.GetJobList(client, job);

            Assert.IsInstanceOf(typeof(Response<JobGetList>), APIResponse);
        }

        [Test(Description = "Get Only Completed Jobs")]
        public async void get_completed_job_list()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            job.AddStatus(JobRequest.STATUS_FINISHED);

            var APIResponse = await FormitizeHelper.Jobs.GetJobList(client, job);

            Assert.IsInstanceOf(typeof(Response<JobGetList>), APIResponse);
        }

        [Test(Description = "Get Job List Bad Credentrials")]
        public async void get_job_list_bad_credentials()
        {
            var client = new WebClient(Helper.createBadCredentials());
            var job = new Formitize.API.Response.JobRequest();

            job.AddStatus(Formitize.API.Response.JobRequest.STATUS_FINISHED);

            try
            {
                var APIResponse = await FormitizeHelper.Jobs.GetJobList(client, job);
                Assert.IsInstanceOf(typeof(Response<JobGetList>), APIResponse);
            }
            catch(Formitize.API.Error.APIException Exception)
            {
                Assert.AreEqual(Exception.StatusCode, System.Net.HttpStatusCode.Unauthorized, "Unexpected Response Code.");
            }
        }
    }
}
