using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job
{
    public class FormitizeCMSEntryPostResponse : Formitize.API.Interface.iPostResponse
    {
        public string getEntryID()
        {
            return resp.ContainsKey("entryID") ? resp["entryID"].ToString() : null;
        }
    }
}
