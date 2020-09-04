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
    public class NUnitGetAssetList
    {
        [Test(Description = "Get Asset List")]
        public async void get_asset_list()
        {
            var client = new WebClient(Helper.createCredentials());

            var APIResponse = await FormitizeHelper.Asset.GetAssetList(client, 360);
        
            Assert.IsInstanceOf(typeof(Response<AssetListResponse>), APIResponse);
        }


    }
}
