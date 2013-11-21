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
            var body = File.ReadAllText(Helpers.ResponseFile("anime-999999.xml")).Substring(1);
            var reader = new AnimeReader();

            try {
                reader.ReadObject(body);
            } catch (ResponseReadXmlException ex) {
                Assert.AreEqual(body, ex.ResponseBody);
                Assert.AreEqual(typeof(XmlException), ex.InnerException.GetType());
            }
        }

        [Test]
        public void CategoryReaderThrowsXmlExceptionTest() {
            var body = File.ReadAllText(Helpers.ResponseFile("category.xml")).Substring(1);
            var reader = new CategoryReader();

            try {
                reader.ReadObject(body);
            } catch (ResponseReadXmlException ex) {
                Assert.AreEqual(body, ex.ResponseBody);
                Assert.AreEqual(typeof(XmlException), ex.InnerException.GetType());
            }
        }

        [Test]
        public void AnimeReaderThrowsValidationExceptionTest() {
            var body = File.ReadAllText(Helpers.ResponseFile("anime-999998.xml"));
            var reader = new AnimeReader();

            var ex = Assert.Throws<ResponseValidateXmlException>(() => reader.ReadObject(body));
            Assert.AreEqual(body, ex.ResponseBody);
            Assert.AreEqual(1, ex.SchemaExceptions.Count());
        }

        [Test]
        public void CategoryReaderThrowsValidationExceptionTest() {
            var body = File.ReadAllText(Helpers.ResponseFile("category-999999.xml"));
            var reader = new CategoryReader();

            var ex = Assert.Throws<ResponseValidateXmlException>(() => reader.ReadObject(body));
            Assert.AreEqual(body, ex.ResponseBody);
            Assert.AreEqual(1, ex.SchemaExceptions.Count());
        }
        
        [Test]
        public void ReadingAnimeResponsesBodiesTest() {
            var animeReader = new AnimeReader();
            var objFromResponse = Helpers.AllValidAnimeResponsesFiles().Select(File.ReadAllText).Select(animeReader.ReadObject).ToList();
            var objFromFiles = Helpers.AllSerializedObjectFiles().Select(f => JsonConvert.DeserializeObject<Anime>(File.ReadAllText(f))).ToList();

            foreach (var actual in objFromResponse) {
                var expected = objFromFiles.First(o => o.Id == actual.Id);
                Assert.AreEqual(expected, actual, actual.Id.ToString());
            }
        }

        /*[Test]
        public void RecreateJsonAnimeObjects() {
            var animeReader = new AnimeReader();
            var objs = Helpers.AllValidAnimeResponsesFiles()
                .Select(File.ReadAllText)
                .Select(animeReader.ReadObject).ToList();

            foreach (var obj in objs)
                File.WriteAllText(Helpers.SerializedObjectFile("obj-" + obj.Id + ".json"), 
                    JsonConvert.SerializeObject(obj, Formatting.Indented));
        }*/
    }
}