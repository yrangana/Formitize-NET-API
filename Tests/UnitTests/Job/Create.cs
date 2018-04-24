using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobCreate
    {
        [Test()]
        public void post_job_create()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Model.Job();

            job.Title = "Test";

            var form = new Formitize.API.Model.JobFormData();

            form.FormID = 10355;
            form.SetValue("0", "clientName", "Test Client")
                .SetValue("0", "clientEmail", "test@test.com")
                .SetValue("0", "businessType", "Option A");

            job.AttachJobForm(form);


            var task = Methods.PostJob(client, job);
            var APIResponse =  task.Result;

            Assert.IsFalse(APIResponse.Payload.JobID == 0, "failed");

            var deleteTask = Methods.DeleteJob(client, APIResponse.Payload.JobID);
            var deleteResponse = deleteTask.Result;

            Assert.AreEqual(deleteResponse.Payload.Message, "Successfully deleted job.");

        }
    }
}
