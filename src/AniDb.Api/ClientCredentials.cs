namespace AniDb.Api
{
    public class ClientCredentials {
        public ClientCredentials(string client, int version) {
            Client = client;
            Version = version;
        }

        public string Client { get; private set; }
        public int Version { get; private set; }
    }
}