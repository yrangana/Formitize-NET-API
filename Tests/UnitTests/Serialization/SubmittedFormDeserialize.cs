using NUnit.Framework;
using System;
using Formitize.API.Model;
using Formitize.API.Serialization;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitSubmittedFormDeserialize
    {
       
        [Test(Description = "Deserialize from JSON to FormSubmit class.")]
        public void deserialize_submitted_form()
        {
            var submittedForm = JSONMapper.To<Formitize.API.Response.SubmittedFormGetEntry>(@"{""submittedFormID"":""1164203"",""jobID"":""0"",""formID"":""10355"",""userID"":""6065"",""userName"":""admin"",""count"":false,""version"":""2"",""title"":""API Test Demo Form"",""formDateCreated"":""1523935663"",""latitude"":false,""longitude"":false,""location"":false,""content"":{""subheaderDetails"":{""0"":{""id"":2,""type"":""formSubheader"",""name"":""subheaderDetails"",""children"":{""clientName"":{""id"":3,""type"":""formText"",""name"":""clientName"",""value"":""Test""},""clientEmail"":{""id"":4,""type"":""formText"",""name"":""clientEmail"",""value"":""test@test.com""},""businessType"":{""id"":5,""type"":""formMultiple"",""name"":""businessType"",""value"":{""0"":""Option A""}}}}},""subheaderFieldTest"":{""0"":{""id"":6,""type"":""formSubheader"",""name"":""subheaderFieldTest"",""children"":{""formDate_1"":{""id"":7,""type"":""formText"",""name"":""formDate_1"",""value"":""30 Apr 2018""},""formLocation_1"":{""id"":8,""type"":""formText"",""name"":""formLocation_1"",""value"":""111 222 333 444""},""formCheckbox_1"":{""id"":9,""type"":""formMultiple"",""name"":""formCheckbox_1"",""value"":{}}}}}},""attachments"":{""0"":{""url"":""http:\/\/localhost:8888\/formitize\/home\/service\/file\/hash\/report\/9264f92d8e781aa13d129ec5a8011d89"",""type"":""pdf"",""name"":""Default""}}}");

            var email = submittedForm.GetTextValue("0", "clientEmail");
            Assert.AreEqual(email, "test@test.com");
            var client = submittedForm.GetTextValue("0", "clientName");
            Assert.AreEqual(client, "Test");
        }
    }
}
