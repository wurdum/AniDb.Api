using System;
using System.Collections.Generic;
using AniDb.Api.Exceptions;
using AniDb.Api.Models;
using AniDb.Api.ResponseReaders;
using AniDb.Api.Tests.Stubs;
using Moq;
using NUnit.Framework;

namespace AniDb.Api.Tests
{
    [TestFixture]
    public class AniDbRequestTests
    {
        private const string ClientErrorBody = "<error>Client Values Missing or Invalid</error>";
        private const string AidErrorBody = "<error>Anime not found</error>";

        [Test, TestCaseSource("RequestBuilderUrlCases")]
        public string RequstBuilderUrlTest(ClientCredentials client, Requests.RequestTarget requestTarget, object[] pars) {
            return Requests.CreateToAnime(client, (int)pars[0]).Uri.ToString();
        }

        [Test, TestCaseSource("ResponseResultsDependingOnResponseBody")]
        public Anime ResponseBodyTest(string responseBody) {
            var readerMock = new Mock<AnimeReader>();
            readerMock.Setup(r => r.ReadObject(It.IsAny<string>())).Returns(new Anime());
            var webRequest = new TestWebRequest();
            var webResponse = webRequest.GetResponse();
            
            var aniDbResponse = new AniDbResponse(webResponse, responseBody);

            return aniDbResponse.Read(readerMock.Object);
        }

        private static IEnumerable<TestCaseData> RequestBuilderUrlCases {
            get {
                yield return new TestCaseData(new ClientCredentials("xxx", 1), Requests.RequestTarget.Anime, new object[] {2})
                    .Returns("http://api.anidb.net:9001/httpapi?request=anime&client=xxx&clientver=1&protover=1&aid=2");
                yield return new TestCaseData(new ClientCredentials("yyy", 2), Requests.RequestTarget.Anime, new object[] { 33403 })
                    .Returns("http://api.anidb.net:9001/httpapi?request=anime&client=yyy&clientver=2&protover=1&aid=33403");
            }
        }

        private static IEnumerable<TestCaseData> ResponseResultsDependingOnResponseBody {
            get {
                yield return new TestCaseData(ClientErrorBody).Throws(typeof(ClientCredentialsException));
                yield return new TestCaseData(AidErrorBody).Throws(typeof(AnimeIdException));
                yield return new TestCaseData(new String('.', 100)).Returns(new Anime());
            }
        }
    }
}
