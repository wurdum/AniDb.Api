using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using AniDb.Api.Exceptions;
using AniDb.Api.ResponseReaders;
using Newtonsoft.Json;

namespace AniDb.Api.Console
{
    class Program
    {
        public static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        private const string ResponsesDir = "Responses";
        private const string FileTemplate = "anime-{0}.xml";

        static void Main(string[] args) {
            if (!Directory.Exists(Path.Combine(AppRoot, ResponsesDir)))
                Directory.CreateDirectory(Path.Combine(AppRoot, ResponsesDir));

            var index = new Index();
            var client = new ClientCredentials("supermango", 1);
            var reader = new AnimeReader();
            for (var i = index.Count - 1; i > 0; i--) {
                var aid = index[i].Id;
                var responseFile = GetResponseFile(aid);
                if (!AlreadyRequested(aid)) {
                    File.WriteAllText(responseFile, Requests.CreateToAnime(client, aid).GetResponseAsync().Result.ResponseBody);
                    Thread.Sleep(TimeSpan.FromSeconds(20));
                }
                
                ReadObject(reader, File.ReadAllText(responseFile), aid);

                System.Console.WriteLine("{0} done", i);
                
            }
        }

        private static void ReadObject(AnimeReader reader, string responseBody, int aid) {
            if (File.Exists(GetResponseFile(aid) + ".success"))
                File.Delete(GetResponseFile(aid) + ".success");

            if (File.Exists(GetResponseFile(aid) + ".fail"))
                File.Delete(GetResponseFile(aid) + ".fail");

            try {
                var obj = reader.ReadObject(responseBody);
                File.WriteAllText(GetResponseFile(aid) + ".success", JsonConvert.SerializeObject(obj));
            } catch (ResponseReadXmlException ex) {
                File.WriteAllText(GetResponseFile(aid) + ".fail", ex.Message);
            } catch (ResponseValidateXmlException ex) {
                File.WriteAllLines(GetResponseFile(aid) + ".fail", ex.SchemaExceptions.Select(e => e.Message).ToArray());
            }
        }

        private static bool AlreadyRequested(int aid) {
            var file = GetResponseFile(aid);
            return File.Exists(file);
        }

        private static string GetResponseFile(int aid) {
            return Path.Combine(AppRoot, ResponsesDir, string.Format(FileTemplate, aid));
        }
    }
}
