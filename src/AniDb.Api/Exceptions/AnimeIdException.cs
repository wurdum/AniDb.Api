using System;

namespace AniDb.Api.Exceptions
{
    public class AnimeIdException : Exception
    {
        public AnimeIdException() {}
        public AnimeIdException(string message) : base(message) {}
        public AnimeIdException(string message, Uri uri) : base(message) {
            Uri = uri;
        }

        public Uri Uri { get; private set; }
    }
}