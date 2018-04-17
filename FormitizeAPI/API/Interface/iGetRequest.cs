using System;
using System.Collections.Generic;
namespace Formitize.API.Interface
{
    public class iGetRequest
    {
        Dictionary<String, String> SearchHeaders;

        public iGetRequest()
        {
            SearchHeaders = new Dictionary<string, string>();
        }

        public void RemoveHeader(String Key)
        {
            SearchHeaders.Remove(Key);
        }

        public void AddHeader(String Key, String Value)
        {
            SearchHeaders[Key] = Value;
        }

        public String GetHeader(String Key)
        {
            if (!SearchHeaders.ContainsKey(Key))
                return "";

            return SearchHeaders[Key];
        }

        public String GetQuery()
        {
            String query = "";
            if (SearchHeaders.Count != 0)
            {
                String[] str = new string[SearchHeaders.Count];
                int c = 0;
                foreach (KeyValuePair<String, String> entry in SearchHeaders)
                {
                    str[c] = entry.Key + "=" + entry.Value;
                }

                query = "?" + String.Join("&", str);
            }

            return query;

        }

    }
}
