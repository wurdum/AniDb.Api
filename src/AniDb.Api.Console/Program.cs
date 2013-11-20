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
                if (AlreadyRequested(aid)) {
                    System.Console.WriteLine("{0} skipped", i);
                    continue;
                }

                var responseBody = Requests.CreateToAnime(client, aid).GetResponseAsync().Result.ResponseBody;
                File.WriteAllText(GetResponseFile(aid), responseBody);

                try {
                    var obj = reader.ReadObject(responseBody);
                    File.WriteAllText(GetResponseFile(aid) + ".success", JsonConvert.SerializeObject(obj));
                } catch (ResponseReadXmlException ex) {
                    File.WriteAllText(GetResponseFile(aid) + ".fail", ex.Message);
                } catch (ResponseValidateXmlException ex) {
                    File.WriteAllLines(GetResponseFile(aid) + ".fail", ex.SchemaExceptions.Select(e => e.Message).ToArray());
                }

                System.Console.WriteLine("{0} done", i);
                Thread.Sleep(TimeSpan.FromSeconds(20));
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
