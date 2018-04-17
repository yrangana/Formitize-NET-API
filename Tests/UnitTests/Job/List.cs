using NUnit.Framework;
using System;
using Formitize.API;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobList
    {
        [Test(Description = "Get Job List")]
        public async void get_job_list()
        {
            var client = new Client(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            var Response = await Methods.GetJobList(client, job);

            Assert.IsInstanceOf(typeof(Formitize.API.Response.JobGetList), Response);
        }

        [Test(Description = "Get Job List Bad Credentrials")]
        public async void get_job_list_bad_credentials()
        {
            var client = new Client(Helper.createBadCredentials());
            var job = new Formitize.API.Response.JobRequest();

            try
            {
                var Response = await Methods.GetJobList(client, job);
                Assert.IsInstanceOf(typeof(Formitize.API.Response.JobGetList), Response);
            }
            catch(Formitize.API.Error.APIException Exception)
            {
                Assert.AreEqual(Exception.StatusCode, System.Net.HttpStatusCode.Unauthorized, "Unexpected Response Code.");
            }
        }
    }
}
