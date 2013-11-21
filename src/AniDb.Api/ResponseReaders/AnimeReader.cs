using AniDb.Api.Models;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public class AnimeReader : ResponseReader<Anime, anime>
    {
        private const string ResponseSchema = "ValidAnimeResponse.xsd";

        public AnimeReader() : base(new AnimeModelMapper()) { }

        protected override anime DeserializeXml(string responseBody) {
            return DeserializeXmlDefault(responseBody, ResponseSchema);
        }
    }
}