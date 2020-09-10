using System;
using System.Collections.Generic;
using Formitize.API.Response;
using Formitize.API.Serialization;
using Formitize.API.Response.Asset;
using Formitize.API.Model.Asset.Schema;

using System.Threading.Tasks;

namespace Formitize.API.Helper
{
    public class Asset
    {

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<Schemas>> GetAssetSchemaList(WebClient client)
        {
            var response = (String)(await client.GetAsync(
                    "asset/schema/list",
                    new Formitize.API.Response.Database.ListRequest()
            ));
            return JSONMapper.To<Response<Schemas>>(response);
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<PostAssetResponse>> PutAsset(WebClient client, int schemaID, Model.Asset.Asset asset)
        {
            var response = (String)(await client.PostAsync<Model.Asset.Asset>(
                "asset/" + schemaID + "/" + (asset.ID == 0 ? "" : asset.ID.ToString()),
                asset
            ));

            return JSONMapper.To<Response<PostAssetResponse>>(response);

        }


        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<DeleteAssetResponse>> DeleteAsset(WebClient client, int schemaID, int assetID)
        {
            var response = (String)(await client.DeleteAsync(
                "asset/" + schemaID.ToString() + "/" + assetID.ToString(),
                new Formitize.API.Response.Database.ListRequest()
            ));

            return JSONMapper.To<Response<DeleteAssetResponse>>(response);

        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<AssetListResponse>> GetAssetList(WebClient client, int schemaID)
        {
            var response = (String)(await client.GetAsync(
                    "asset/" + schemaID.ToString() + "/list",
                    new Formitize.API.Response.Database.ListRequest()
            ));
            var data = JSONMapper.To<Response<AssetListResponse>>(response);


            return data;
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<AssetResponse>> GetAsset(WebClient client, int schemaID, int assetID)
        {
            var response = (String)(await client.GetAsync(
                    "asset/" + schemaID.ToString() + "/" + assetID.ToString(),
                    new Formitize.API.Response.Database.ListRequest()
            ));
            return JSONMapper.To<Response<AssetResponse>>(response);
        }

        /**
         * <exception cref="Formitize.API.Error.APIException">On any API errors.</exception>
         */
        public static async Task<Response<Schema>> GetSchema(WebClient client, int id)
        {
            var response = (String)(await client.GetAsync(
                    "asset/schema/" + id.ToString(),
                    new Formitize.API.Response.Database.ListRequest()
            ));
            return JSONMapper.To<Response<Schema>>(response);
        }

    }
}
