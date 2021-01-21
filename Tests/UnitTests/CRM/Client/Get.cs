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
    public class NUnitCRMClientGet
    {
        [Test(Description = "Put Client")]
        public async void get_crm_client()
        {
            var client = new WebClient(Helper.createCredentials());

            var APIResponse = await FormitizeHelper.CRM.GetClient(client, 76);


            if(APIResponse.Payload.ID == 1)
            {

            }


            Assert.IsInstanceOf(typeof(Response<Formitize.API.Model.Client>), APIResponse);

            var locations = await APIResponse.Payload.GetLocations(client);

            foreach(var location in locations)
            {
                Console.WriteLine(
                    "ID: {0}\n Street 1: {1}\n Zones: {2}",
                    location.ID,
                    location.Street1,
                    location.Zones.Count
                );
            }

        }
    }
}
