using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AniDb.Api.Tests.Stubs
{
    public class TestWebRequestCreate : IWebRequestCreate
    {
        private static WebRequest _nextRequest;
        private static readonly object lockObject = new object();

        static public WebRequest NextRequest {
            get { return _nextRequest; }
            set {
                lock (lockObject) {
                    _nextRequest = value;
                }
            }
        }

        public WebRequest Create(Uri uri) {
            return _nextRequest;
        }

        public static TestWebRequest CreateTestRequest(string response) {
            var request = new TestWebRequest(response);
            NextRequest = request;
            return request;
        }
    }

    public class TestWebRequest : WebRequest
    {
        private readonly MemoryStream _requestStream = new MemoryStream();
        private readonly MemoryStream _responseStream;

        public override string Method { get; set; }
        public override string ContentType { get; set; }
        public override long ContentLength { get; set; }

        public TestWebRequest(string response) {
            _responseStream = new MemoryStream(Encoding.UTF8.GetBytes(response));
        }

        public TestWebRequest() : this(string.Empty) {}

        public string ContentAsString() {
            return Encoding.UTF8.GetString(_requestStream.ToArray());
        }

        public override Stream GetRequestStream() {
            return _requestStream;
        }

        public override WebResponse GetResponse() {
            return new TestWebReponse(_responseStream);
        }

        public override Task<WebResponse> GetResponseAsync() {
            return Task.Factory.StartNew(() => GetResponse());
        }
    }

    public class TestWebReponse : WebResponse
    {
        private readonly Stream _responseStream;

        public TestWebReponse(Stream responseStream) {
            _responseStream = responseStream;
        }

        public override Uri ResponseUri {
            get { return new Uri("test://someurl"); }
        }

        public override Stream GetResponseStream() {
            return _responseStream;
        }
    }
}