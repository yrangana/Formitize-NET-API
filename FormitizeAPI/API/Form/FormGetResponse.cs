using System;
using System.Collections.Generic;
using System.Text;
using Formitize.API.Job.Response;

namespace Formitize.API.Form
{

	public class FormitizeFormList
	{
		public int ID {
			get;
		}

		public string Title
		{
			get;
		}

		public FormitizeFormList(int ID, string Title)
		{
			this.ID = ID;
			this.Title = Title;
		}
	}

    public class FormitizeFormGetResponse : Formitize.API.Interface.iGetResponse
    {
		public FormitizeFormList[] getIDList()
        {
			FormitizeFormList[] ids = new FormitizeFormList[resp.Count];
            int c = 0;

			foreach( Dictionary<string, object> key in resp.Values)
            {
				ids[c] = new FormitizeFormList( 
					Convert.ToInt32( key["formID"].ToString()), 
					key["title"].ToString()
				);

				c++;

            }

            return ids;
        }



    }
}
