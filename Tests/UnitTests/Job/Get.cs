using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobGet
    {
        [Test()]
        public void post_job_get()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Model.Job();

            job.Title = "Test";
            job.DueDate = DateTime.Now;
            job.QueueGroups.Add("Main");

            var form = new Formitize.API.Model.JobFormData();

            form.FormID = 10355;
            form.SetValue("0", "clientName", "Test Client")
                .SetValue("0", "clientEmail", "test@test.com")
                .SetValue("0", "businessType", "Option A");

            job.AttachJobForm(form);


            var task = FormitizeHelper.Jobs.PostJob(client, job);
            var Response =  task.Result;

            Assert.IsFalse(Response.Payload.JobID == 0, "failed");

            var getTask = FormitizeHelper.Jobs.GetJob(client, Response.Payload.JobID);
            var getResponse = getTask.Result;

            Assert.AreEqual(getResponse.Payload.JobID, Response.Payload.JobID);

            var deleteTask = FormitizeHelper.Jobs.DeleteJob(client, Response.Payload.JobID);
            var deleteResponse = deleteTask.Result;

            Assert.AreEqual(deleteResponse.Payload.Message, "Successfully deleted job.");

        }
    }
}
