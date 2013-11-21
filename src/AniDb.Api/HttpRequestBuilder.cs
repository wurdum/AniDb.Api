using System;
using System.Collections.Generic;

namespace AniDb.Api
{
    internal class HttpRequestBuilder {
        private readonly static Dictionary<Requests.RequestTarget, string> _urlTemplates = new Dictionary<Requests.RequestTarget, string> {
            {Requests.RequestTarget.Anime, "http://api.anidb.net:9001/httpapi?request=anime&client={0}&clientver={1}&protover=1&aid={2}"},
            {Requests.RequestTarget.Category, "http://api.anidb.net:9001/httpapi?client={0}&clientver={1}&protover=1&request=categorylist"},
        };

        protected readonly ClientCredentials _client;
        protected readonly Requests.RequestTarget _requestTarget;

        protected HttpRequestBuilder(ClientCredentials client, Requests.RequestTarget requestTarget) {
            _client = client;
            _requestTarget = requestTarget;
        }

        public virtual AniDbRequest Build(params object[] requestParameters) {
            var parameters = new List<object> {_client.Client, _client.Version};
            parameters.AddRange(requestParameters);
            var url = string.Format(_urlTemplates[_requestTarget], parameters.ToArray());
            var uri = new Uri(url);
            return new AniDbRequest(uri);
        }

        public static HttpRequestBuilder For(ClientCredentials client, Requests.RequestTarget requestTarget) {
            return new HttpRequestBuilder(client, requestTarget);
        }
    }
}