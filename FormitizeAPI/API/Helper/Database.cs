using System;
using System.Collections.Generic;
using Formitize.API.Response;
using Formitize.API.Model;
using Formitize.API.Serialization;
using Formitize.API.Response.Database;
using Formitize.API.Model.Database;

using System.Threading.Tasks;

namespace Formitize.API.Helper
{
    public class Database
    {

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<ListResponse>> GetDatabaseList(WebClient client)
        {
            return JSONMapper.To<Response<ListResponse>>((String)(await client.GetAsync<ListRequest>("database/list", new ListRequest())));
        }


        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<PostBatchResponse>> BulkWrite(WebClient client, string Database, List<Entry> Entries, List<string> PrimaryKeys = null)
        {
            var request = new PostBatchRequest();
            foreach (var entry in Entries) {

                var newDictionary = new Dictionary<string, string>(entry.Content);
                if(entry.ID != 0)
                {
                    newDictionary.Add("id", entry.ID.ToString());
                }

                request.Payload.Add(newDictionary);
            }

            if(PrimaryKeys != null)
            {
                request.PrimaryKeys = PrimaryKeys;
            }

            return JSONMapper.To<Response<PostBatchResponse>>((String)(await client.PostAsync<PostBatchRequest>("database/" + Database, request)));
        }



    }
}
