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
    public class NUnitGetSchemaList
    {
        [Test(Description = "Get Schema List")]
        public async void get_schema_list()
        {
            var client = new WebClient(Helper.createCredentials());

            var APIResponse = await FormitizeHelper.Asset.GetAssetSchemaList(client);

            Assert.IsInstanceOf(typeof(Response<Schemas>), APIResponse);
        }


    }
}
