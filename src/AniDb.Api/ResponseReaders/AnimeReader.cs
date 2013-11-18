using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AniDb.Api.Exceptions;
using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders
{
    public class AnimeReader : ResponseReader<Anime>
    {
        private const string ResponseSchema = "ValidAnimeResponse.xsd";

        public override Anime ReadObject(string responseBody) {
            if (string.IsNullOrWhiteSpace(responseBody))
                throw new ArgumentNullException(responseBody);

            var validationErrors = new List<XmlSchemaException>();
            try {
                var readerSettings = new XmlReaderSettings();
                readerSettings.Schemas.Add(null, FileFromData(ResponseSchema));
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
                readerSettings.ValidationEventHandler += (sender, args) => validationErrors.Add(args.Exception);

                anime obj;
                var serializer = new XmlSerializer(typeof (anime));
                using (var reader = XmlReader.Create(new StringReader(responseBody), readerSettings)) {
                    obj = (anime)serializer.Deserialize(reader);
                }

            } catch (InvalidOperationException ex) {
                var inner = ex.InnerException;
                if (inner == null)
                    throw;

                throw new ResponseReadXmlException(inner.Message, responseBody, inner);
            }

            if (validationErrors.Count > 0)
                throw new ResponseValidateXmlException("Errors encountered during xsd validation", responseBody, validationErrors);

            return null;
        }
    }
}