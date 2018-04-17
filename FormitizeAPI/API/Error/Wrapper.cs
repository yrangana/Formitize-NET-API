using System;
using System.Runtime.Serialization;
using Formitize.API.Error;

namespace Formitize.API.Error
{
    public class Wrapper
    {
        [DataMember(Name = "error")]
        public ErrorMessage Error
        {
            get; set;
        }

        public Wrapper()
        {
        }
    }
}
