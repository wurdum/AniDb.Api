using System.IO;
using System.Linq;
using System.Xml;
using AniDb.Api.Exceptions;
using AniDb.Api.Models;
using AniDb.Api.ResponseReaders;
using NUnit.Framework;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace AniDb.Api.Tests
{
    [TestFixture]
    public class ResponseReaderTests
    {
        [Test]
        public void AnimeReaderThrowsXmlExceptionTest() {
            var animeReader = new AnimeReader();
            var body = File.ReadAllText(Helpers.ResponseFile("anime-1774.xml")).Substring(1);

            try {
                animeReader.ReadObject(body);
            } catch (ResponseReadXmlException ex) {
                Assert.AreEqual(body, ex.ResponseBody);
                Assert.AreEqual(typeof(XmlException), ex.InnerException.GetType());
            }
        }

        [Test]
        public void AnimeReaderThrowsValidationExceptionTest() {
            var animeReader = new AnimeReader();
            var body = File.ReadAllText(Helpers.ResponseFile("anime-999999.xml"));

            try {
                animeReader.ReadObject(body);
            } catch (ResponseValidateXmlException ex) {
                Assert.AreEqual(body, ex.ResponseBody);
                Assert.AreEqual(1, ex.SchemaExceptions.Count());
            }
        }
        
        [Test]
        public void ReadingResponsesBodiesTest() {
            var animeReader = new AnimeReader();
            var objFromResponse = Helpers.AllValidResponsesFiles().Select(File.ReadAllText).Select(animeReader.ReadObject).ToList();
            var objFromFiles = Helpers.AllSerializedObjectFiles().Select(f => JsonConvert.DeserializeObject<Anime>(File.ReadAllText(f))).ToList();

            foreach (var actual in objFromResponse) {
                var expected = objFromFiles.First(o => o.Id == actual.Id);
                Assert.AreEqual(expected, actual, actual.Id.ToString());
            }
        }

        /*[Test]
        public void RecreateJsonAnimeObjects() {
            var animeReader = new AnimeReader();
            var objs = Helpers.AllValidResponsesFiles()
                .Select(File.ReadAllText)
                .Select(animeReader.ReadObject).ToList();

            foreach (var obj in objs)
                File.WriteAllText(Helpers.SerializedObjectFile("obj-" + obj.Id + ".json"), 
                    JsonConvert.SerializeObject(obj, Formatting.Indented));
        }*/
    }
}