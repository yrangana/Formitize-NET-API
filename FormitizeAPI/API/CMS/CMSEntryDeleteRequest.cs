using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.CMS
{
    public class FormitizeCMSEntryDeleteRequest : Formitize.API.Interface.iDeleteRequest
    {
        public string Table { get; set;  }
        private FormitizeCMSWhere where;

        public FormitizeCMSEntryDeleteRequest()
        {
            where = new FormitizeCMSWhere();

        }

        public void setWhere(FormitizeCMSWhere w)
        {
            where = w;
        }

        public FormitizeCMSWhere getWhere()
        {

            return where;
        }


        public FormitizeCMSWhere addCriteria(string key, object value, FormitizeCMSWhere.SearchType searchType = FormitizeCMSWhere.SearchType.Equals)
        {
            return where.addCriteria(key, value, searchType);
        }

        public override string getURL()
        {

            List<String> str = new List<String>();

            
            foreach(KeyValuePair<string, object> kvp in where.getData())
            {
                if (kvp.Key == "id")
                {
                    if(kvp.Value.ToString() != "0")
                        str.Add(String.Format("id={0}", kvp.Value.ToString()));
                }
                else
                {
                    Dictionary<string, object> kvpEntry = (Dictionary<string, object>)kvp.Value;
                    str.Add( System.Uri.EscapeDataString( String.Format( "where[{0}][value]={1}&where[{0}][search]={2}", kvp.Key, kvpEntry["value"].ToString(), kvpEntry["search"].ToString()) ));
                }

            }




            return "cms/" + Table + "/entry/?" +  String.Join("&", str.ToArray());
        }
    }
}
