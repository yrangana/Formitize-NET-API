using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job.Response
{
    public class FormitizeJobEntry
    {

        private Dictionary<string, object> data;

        public int ID
        {
            get { return int.Parse(data["id"].ToString()); }
        }

        public int MaintenanceID
        {
            get { return int.Parse(data["maintenanceID"].ToString());  }
        }

        public string Title
        {
            get { return data["title"].ToString(); }
        }

        public string JobNumber
        {
            get { return data["jobNumber"].ToString(); }
        }

        public string OrderNumber
        {
            get { return data["orderNumber"].ToString(); }
        }

        public string Location
        {
            get { return data["location"].ToString(); }
        }

        public int agentID
        {
            get { return int.Parse(data["assignedTo"].ToString()); }
        }

        public FormitizeJobEntry(Dictionary<string, object> refs)
        {
            this.data = refs;
        }
    }
}
