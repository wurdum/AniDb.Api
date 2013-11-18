using System;
using System.IO;
using System.Reflection;

namespace AniDb.Api.ResponseReaders
{
    public abstract class ResponseReader<T>
    {
        protected const string DataDir = "Data";
        protected static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

        public abstract T ReadObject(string responseBody);

        protected string FileFromData(string fileName) {
            return Path.Combine(AppRoot, DataDir, fileName); 
        }
    }
}