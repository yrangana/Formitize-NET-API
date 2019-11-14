using System;
using System.Runtime.Serialization;
using Formitize.API.Interface;

namespace Formitize.API.Response
{
    public class SubmittedFormRequest : iGetRequest
    {

        public string Query
        {
            get
            {

                var ret = GetHeader("query");
                if (ret == "") return "";
                return ret;
            }
            set
            {
                AddHeader("query", value);
            }
        }

        public int SubmittedID 
        {
            get
            {
                var ret = GetHeader("id");
                if (ret == "") return 0;
                return int.Parse(ret);
            }
            set
            {
                AddHeader("id", value.ToString());
            }
        }

        public SubmittedFormRequest()
        {
        }
    }
}
