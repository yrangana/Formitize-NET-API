using System;
using System.Runtime.Serialization;

namespace Formitize.API.Error
{
    public class ErrorMessage
    {

        [DataMember(Name = "message")]
        public String Message
        {
            get; set;
        }

        [DataMember(Name = "timestamp")]
        public int Timestamp
        {
            get; set;
        }

        [DataMember(Name = "code")]
        public int Code
        {
            get; set;
        }

        public ErrorMessage()
        {
        }
    }
}
