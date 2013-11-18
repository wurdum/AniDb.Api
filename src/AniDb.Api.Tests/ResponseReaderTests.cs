using System.IO;
using System.Linq;
using System.Xml;
using AniDb.Api.Exceptions;
using AniDb.Api.ResponseReaders;
using NUnit.Framework;

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
        public void AnimeReaderModelMapperTest() {
            var animeReader = new AnimeReader();
            var body = File.ReadAllText(Helpers.ResponseFile("anime-4054.xml"));

            animeReader.ReadObject(body);
        }
    }
}