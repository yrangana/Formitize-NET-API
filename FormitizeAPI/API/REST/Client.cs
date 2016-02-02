using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;


namespace Formitize.API.REST
{
    public class FormitizeClient
    {
        const String Version = "v1";
        const String URL = "https://service.formitize.com.au/";

        private FormitizeCredentials credentials;

        public FormitizeClient(FormitizeCredentials credentials)
        {
            this.credentials = credentials;
        }

        private String getBaseURL()
        {
            return FormitizeClient.URL + "api/rest/" + FormitizeClient.Version + "/";
        }

        public String GetURL(String URL)
        {
                
            return this.getBaseURL() + URL;
        }

        public GetResponseType Get<GetResponseType>(Interface.iGetRequest GetRequest) where GetResponseType : Interface.iGetResponse, new()
        {

            string endpoint = this.GetURL(GetRequest.getURL());
            var request = createRequest(endpoint, "GET");
            

            try
            {

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return Interface.iGetResponse.createObjectFromJSON<GetResponseType>(responseValue);
                }
            }
            catch (WebException exception)
            {
                var resp = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
                return Interface.iGetResponse.createObjectFromJSON<GetResponseType>(resp);
            }
        }

        HttpWebRequest createRequest(string endpoint, string method, string contentType = "application/json")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.credentials.UserName + ":" + this.credentials.Password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            request.UserAgent = this.credentials.CompanyName;


            request.Method = method;
            request.ContentType = contentType;

            return request;
        }
        
        public DeleteResponseType Delete<DeleteResponseType>(Interface.iDeleteRequest delete) where DeleteResponseType : Interface.iDeleteResponse, new()
        {
            string endpoint = this.GetURL(delete.getURL());
            var request = createRequest(endpoint, "DELETE");


            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return Interface.iDeleteResponse.createObjectFromJSON<DeleteResponseType>(responseValue);
                }
            }
            catch (WebException exception)
            {
                var resp = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
                return Interface.iDeleteResponse.createObjectFromJSON<DeleteResponseType>(resp);
            }

        }

        public PostResponseType Post<PostResponseType>(Interface.iPostRequest post) where PostResponseType : Interface.iPostResponse, new()
        {
            string PostData = post.getData();

            string endpoint = this.GetURL(post.getURL());

            var request = createRequest(endpoint, "POST");

            if (!string.IsNullOrEmpty(PostData))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return Interface.iPostResponse.createObjectFromJSON<PostResponseType>(responseValue);
                }
            }
            catch(WebException exception)
            {
                var resp = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
                return Interface.iPostResponse.createObjectFromJSON<PostResponseType>(resp);
            }


        }

        public void PostAsync(Interface.iPostRequest post)
        {

        }
    }
}
