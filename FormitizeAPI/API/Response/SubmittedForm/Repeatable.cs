using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Formitize.API.Response.SubmittedForm
{
    public class Repeatable
    {
        [JsonProperty(PropertyName = "content")]
        public JContainer Content
        {
            get; set;
        }

        public Repeatable(JContainer container)
        {
            Content = container;
        }

        public List<Row> GetRows()
        {
            var response = new List<Row>();

            foreach (var token in Content.SelectTokens("children.*"))
            {
                response.Add(new Row(token));
            }

            return response;
        }
    }
}
