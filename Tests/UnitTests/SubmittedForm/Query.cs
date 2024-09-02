using NUnit.Framework;
using System;
using Formitize.API;
using FormitizeHelper = Formitize.API.Helper;

using Formitize.API.Model;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitSubmittedFormQuery
    {
        [Test()]
        public void query_for_id()
        {

            var client = new WebClient(Helper.createCredentials());

            var getTask = FormitizeHelper.SubmittedForms.QueryForSubmittedForm(client, "Your Value", lastModified: DateTime.Now.AddDays(-14));
            var getResponse = getTask.Result;

            foreach (var item in getResponse.Payload)
            {
                System.Console.WriteLine(
                    item.Value.SubmittedFormID
                );

                //if we then want to get the submitted form data.
                //var getSubmittedFormTask = Methods.GetSubmittedForm(client, item.Value.SubmittedFormID);
                //var submittedFormData = getSubmittedFormTask.Result;

            }


            /*
            var getTask = Methods.GetSubmittedForm(client, 1164203);
            var getResponse = getTask.Result;

            Assert.AreEqual(getResponse.SubmittedFormID, 1164203);
            */

        }
    }
}
