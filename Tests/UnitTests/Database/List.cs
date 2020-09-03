using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model;
using Formitize.API.Response;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitDatabaseList
    {
        [Test(Description = "Get Database List")]
        public async void get_database_list()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            var APIResponse = await FormitizeHelper.Database.GetDatabaseList(client);

            Assert.IsInstanceOf(typeof(Response<Formitize.API.Response.Database.ListResponse>), APIResponse);
        }


    }
}
