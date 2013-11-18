using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AniDb.Api
{
    public class AniDbRequest
    {
        private readonly HttpWebRequest _request;

        public AniDbRequest(Uri uri) {
            Uri = uri;

            _request = WebRequest.CreateHttp(uri);
            _request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }

        public Uri Uri { get; private set; }

        public async Task<AniDbResponse> GetResponseAsync() {
            var response = (HttpWebResponse)(await _request.GetResponseAsync());
            if (response.StatusCode == HttpStatusCode.OK) {
                var responseBody = await GetResponseBodyAsync(response);
                return new AniDbResponse(response, responseBody);
            }

            throw new HttpListenerException((int)response.StatusCode, "Error during sending request to '" + Uri + "'");
        }

        protected async Task<string> GetResponseBodyAsync(WebResponse response) {
            var stream = response.GetResponseStream();
            if (stream == null)
                throw new NullReferenceException("Response stream from '" + response.ResponseUri + "' is null");

            var sb = new StringBuilder();
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                    sb.Append(line);
            }

            return sb.ToString();
        }
    }
}