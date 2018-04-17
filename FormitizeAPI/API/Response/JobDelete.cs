using System;
using System.Runtime.Serialization;

namespace Formitize.API.Response
{
    public class JobDelete
    {

        [DataMember(Name = "id")]
        public int JobID 
        {
            get; set;
        }

        [DataMember(Name = "message")]
        public String Message
        {
            get; set; 
        }


        public JobDelete()
        {
        }
    }
}
