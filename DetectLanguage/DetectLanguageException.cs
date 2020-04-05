using System;
using System.Net;
using System.Net.Http;

namespace DetectLanguage
{
    public class DetectLanguageException : Exception
    {
        public DetectLanguageException(HttpStatusCode statusCode, string message, HttpResponseMessage response) : base(message)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public DetectLanguageException(HttpStatusCode statusCode, DetectLanguageError error, HttpResponseMessage response) : base(error.message)
        {
            StatusCode = statusCode;
            Response = response;
            Error = error;
        }

        public HttpStatusCode StatusCode { get; }
        public HttpResponseMessage Response { get; }
        public DetectLanguageError Error { get; }

    }
}
