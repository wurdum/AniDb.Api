using System;

namespace AniDb.Api.Exceptions
{
    public class ResponseReadXmlException : Exception
    {
        public ResponseReadXmlException() {}
        public ResponseReadXmlException(string message) : base(message) {}
        public ResponseReadXmlException(string message, string responseBody, Exception inner) : base(message, inner) {
            ResponseBody = responseBody;
        }

        public string ResponseBody { get; private set; }
    }
}