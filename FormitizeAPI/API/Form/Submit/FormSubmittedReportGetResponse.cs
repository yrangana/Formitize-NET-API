using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form.Submit
{
	using ReportList = Dictionary<int, FormitizeFormSubmittedReportContainer>;

	public class FormitizeFormSubmittedReportContainer
	{
		public List<FormitizeFormSubmittedReportEntry> ReportList
		{
			get;
		}

		public void Add(FormitizeFormSubmittedReportEntry entry)
		{
			ReportList.Add (entry);
		}

		public FormitizeFormSubmittedReportContainer()
		{
			ReportList = new List<FormitizeFormSubmittedReportEntry>();
		}

	}

	public class FormitizeFormSubmittedReportEntry
	{
		public string URL
		{
			get; 
		}

		public string Title
		{
			get;
		}

		public FormitizeFormSubmittedReportEntry(string url, string title)
		{
			URL = url;
			Title = title;
		}
	}


	public class FormitizeFormSubmittedReportGetResponse : Formitize.API.Interface.iGetResponse
    {
		
		public ReportList GetReports()
		{
			Dictionary<int, FormitizeFormSubmittedReportContainer> dict = new Dictionary<int, FormitizeFormSubmittedReportContainer>();


			foreach (var key in resp.Keys) {

				System.Collections.ArrayList obj = (System.Collections.ArrayList)resp [key];

				FormitizeFormSubmittedReportContainer cont = new FormitizeFormSubmittedReportContainer ();

				foreach (Dictionary<string, object> entry in obj) {
					cont.Add(new FormitizeFormSubmittedReportEntry (entry ["url"].ToString(), entry ["title"].ToString()));
				}

				dict [Convert.ToInt32 (key)] = cont;
			}

			return dict;
		}
	



    }
}
