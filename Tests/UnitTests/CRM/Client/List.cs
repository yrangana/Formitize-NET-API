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
    public class NUnitCRMListClients
    {
        [Test(Description = "List Client")]
        public async void get_crm_client_list()
        {
            var client = new WebClient(Helper.createCredentials());


            Response<ClientListResponse> APIResponse = await FormitizeHelper.CRM.ListClients(client);
            Assert.IsInstanceOf(typeof(Response<ClientListResponse>), APIResponse);
        }
    }
}
