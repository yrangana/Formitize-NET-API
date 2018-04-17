using NUnit.Framework;
using System;
using Formitize.API.Model;
using Formitize.API.Serialization;

namespace Tests.UnitTests
{
    [TestFixture()]
    public class NUnitJobSerialize
    {
        [Test(Description = "Test if Job can Serialize into JSON")]
        public void serialize_job()
        {
            var job = new Job();

            job.Title = "Test";
            job.Duration = 60;
            job.Agent = "Test";

            var result = JSONMapper.From<Job>(job);

            Assert.IsFalse(result == "", "JSON Failed to serialize.");

        }

        [Test(Description = "Test if Job can Serialize into JSON with a Form Attached.")]
        public void serialize_job_with_form_attached()
        {
            var job = new Job();
            var form = new JobFormData();


            job.Title = "Test";
            job.Duration = 60;
            job.Agent = "Test";


            form.SetValue("0", "Test", "Test Value");
            form.FormID = 500;

            job.AttachJobForm(form);

            var result = JSONMapper.From<Job>(job);

            Assert.IsFalse(result == "", "JSON Failed to serialize.");
        }

    }
}
