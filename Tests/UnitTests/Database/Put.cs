using NUnit.Framework;
using System;
using Formitize.API;
using Formitize.API.Model.Database;
using Formitize.API.Response;
using FormitizeHelper = Formitize.API.Helper;
using System.Collections.Generic;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitDatabasePut
    {
        [Test(Description = "Update Database")]
        public async void put_database_entries()
        {
            var client = new WebClient(Helper.createCredentials());
            var job = new Formitize.API.Response.JobRequest();

            var primaryKeys = new List<string>() { "aa" };
            var entries = new List<Entry>() {
                new Entry() {
                    Content = {
                        ["ColumnA"] = "Value 1",
                        ["ColumnB"] = "Value 2",
                        ["ColumnC"] = "Value 3"
                    }
                },
                new Entry() {
                    Content = {
                        ["ColumnA"] = "Person A",
                        ["ColumnB"] = "some description",
                        ["ColumnC"] = "some other value"
                    }
                },
            };

            var APIResponse = await FormitizeHelper.Database.BulkWrite(client, "database_test", entries, primaryKeys );

            Assert.IsInstanceOf(typeof(Response<Formitize.API.Response.Database.ListResponse>), APIResponse);
        }


    }
}
