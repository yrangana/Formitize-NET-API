using System;
using Formitize.API.Response;
using Formitize.API.Model;
using Formitize.API.Serialization;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace Formitize.API.Helper
{
    public class SubmittedForms
    {
        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<SubmittedFormGetEntry>> GetSubmittedForm(WebClient client, int submittedID)
        {
            SubmittedFormRequest jobRequest = new SubmittedFormRequest();
            jobRequest.SubmittedID = submittedID;
            return JSONMapper.To<Response<SubmittedFormGetEntry>>((String)(await client.GetAsync<SubmittedFormRequest>("form/submit/", jobRequest)));
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<SubmittedFormPost>> PostSubmittedForm(WebClient client, SubmittedForm sf)
        {
            var id = sf.SubmittedFormID;

            string url = "form/submit/";

            if (id != 0) url += id.ToString();

            return JSONMapper.To<Response<SubmittedFormPost>>((String)(await client.PostAsync<SubmittedForm>(url, sf)));
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<Dictionary<string, SubmittedFormGetEntry>>> GetSubmittedFormsByJobID(WebClient client, int jobID){
            SubmittedFormRequest jobRequest = new SubmittedFormRequest();
            jobRequest.AddHeader("jobID", jobID.ToString());
            return JSONMapper.To<Response<Dictionary<string, SubmittedFormGetEntry>>>((String)(await client.GetAsync<SubmittedFormRequest>("form/submit/", jobRequest)));
        }

    }
}
