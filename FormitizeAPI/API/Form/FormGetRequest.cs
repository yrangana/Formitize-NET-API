using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form
{
    public class FormitizeFormGetRequest : Formitize.API.Interface.iGetRequest
    {
        public bool SimpleMode
        {
            get; set;
        }

        
		public bool OrderByLastModified
        {
			get; set;
        }

		public int FormID 
		{
			get;
			set; 
		}

		public FormitizeFormGetRequest()
		{
			SimpleMode = false;
			OrderByLastModified = false;
			FormID = 0;
		}

        public override string getURL()
        {
			List<string> str = new List<string>();

			if (SimpleMode)
				str.Add("simple=true");

			if (OrderByLastModified)
				str.Add("orderByLastModified=true");


			if (FormID != 0) {
				return "form/" + FormID.ToString() + "/?" + String.Join("&", str);
			}
			else
	            return "form/all/?" + String.Join("&", str);
        }
    }
}
