using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace AniDb.Api.Exceptions
{
    public class ResponseValidateXmlException : Exception
    {
        public ResponseValidateXmlException() { }
        public ResponseValidateXmlException(string message) : base(message) { }

        public ResponseValidateXmlException(string message, string responseBody, IEnumerable<XmlSchemaException> exceptions)
            : base(message) {
            ResponseBody = responseBody;
            SchemaExceptions = exceptions;
        }

        public string ResponseBody { get; private set; }
        public IEnumerable<XmlSchemaException> SchemaExceptions { get; private set; }
    }
}