using NUnit.Framework;
using System.Collections.Generic;
using Formitize.API;
using Formitize.API.Model.Asset.Schema;
using Formitize.API.Response.Asset;
using Formitize.API.Response;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitGetSchema
    {
        [Test(Description = "Get Schema List")]
        public async void get_schema()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            var APIResponse = await FormitizeHelper.Asset.GetSchema(client, 360);

            Assert.IsInstanceOf(typeof(Response<Schema>), APIResponse);
        }


    }
}
