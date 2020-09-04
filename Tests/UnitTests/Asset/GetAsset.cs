using NUnit.Framework;
using System.Collections.Generic;
using Formitize.API;
using Formitize.API.Model.Asset;
using Formitize.API.Response.Asset;
using Formitize.API.Response;
using FormitizeHelper = Formitize.API.Helper;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitGetAsset
    {
        [Test(Description = "Get Asset")]
        public async void get_asset()
        {
            var client = new WebClient(Helper.createCredentials());

            var APIResponse = await FormitizeHelper.Asset.GetAsset(client, 360, 546190);

            Assert.IsInstanceOf(typeof(Response<Response<Formitize.API.Response.Asset.AssetResponse>>), APIResponse);
        }

        
    }
}
