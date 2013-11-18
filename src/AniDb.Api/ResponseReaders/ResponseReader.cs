using System;
using System.IO;
using System.Reflection;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public abstract class ResponseReader<T, K>
    {
        protected const string DataDir = "Data";
        protected static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        protected readonly IModelMapper<T, K> _mapper;

        protected ResponseReader(IModelMapper<T, K> mapper) {
            _mapper = mapper;
        }

        public virtual T ReadObject(string resposeBody) {
            var generatedObj = DeserializeXml(resposeBody);

            return _mapper.Map(generatedObj);
        }

        protected abstract K DeserializeXml(string responseBody);

        protected string FileFromData(string fileName) {
            return Path.Combine(AppRoot, DataDir, fileName); 
        }
    }
}