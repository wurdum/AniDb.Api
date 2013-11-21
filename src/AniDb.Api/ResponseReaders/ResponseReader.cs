using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AniDb.Api.Exceptions;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public abstract class ResponseReader<T, K>
    {
        protected const string DataDir = "Data";
        protected static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        protected readonly ModelMapper<T, K> _mapper;

        protected ResponseReader(ModelMapper<T, K> mapper) {
            _mapper = mapper;
        }

        public virtual T ReadObject(string resposeBody) {
            var generatedObj = DeserializeXml(resposeBody);

            return _mapper.Map(generatedObj);
        }

        protected abstract K DeserializeXml(string responseBody);

        protected virtual K DeserializeXmlDefault(string responseBody, string schemaFileName) {
            if (string.IsNullOrWhiteSpace(responseBody))
                throw new ArgumentNullException(responseBody);

            K obj;
            var validationErrors = new List<XmlSchemaException>();
            try {
                var readerSettings = new XmlReaderSettings();
                readerSettings.Schemas.Add(null, FileFromData(schemaFileName));
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
                readerSettings.ValidationEventHandler += (sender, args) => validationErrors.Add(args.Exception);


                var serializer = new XmlSerializer(typeof(K));
                using (var reader = XmlReader.Create(new StringReader(responseBody), readerSettings)) {
                    obj = (K)serializer.Deserialize(reader);
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

        protected string FileFromData(string fileName) {
            return Path.Combine(AppRoot, DataDir, fileName); 
        }
    }
}