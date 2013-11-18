using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AniDb.Api.Exceptions;
using AniDb.Api.Models;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public class AnimeReader : ResponseReader<Anime, anime>
    {
        private const string ResponseSchema = "ValidAnimeResponse.xsd";

        public AnimeReader() : base(new AnimeModelMapper()) { }

        protected override anime DeserializeXml(string responseBody) {
            if (string.IsNullOrWhiteSpace(responseBody))
                throw new ArgumentNullException(responseBody);

            anime obj;
            var validationErrors = new List<XmlSchemaException>();
            try {
                var readerSettings = new XmlReaderSettings();
                readerSettings.Schemas.Add(null, FileFromData(ResponseSchema));
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
                readerSettings.ValidationEventHandler += (sender, args) => validationErrors.Add(args.Exception);

                
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

            return obj;
        }
    }
}