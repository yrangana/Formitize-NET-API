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
    public class NUnitPutAsset
    {
        [Test(Description = "Put Asset")]
        public async void put_asset()
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

            var assetData = new Asset()
            {
                ID = 546190,
                Content = new Dictionary<string, string>()
                {
                    ["FieldA"] = "Test-1234",
                    ["FieldB"] = "Kitchen",
                    ["FieldC"] = "Sink"
                },
                NewClient = crmClient
            };

            var APIResponse = await FormitizeHelper.Asset.PutAsset(client, 360, assetData);



            Assert.IsInstanceOf(typeof(Response<Response<AssetListResponse>>), APIResponse);
        }


    }
}
