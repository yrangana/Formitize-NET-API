using System;
using Newtonsoft.Json;

namespace Formitize.API.Response
{
    public class SubmittedFormPost
    {

        [JsonProperty(PropertyName = "id")]
        public int SubmittedFormID
        {
            get; set;
        }

        public SubmittedFormPost()
        {
        }
    }
}
