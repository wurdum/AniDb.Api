using AniDb.Api.Models;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public class HotReader : ResponseReader<HotAnime[], hotanime>
    {
        private const string ResponceSchema = "ValidHotResponse.xsd";

        public HotReader() : base(new HotModelMapper()) {}
        
        protected override hotanime DeserializeXml(string responseBody) {
            return DeserializeXmlDefault(responseBody, ResponceSchema);
        }
    }
}