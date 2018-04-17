using System;
using System.Net;
using System.Net.Http;

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
            Wrapper wrapper = Formitize.API.Serialization.JSONMapper.To<Wrapper>(json);
            StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), wrapper.Error.Code.ToString());
        }

        public APIException(string json, Exception inner)
            : base(GetErrorMessage(json), inner)
        {
            Wrapper wrapper = Formitize.API.Serialization.JSONMapper.To<Wrapper>(json);
            StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), wrapper.Error.Code.ToString());
        }


        public HttpStatusCode StatusCode
        {
            get; private set;
        }

        private static string GetErrorMessage(string JSON)
        {
            Wrapper wrapper = Formitize.API.Serialization.JSONMapper.To<Wrapper>(JSON);
            
            return wrapper.Error.Message;
        }

    }
}
