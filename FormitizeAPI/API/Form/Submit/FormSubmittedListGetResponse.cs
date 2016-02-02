using System;
using System.Collections.Generic;
using System.Text;
using Formitize.API.Job.Response;

namespace Formitize.API.Form
{
	public class FormitizeFormSubmittedList
	{
		public int ID {
			get;
		}

		public int FormID
		{
			get;
		}

		public int JobID
		{
			get; 
		}

		public int UserID {
			get;
		}

		public DateTime  DateCreated {
			get;
		}

		public DateTime DateModified
		{
			get;
		}

		public string Title
		{
			get;
		}

		public FormitizeFormSubmittedList(int ID, int FormID, int UserID, int JobID, string Title, double DateCreated, double DateModified)
		{
			this.ID = ID;
			this.FormID = FormID;
			this.UserID = UserID;
			this.JobID = JobID;
			this.Title = Title;

			this.DateCreated = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
			this.DateModified = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);

			this.DateCreated = this.DateCreated.AddSeconds (DateCreated);

			this.DateModified = this.DateModified.AddSeconds (DateModified);
		

		}
	}

	public class FormitizeFormSubmittedListGetResponse : Formitize.API.Interface.iGetResponse
    {
		public int Count
		{
			get { return resp.Count; }
		}

		public FormitizeFormSubmittedList[] GetList()
        {
			FormitizeFormSubmittedList[] ids = new FormitizeFormSubmittedList[resp.Count];
            int c = 0;

			foreach( Dictionary<string, object> key in resp.Values)
            {
				ids[c] = new FormitizeFormSubmittedList( 
					Convert.ToInt32( key["submittedFormID"].ToString()), 
					Convert.ToInt32( key["formID"].ToString() ),
					Convert.ToInt32( key["userID"].ToString() ),
					Convert.ToInt32( key["jobID"].ToString() ),
					key["title"].ToString(),
					Convert.ToDouble( key["dateCreated"].ToString() ),
					Convert.ToDouble( key["dateModified"].ToString() )
				);

				c++;

            }

            return ids;
        }



    }
}
