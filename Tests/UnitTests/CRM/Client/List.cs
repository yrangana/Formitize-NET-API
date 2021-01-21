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

            var locations = await APIResponse.Payload[76].GetLocations(client);

            foreach (var location in locations)
            {
                System.Console.WriteLine(
                    "ID: {0}\n Street1: {1}\n Street2: {2}\n City: \nPostcode: {4}\nCountry: {5}\nZones: {6}",
                    location.ID,
                    location.Street1,
                    location.Street2,
                    location.City,
                    location.Postcode,
                    location.Country,
                    location.Zones.Count
                );

            }

        }
    }
}
