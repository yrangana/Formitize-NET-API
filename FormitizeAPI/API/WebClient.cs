using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using Formitize.API.Serialization;

namespace Formitize.API
{
    public class WebClient
    {
        const String Version = "v2";
        //const String URL = "https://service.formitize.com/";
        const String URL = "http://localhost:8888/formitize/home/service/";

        private Credentials credentials;

        public WebClient(Credentials credentials)
        {
            this.credentials = credentials;
        }

        private String getBaseURL()
        {
            return WebClient.URL + "api/rest/" + WebClient.Version + "/";
        }

        public String GetURL(String URL)
        {
                
            return this.getBaseURL() + URL;
        }

        private HttpClient createClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(getBaseURL());
            client.DefaultRequestHeaders.Add("User-Agent", this.credentials.CompanyName);
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.credentials.UserName + ":" + this.credentials.Password));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);

            return client;
        }

        public async Task<string> PostAsync<T>(String URL, T Object)
        {
            var payload = JSONMapper.From<T>(Object);
            var request = this.createClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, URL);
            requestMessage.Content = new StringContent(payload, Encoding.UTF8, "text/json");

            var response = await request.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            var StatusCode = response.StatusCode;

            response.Dispose();
            requestMessage.Dispose();
            request.Dispose();

            if(StatusCode != HttpStatusCode.OK)
            {
                throw new Formitize.API.Error.APIException(responseString);
            }

            return responseString;
        }

        public async Task<string> DeleteAsync<T>(String URL, T Object) where T : Formitize.API.Interface.iGetRequest
        {
            var request = this.createClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, URL + Object.GetQuery());

            var response = await request.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            var StatusCode = response.StatusCode;

            response.Dispose();
            requestMessage.Dispose();
            request.Dispose();

            if (StatusCode != HttpStatusCode.OK)
            {
                throw new Formitize.API.Error.APIException(responseString);
            }

            return responseString;
        }


        /**
         *  @<exception cref="Formitize.API.Error.APIException">Any API exceptions are thrown.</exception>
         * 
         */
        public async Task<string> GetAsync<T>(String URL, T Object) where T : Formitize.API.Interface.iGetRequest 
        {
            var request = this.createClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, URL + Object.GetQuery());

            var response = await request.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            var StatusCode = response.StatusCode;

            response.Dispose();
            requestMessage.Dispose();
            request.Dispose();

            if (StatusCode != HttpStatusCode.OK)
            {
                throw new Formitize.API.Error.APIException(responseString);
            }

            return responseString;
        }
        
    }
}
