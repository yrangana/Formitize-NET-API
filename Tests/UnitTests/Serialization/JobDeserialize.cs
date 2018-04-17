using NUnit.Framework;
using System;
using Formitize.API.Model;
using Formitize.API.Serialization;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobDeserialize
    {
       
        [Test(Description = "Deserialize from JSON to Job class.")]
        public void deserialize_job()
        {
            var job = JSONMapper.To<Job>("{\"title\":\"test\"}");

            Assert.IsTrue(job.Title == "test", "Deserialize failed.");

        }
    }
}
