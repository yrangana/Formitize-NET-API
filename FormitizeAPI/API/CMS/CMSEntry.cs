using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.CMS
{
    class FormitizeCMSEntry : Formitize.API.Interface.iPostRequest
    {
        Dictionary<string, object> entry;
        private FormitizeCMSWhere where;

        public string Table { set; get; }

        public bool CreateIfCantFindWhere { set; get;  }


        public string getURL()
        {
            return "cms/" + Table + "/entry/";
        }

        public string getData()
        {
            Dictionary<string, object> obj = new Dictionary<string, object>();

            obj["data"] = entry;
            obj["createIfCantFindWhere"] = CreateIfCantFindWhere;
            obj["where"] = this.where.getData();

            if (this.where.getData().Count == 0)
                obj["createIfCantFindWhere"] = true;

            return Formitize.API.Method.Helper.DictToJSONString(ref obj);
        }

        public FormitizeCMSEntry()
        {
            where = new FormitizeCMSWhere();
            entry = new Dictionary<string, object>();
            CreateIfCantFindWhere = true;
        }

        public void setWhere(FormitizeCMSWhere where)
        {
            this.where = where;
        }

        public FormitizeCMSWhere addCriteria(string key, object value, FormitizeCMSWhere.SearchType searchType = FormitizeCMSWhere.SearchType.Equals)
        {
            return where.addCriteria(key, value, searchType);
        }

        public FormitizeCMSEntry setValue(string key, string val)
        {
            entry[key] = val;
            return this;

        }

        public FormitizeCMSEntry setValue(string key, object val)
        {
            entry[key] = val;

            return this;

        }


        public FormitizeCMSWhere getWhere()
        {

            return where;
        }
    }
}
