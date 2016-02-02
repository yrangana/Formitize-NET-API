using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;


namespace Formitize.API.Method
{
    static class Helper
    {
        public static string DictToJSONString(ref Dictionary<string, object> Dict)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize((object)Dict);
            }
            catch
            {
                return null;
            }
        }

        public static Dictionary<string, object> JSONStringToDict(string RawJson)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                return serializer.Deserialize<Dictionary<string, object>>(RawJson);
            }
            catch
            {
                return null;
            }

        }
    }
}
