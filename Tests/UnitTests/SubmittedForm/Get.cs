using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitSubmittedFormGet
    {
        [Test()]
        public void submitted_form_get()
        {
            /**
             * This test is ideally for localhost.
             */

            var client = new WebClient(Helper.createCredentials());
            var getTask = FormitizeHelper.SubmittedForms.GetSubmittedForm(client, 104);
            var getResponse = getTask.Result;
            var form = new Formitize.API.Model.SubmittedForm(getResponse.Payload);

            Assert.AreEqual(getResponse.Payload.SubmittedFormID, 104);

        }
    }
}
