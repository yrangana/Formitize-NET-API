using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Response.CRM;
using Formitize.API.Response;

using System.Collections.Generic;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitCRMClientCreate
    {
        [Test(Description = "Put Client")]
        public async void post_crm_client_create()
        {
            var client = new WebClient(Helper.createCredentials());

            var crmClient = new Formitize.API.Model.Client()
            {
                BillingName = "New Test Client",
                ContactList = new List<Formitize.API.Model.Contact>()
                {
                    new Formitize.API.Model.Contact()
                    {
                        FirstName = "Max",
                        LastName = "Power",
                        Mobile = "0410 000 000",
                        MobileAreaCode = "+61",
                        CustomFields = new Dictionary<string, Formitize.API.Model.CRMVariableField>()
                        {
                            ["Website"] = new Formitize.API.Model.CRMVariableField()
                            {
                                Value = "http://mitechnologies.github.io/Formitize-NET-API/"
                            }
                        }
                    }
                },
                LocationList = new List<Formitize.API.Model.Location>()
                {
                    new Formitize.API.Model.Location()
                    {
                        Street1 = "123 Some Street",
                        Postcode = "2000",
                        City = "Sydney",
                        State = "New South Wales",
                        Country = "Australia"
                    }
                }
            };


            var APIResponse = await FormitizeHelper.CRM.PutClient(client, crmClient);


            Assert.IsInstanceOf(typeof(Response<PostCRMClientResponse>), APIResponse);
        }
    }
}
