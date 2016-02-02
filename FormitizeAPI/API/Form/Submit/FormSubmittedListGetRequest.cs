using System;
using System.Collections.Generic;
using System.Text;

namespace Formitize.API.Form.Submit
{
	public enum FormitizeFormSubmittedGetRequestSearch
	{
		SEARCH_CONTAIN = 1,
		SEARCH_DOESNT_CONTAIN,
		SEARCH_EQUAL,
		SEARCH_NOTEQUAL
	}

    public class FormitizeFormSubmittedListGetRequest : Formitize.API.Interface.iGetRequest
    {
		public const int MAX_PERPAGE = 200;

		public DateTime ModifiedAfterDate
        {
            get; set;
        }

		public DateTime CreatedAfterDate
		{
			get; set;
		}

		public int PageNumber {
			get;
			set;
		}

		private string IDOrder;

		private string TitleSearch;
		private string TitleSearchMethod;

		public void SetIDOrder(System.ComponentModel.ListSortDirection direction)
		{
			switch (direction) {
			case System.ComponentModel.ListSortDirection.Ascending:
				IDOrder = "asc";
				break;
			default:
				IDOrder = "desc";
				break;
			}
		}
        
		public void SetTitle(string Title, FormitizeFormSubmittedGetRequestSearch Search)
		{
			TitleSearch = Title;


			switch (Search) 
			{
				case FormitizeFormSubmittedGetRequestSearch.SEARCH_CONTAIN:
					TitleSearchMethod = "contain";
					break;
				case FormitizeFormSubmittedGetRequestSearch.SEARCH_DOESNT_CONTAIN:
					TitleSearchMethod = "ncontain";
					break;
				case FormitizeFormSubmittedGetRequestSearch.SEARCH_EQUAL:
					TitleSearchMethod = "equal";
					break;
				case FormitizeFormSubmittedGetRequestSearch.SEARCH_NOTEQUAL:
					TitleSearchMethod = "nequal";
					break;
			}
		}

		public FormitizeFormSubmittedListGetRequest()
		{
			TitleSearchMethod = "";
			TitleSearch = "";
			PageNumber = 1;
			ModifiedAfterDate = new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			CreatedAfterDate = new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			IDOrder = "desc";


		}

        public override string getURL()
        {
			List<string> str = new List<string>();
				
			str.Add ("simple=true");
			str.Add ("page=" + PageNumber.ToString ());



			if (!String.IsNullOrEmpty (TitleSearch)) {
				str.Add ("title=" + TitleSearch);
				str.Add ("titlesearch=" + TitleSearchMethod);
			}


			Int32 dm = (Int32)ModifiedAfterDate.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToUniversalTime ()).TotalSeconds;

			if (dm > 0) {
				str.Add ("modifiedAfterDate=" + Convert.ToString(dm) );
			}

			Int32 dc = (Int32)CreatedAfterDate.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToUniversalTime ()).TotalSeconds;

			if (dc > 0) {
				str.Add ("modifiedAfterDate=" + Convert.ToString(dc) );
			}

			str.Add ("idorder=" + IDOrder);

			return "form/submit/list/?" + String.Join("&", str);
        }
    }
}
