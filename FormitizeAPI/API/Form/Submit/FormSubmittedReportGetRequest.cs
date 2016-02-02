using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form.Submit
{
	

	public class FormitizeFormSubmittedReportGetRequest : Formitize.API.Interface.iGetRequest
    {

		private int _SubmittedID;
		private string _Report;

		public FormitizeFormSubmittedReportGetRequest(int SubmittedID)
		{
			_SubmittedID = SubmittedID;
			_Report = "";
		}



		public FormitizeFormSubmittedReportGetRequest(int SubmittedID, string Report)
		{
			_SubmittedID = SubmittedID;
			_Report = Report;
		}



        public override string getURL()
        {
			List<string> str = new List<string>();

			str.Add ("id=" + _SubmittedID.ToString());

			if(_Report != "") str.Add ("report=" + _Report);

			return "form/submit/report/?" + String.Join("&", str);
        }


    }
}
