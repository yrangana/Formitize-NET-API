using System;
using System.Collections.Generic;
using Formitize.API.Response;
using Formitize.API.Serialization;
using Formitize.API.Response.CRM;
using System.Threading.Tasks;

namespace Formitize.API.Helper
{
    public class CRM
    {

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<PostCRMClientResponse>> PutClient(WebClient client, Model. Client crmClient)
        {
            var response = (String)(await client.PostAsync<Model.Client>(
                "crm/client/" + (crmClient.ID == 0 ? "" : crmClient.ID.ToString()),
                crmClient
            ));

            return JSONMapper.To<Response<PostCRMClientResponse>>(response);

        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<ClientListResponse>> ListClients(WebClient client, int page = 1)
        {
            var response = (String)(await client.GetAsync(
                    "crm/client/list/?page=" + page.ToString(),
                    new Formitize.API.Response.Database.ListRequest()
            ));
            return JSONMapper.To<Response<ClientListResponse>>(response);
        }

    }
}
