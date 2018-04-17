using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Formitize.API.Response
{
    
    public class SubmittedFormContent
    {
        [JsonProperty(PropertyName = "content")]
        public JObject Content
        {
            get; set;
        }

        public string GetTextValue(string index, string Objectname)
        {
            foreach(JToken token in Content.SelectTokens("*." + index + ".*.*.name"))
            {
                if (token.ToString() == Objectname)
                {
                    var par = token.Parent.Parent.SelectToken("value");
                    if (par == null) return "";
                       
                    return par.Value<string>();

                }
            }

            return "";
        }
	}
}
