using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;
using FormitizeHelper = Formitize.API.Helper;


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
            job.Agent = "-1"; //Assign to Queue (Taxi-Rank style) - Job is free-for-all to pick up by any agent.

            job.Client.BillingName = "Test";

            var contact = new Contact();
            contact.FirstName = "FIRST_NAME";
            contact.LastName = "LAST_NAME";
            contact.Mobile = "0000 000 000";
            contact.Email = "test@test.com";
            contact.CustomFields.Add("Custom_Variable", new CRMVariableField() { Value = "Test" });

            job.Client.ContactList.Add(contact);

            var form = new Formitize.API.Model.JobFormData();

            form.FormID = 10355;
            form.SetValue("0", "clientName", "Test Client")
                .SetValue("0", "clientEmail", "test@test.com")
                .SetValue("0", "businessType", "Option A");

            job.AttachJobForm(form);


            var task = FormitizeHelper.Jobs.PostJob(client, job);
            var APIResponse =  task.Result;

            Assert.IsFalse(APIResponse.Payload.JobID == 0, "failed");

            var deleteTask = FormitizeHelper.Jobs.DeleteJob(client, APIResponse.Payload.JobID);
            var deleteResponse = deleteTask.Result;

            Assert.AreEqual(deleteResponse.Payload.Message, "Successfully deleted job.");

        }
    }
}
