using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formitize.API.Interface
{
    public class iDeleteResponse
    {

        internal Dictionary<string, object> resp;

        public iDeleteResponse()
        {
            resp = new Dictionary<string, object>();
        }

        virtual public void passRawJSON(string json)
        {
            resp = Method.Helper.JSONStringToDict(json);
        }

        virtual public string getErrorMessage()
        {
            if(resp.ContainsKey("error"))
            {
                return ((Dictionary<string, object>)resp["error"])["message"].ToString();
            }

            return null;
        }

        virtual public string getErrorCode()
        {
            if(resp.ContainsKey("error"))
            {
                return ((Dictionary<string, object>)resp["error"])["code"].ToString();
            }

            return null;
        }

        virtual public bool hasError()
        {
            return resp.ContainsKey("error");
        }


        public static T createObjectFromJSON<T>(string json) where T : iDeleteResponse, new()
        {
            T t = new T();


            t.passRawJSON(json);

            return t;
        }
    }
}
