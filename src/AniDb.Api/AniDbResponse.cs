using System;
using System.Net;
using System.Text.RegularExpressions;
using AniDb.Api.Exceptions;
using AniDb.Api.ResponseReaders;

namespace AniDb.Api
{
    public class AniDbResponse
    {
        private readonly static Regex ErrorRx = new Regex(@"^<error>(?<text>.*)<\/error>$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly WebResponse _response;
        private readonly string _responseBody;

        public AniDbResponse(WebResponse response, string responseBody) {
            if (response == null || string.IsNullOrWhiteSpace(responseBody))
                throw new ArgumentException("Some of the input parameters are empty");

            _response = response;
            _responseBody = responseBody;
        }

        public WebResponse Response {
            get { return _response; }
        }

        public string ResponseBody {
            get { return _responseBody; }
        }

        public T Read<T>(ResponseReader<T> responseReader) {
            if (ResponseBody.Length < 100)
                CheckIfAnError(ResponseBody);

            return responseReader.ReadObject(ResponseBody);
        }

        protected void CheckIfAnError(string responseBody) {
            var match = ErrorRx.Match(responseBody);
            if (!match.Success)
                return;

            var text = match.Groups["text"].Value;
            if (text.Equals("Anime not found", StringComparison.OrdinalIgnoreCase))
                throw new AnimeIdException("Anime with such Id not found", Response.ResponseUri);

            if (text.Equals("Client Values Missing or Invalid"))
                throw new ClientCredentialsException("Clent name or version is wrong");
        }
    }
}