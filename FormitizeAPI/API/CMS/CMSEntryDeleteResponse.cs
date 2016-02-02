using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Job
{
    public class FormitizeCMSEntryDeleteResponse : Formitize.API.Interface.iDeleteResponse
    {
        public string getDeletedRowsCount()
        {
            return resp.ContainsKey("deletedRows") ? resp["deletedRows"].ToString() : null;
        }
    }
}
