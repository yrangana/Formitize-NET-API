using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Formitize.API.Serialization
{
    public class JSONMapper
    {
        

        public JSONMapper()
        {
            
        }

        public static T To<T>(string result)
        {
            var item = JsonConvert.DeserializeObject<T>(result);
            return item;
        }

        public static string From<T>(T request)
        {
            return JsonConvert.SerializeObject(request);
        }
    }
}