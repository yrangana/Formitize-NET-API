using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formitize.API.REST;
using Formitize.API.Job;
using Formitize.API.Job.Response;
using Formitize.API.CMS;
using Formitize.API.Form;
using Formitize.API.Form.Submit;

namespace Formitize_API_NET
{
    class Program
    {
        static void PostJob()
        {

            FormitizeClient client = CreateClient();

            FormitizeJob job = new FormitizeJob();

            job.Title = "API Test";
            job.JobNumber = "1111";
            job.Notes = "Test Notes - NSW";
			job.Agent = "APIDemo";
            job.Location = "Some Place";
            job.setDueDateFromDate(DateTime.UtcNow);

            FormitizeJobForm jform = new FormitizeJobForm();

			jform.FormID = 10355; //the id for 'Interstate Run sheet'
			jform.setValue (0, "formDate_1", "2016-02-20")
				 .setValue (0, "formLocation_1", "Some location")
				 .setValueMultipleChoice (0, "formCheckbox_1", "Test Value A", "Test Value B", "Test Value C");
			 
            job.AttachJobForm(ref jform);

            FormitizeJobPostResponse resp = client.Post<FormitizeJobPostResponse>(job);

            if (resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            Console.WriteLine("Job ID - " + resp.getJobID());
            Console.WriteLine("Agent ID - " + resp.getAgentID());
        }

        static FormitizeClient CreateClient()
        {
			FormitizeCredentials cred = new FormitizeCredentials("APIDemo", "APIDemo", "apidemo123");

            
            return new FormitizeClient(cred);
        }

        static void GetJobs()
        {
            FormitizeClient client = CreateClient();

            FormitizeJobGetRequest request = new FormitizeJobGetRequest();

			request.AgentName = "APIDemo";

            FormitizeJobGetResponse resp = client.Get<FormitizeJobGetResponse>(request);

            if(resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            FormitizeJobEntry[] JobEntry = resp.getAllJobs();


            foreach(var job in JobEntry)
            {
                Console.WriteLine
                    (
                        "Job ID {0}\n" +
                        "Title {1}\n" +
                        "Location {2}\n" +
                        "Job Number {3}\n" +
                        "Order Number {4}\n --------", 
                        job.ID, job.Title, job.Location, job.JobNumber, job.OrderNumber
                    );
            }

        }

        static void CreateNewCMSEntry()
        {
            FormitizeClient client = CreateClient();

            FormitizeCMSEntry entry = new FormitizeCMSEntry();

            entry.Table = "TestTable1";

            entry.setValue("Name", "aaa")
                         .setValue("LastName", "bbb");


            FormitizeCMSEntryPostResponse resp = client.Post<FormitizeCMSEntryPostResponse>(entry);

            if (resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            Console.WriteLine("Created Entry ID - " + resp.getEntryID());

            entry.setValue("Name", "aaa2")
                         .setValue("LastName", "bbb222");


            resp = client.Post<FormitizeCMSEntryPostResponse>(entry);

            if (resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            Console.WriteLine("Created Entry ID - " + resp.getEntryID());

        }

        static void UpdateCMSEntry()
        {
            FormitizeClient client = CreateClient();

            FormitizeCMSEntry entry = new FormitizeCMSEntry();

            entry.Table = "TestTable1";

            entry.setValue("Name", "aaabbb")
                         .setValue("LastName", "bbbccc");
            entry.addCriteria("Name", "aaa");
            entry.CreateIfCantFindWhere = false;

            FormitizeCMSEntryPostResponse resp = client.Post<FormitizeCMSEntryPostResponse>(entry);

            if (resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            Console.WriteLine("Updated Entry ID - " + resp.getEntryID());
        }

        static void DeleteCMSEntry()
        {
            FormitizeClient client = CreateClient();

            FormitizeCMSEntryDeleteRequest entry = new FormitizeCMSEntryDeleteRequest();

            entry.Table = "TestTable1";
            entry.addCriteria("Name", "aaabbb");

            FormitizeCMSEntryDeleteResponse resp = client.Delete<FormitizeCMSEntryDeleteResponse>(entry);


            if (resp.hasError())
            {
                Console.WriteLine("Error Code " + resp.getErrorCode());
                Console.WriteLine(resp.getErrorMessage());
                return;
            }

            Console.WriteLine("Deleted Rows - " + resp.getDeletedRowsCount());


        }

		static void FetchForms()
		{
			FormitizeClient client = CreateClient ();

			FormitizeFormGetRequest request = new FormitizeFormGetRequest ();

			request.SimpleMode = true;


			FormitizeFormGetResponse resp = client.Get<FormitizeFormGetResponse> (request);

			if (resp.hasError ()) {
				Console.WriteLine("Error Code " + resp.getErrorCode());
				Console.WriteLine(resp.getErrorMessage());
				return;
			}

			FormitizeFormList[] list = resp.getIDList ();

			foreach(var e in list)
			{
				Console.WriteLine ("{0} - {1}", e.ID, e.Title);
			}


		}

		static void FetchSubmittedForms() 
		{

			FormitizeClient client = CreateClient ();

			bool inLoop = true;

			FormitizeFormSubmittedListGetRequest request = new FormitizeFormSubmittedListGetRequest ();

			request.SetIDOrder (System.ComponentModel.ListSortDirection.Ascending); //Defaults to Descending order.
			request.ModifiedAfterDate = new DateTime (2016, 1, 1);
				
			do {
				
				FormitizeFormSubmittedListGetResponse resp = client.Get<FormitizeFormSubmittedListGetResponse> (request);

				foreach(var item in resp.GetList())
				{
					
					Console.WriteLine(
						"Title - {0}\n ID - {1} \n FormID - {2} \n JobID - {3} \n UserID - {4} \n DateCreated - {5} \n DateModified - {6} \n----",
						item.Title,
						item.ID,
						item.FormID,
						item.JobID,
						item.UserID,
						item.DateCreated.ToString(),
						item.DateModified.ToString()
					);

					//request for a report.

					/*
					FormitizeFormSubmittedReportGetRequest getReport = new FormitizeFormSubmittedReportGetRequest(item.ID, "F1 Minimal Report"); //if left blank will return all reports.

					FormitizeFormSubmittedReportGetResponse reportResp = client.Get<FormitizeFormSubmittedReportGetResponse> (getReport);


					var cont = reportResp.GetReports();

					Console.WriteLine(
						"{0} - {1}",
						cont[item.ID].ReportList[0].Title,
						cont[item.ID].ReportList[0].URL //Using this URL you can download the PDF.
					);

					*/

					FormitizeFormSubmittedDataGetRequest getData = new FormitizeFormSubmittedDataGetRequest();
					getData.AddSubmittedID(item.ID);

					FormitizeFormSubmittedDataGetResponse dataResp = client.Get<FormitizeFormSubmittedDataGetResponse> (getData);

					FormitizeFormSubmittedDataSubheader subheader;
					FormitizeFormSubmittedDataContent entry;
					if( (subheader = dataResp.GetSubheader("subheaderDetails")) != null)
					{
						if((entry = subheader.GetEntry("clientName", 0)) != null)
							Console.WriteLine("clientName = {0}\n---", entry.GetStringValue());
					}


				}

				if (resp.Count != FormitizeFormSubmittedListGetRequest.MAX_PERPAGE)
					inLoop = false;
				
				request.PageNumber++;

			} while(inLoop);
		}

		static void WebhookCallback()
		{
			//This is essentially the JSON that is passed from a webhook on a formsubmission. To set up webhooks please visit
			//http://service.formitize.com.au/setting/api/ - as this is the most prefered and reliable method of ensuring data is sent across.


			//TestJSON would be the JSON posted to the webhook url.
			string TestJSON = "{\"submittedFormID\":\"330335\",\"jobID\":false,\"formID\":\"10355\",\"userID\":\"6065\",\"userName\":\"admin\",\"count\":\"2\",\"version\":\"2\",\"title\":\"API Test Demo Form\",\"formDateCreated\":\"1454453545\",\"latitude\":false,\"longitude\":false,\"location\":false,\"content\":{\"subheaderDetails\":{\"0\":{\"id\":\"2\",\"type\":\"formSubheader\",\"name\":\"subheaderDetails\",\"children\":{\"clientName\":{\"id\":3,\"type\":\"formText\",\"name\":\"clientName\",\"value\":\"Test Name\"},\"clientEmail\":{\"id\":4,\"type\":\"formText\",\"name\":\"clientEmail\",\"value\":\"test@test.com\"},\"businessType\":{\"id\":5,\"type\":\"formMultiple\",\"name\":\"businessType\",\"value\":{\"0\":\"Option A\"}}}}},\"subheaderFieldTest\":{\"0\":{\"id\":\"6\",\"type\":\"formSubheader\",\"name\":\"subheaderFieldTest\",\"children\":{\"formDate_1\":{\"id\":7,\"type\":\"formText\",\"name\":\"formDate_1\",\"value\":\"\"},\"formLocation_1\":{\"id\":8,\"type\":\"formText\",\"name\":\"formLocation_1\",\"value\":\"\"},\"formCheckbox_1\":{\"id\":9,\"type\":\"formMultiple\",\"name\":\"formCheckbox_1\",\"value\":{}}}}}},\"attachments\":{\"0\":{\"url\":\"https:\\/\\/service.formitize.com.au\\/file\\/hash\\/report\\/0a229a5a92bd7f629e181343b781edaa\",\"type\":\"pdf\",\"name\":\"Default\"}}}";

			FormitizeFormSubmittedDataGetResponse resp = FormitizeFormSubmittedDataGetResponse.createObjectFromJSON<FormitizeFormSubmittedDataGetResponse> (TestJSON);


			Console.WriteLine
			(
				"ID - {0}\n" +
				"JobID - {1}\n" +
				"FormID {2}\n" +
				"UserID {3}\n" +
				"Username {4}\n" +
				"Longitude {5}\n" +
				"Latitude {6}\n" +
				"Location {7}\n",
				resp.SubmittedFormID,
				resp.JobID,
				resp.FormID,
				resp.UserID,
				resp.Username,
				resp.Longitude,
				resp.Latitude,
				resp.Location
			);


			//grab specific fields from it now.
			FormitizeFormSubmittedDataSubheader subheader;

			if( (subheader = resp.GetSubheader("subheaderDetails")) != null)
			{
				
				Console.WriteLine("clientName = {0}", subheader.GetEntry("clientName", 0).GetStringValue());
				Console.WriteLine("clientEmail = {0}", subheader.GetEntry("clientEmail", 0).GetStringValue());
				Console.WriteLine("businessType = {0}", subheader.GetEntry("businessType", 0).GetStringValue());
			}


		}

        static void Main(string[] args)
        {
            GetJobs();
			PostJob();

            CreateNewCMSEntry();
            UpdateCMSEntry();
            DeleteCMSEntry();

			WebhookCallback ();

			FetchForms ();
			FetchSubmittedForms ();
        }
    }
}
