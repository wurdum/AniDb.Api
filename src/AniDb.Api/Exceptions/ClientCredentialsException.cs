using System;

namespace AniDb.Api.Exceptions
{
    public class ClientCredentialsException : Exception
    {
        public ClientCredentialsException() {}
        public ClientCredentialsException(string message) : base(message) {}
    }
}