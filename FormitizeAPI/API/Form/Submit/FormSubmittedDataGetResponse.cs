using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form.Submit
{
	public class FormitizeFormSubmittedDataContent
	{
		private Dictionary<string, object> _data;

		public FormitizeFormSubmittedDataContent(Dictionary<string, object> data)
		{
			_data = data;
		}

		public List<string> GetMultipleValue()
		{
			var l = new List<string> ();

			switch (_data ["type"].ToString()) 
			{
			case "formText":
			case "formBarcode":
			case "formCalculate":
				l.Add(_data ["value"].ToString ());
				break;
			case "formMultiple":
				Dictionary<string, object> o = (Dictionary<string,object>)_data ["value"];

				foreach(var i in o)
				{
					l.Add(i.Value.ToString());	
				}


				break;
			}

			return l;

		}

		public string GetStringValue()
		{
			switch (_data ["type"].ToString()) 
			{
				case "formText":
				case "formBarcode":
				case "formCalculate":
					return _data ["value"].ToString ();
					break;
				case "formMultiple":
					Dictionary<string, object> o = (Dictionary<string,object>)_data ["value"];

					List<string> item = new List<string>();

					foreach(var i in o)
					{
						item.Add(i.Value.ToString());	
					}

					return String.Join(",", item);

					break;
			}

			return null;
		}

	}

	public class FormitizeFormSubmittedDataSubheader
	{
		private Dictionary<string, object> _data;

		public FormitizeFormSubmittedDataSubheader(Dictionary<string, object> data)
		{
			_data = data;
		}

		public FormitizeFormSubmittedDataContent GetEntry(string ObjectName, int RepeatedCount)
		{
			if (!_data.ContainsKey (RepeatedCount.ToString()))
				return null;
				
			Dictionary<string, object> entry = (Dictionary<string, object>)((Dictionary<string, object>) _data [RepeatedCount.ToString()])["children"];



			if (!entry.ContainsKey (ObjectName))
				return null;

			Dictionary <string, object> theEntry = (Dictionary<string, object>)entry [ObjectName];

			return new FormitizeFormSubmittedDataContent (theEntry);

		}

		public FormitizeFormSubmittedDataContent GetEntry(string ObjectName)
		{
			return GetEntry (ObjectName, 0);
		}

	}


	public class FormitizeFormSubmittedDataGetResponse : Formitize.API.Interface.iGetResponse
    {
		public int SubmittedFormID
		{
			get { return Convert.ToInt32 (resp ["submittedFormID"].ToString ()); }
		}

		public int JobID
		{
			get { 
				try
				{
					return Convert.ToInt32 (resp ["jobID"].ToString ()); 
				}
				catch
				{
					return 0;
				}
			}
		}

		public int FormID
		{
			get { return Convert.ToInt32 (resp ["formID"].ToString ()); }
		}

		public int UserID
		{
			get { return Convert.ToInt32 (resp ["userID"].ToString ()); }
		}

		public string Username
		{
			get { return resp ["userName"].ToString (); }
		}

		public int Count
		{
			get { return Convert.ToInt32 (resp ["count"].ToString ()); }
		}

		public int Version
		{
			get { return Convert.ToInt32 (resp ["version"].ToString ()); }
		}

		public string Title
		{
			get { return resp ["title"].ToString (); }
		}

		public string Latitude
		{
			get { return resp ["latitude"].ToString (); }
		}

		public string Longitude
		{
			get { return resp ["longitude"].ToString (); }
		}

		public string Location
		{
			get { return resp ["location"].ToString (); }
		}

		public FormitizeFormSubmittedDataSubheader GetSubheader(string subheader)
		{
			Dictionary<string, object> obj = (Dictionary<string, object>)resp ["content"];

			if (obj.ContainsKey (subheader)) {
				return new FormitizeFormSubmittedDataSubheader ((Dictionary<string, object>)obj[subheader]);

			}

			return null;

		}
    }
}
