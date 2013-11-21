using System;

namespace AniDb.Api
{
    public class Requests {
        public enum RequestTarget { Anime = 1, Category, Hot }

        public static AniDbRequest CreateToAnime(ClientCredentials client, int id) {
            return HttpRequestBuilder.For(client, RequestTarget.Anime).Build(id);
        }

        public static AniDbRequest CreateToCategory(ClientCredentials client) {
            return HttpRequestBuilder.For(client, RequestTarget.Category).Build();
        }

        public static AniDbRequest CreateToHot(ClientCredentials client) {
            throw new NotImplementedException();
        }
    }
}