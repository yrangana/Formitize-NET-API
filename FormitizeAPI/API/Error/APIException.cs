using System;
using System.Net;
using System.Net.Http;
using Formitize.API.Response;

namespace Formitize.API.Error
{
    public class APIException : Exception
    {

        public APIException()
        {
        }

        public APIException(string json)
            : base(GetErrorMessage(json))
        {
            var wrapper = Formitize.API.Serialization.JSONMapper.To<Response<Wrapper>>(json);
            StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), wrapper.Payload.Error.Code.ToString());
        }

        public APIException(string json, Exception inner)
            : base(GetErrorMessage(json), inner)
        {
            var wrapper = Formitize.API.Serialization.JSONMapper.To<Response<Wrapper>>(json);
            StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), wrapper.Payload.Error.Code.ToString());
        }


        public HttpStatusCode StatusCode
        {
            get; private set;
        }

        private static string GetErrorMessage(string JSON)
        {
            var wrapper = Formitize.API.Serialization.JSONMapper.To<Response<Wrapper>>(JSON);
            
            return wrapper.Payload.Error.Message;
        }

    }
}
