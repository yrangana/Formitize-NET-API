using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.CMS
{
    public class FormitizeCMSWhere
    {
        public enum SearchType
        {
            Contains = 1,
            Equals = 2,
            NotEquals = 3
        }

        public int ID { get; set;  }
        private Dictionary<string, object> values;


        public FormitizeCMSWhere()
        {
            values = new Dictionary<string, object>();
            ID = 0;
        }

        public Dictionary<string, object> getData()
        {
            values["id"] = ID;
            return values;
        }

        public FormitizeCMSWhere addCriteria(string key, object value, SearchType searchType = SearchType.Equals)
        {
            string search = "equal";
            switch(searchType)
            {
                case SearchType.Equals:
                    search = "equal";
                    break;
                case SearchType.Contains:
                    search = "contain";
                    break;
                case SearchType.NotEquals:
                    search = "notequal";
                    break;
            }

            Dictionary<string, object> newVal = new Dictionary<string, object>();

            newVal["value"] = value;
            newVal["search"] = search;

            values[key] = newVal;

            return this;
        }
    }
}
