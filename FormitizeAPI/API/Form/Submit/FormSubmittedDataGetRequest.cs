using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form.Submit
{
	

	public class FormitizeFormSubmittedDataGetRequest : Formitize.API.Interface.iGetRequest
    {
		private List<int> SubmittedIDs;

		public void AddSubmittedID(int ID)
		{
			SubmittedIDs.Add (ID);
		}


		public FormitizeFormSubmittedDataGetRequest()
		{
			SubmittedIDs = new List<int> ();
		}

        public override string getURL()
        {
			List<string> str = new List<string>();

			if (SubmittedIDs.Count > 0) {
				str.Add ("id=" + String.Join (",", SubmittedIDs));
			}

			if (SubmittedIDs.Count == 0) {
				throw new Exception ("Please add a Submitted ID via AddSubmittedID function for this request..");
			}

			return "form/submit/?" + String.Join("&", str);
        }


    }
}
