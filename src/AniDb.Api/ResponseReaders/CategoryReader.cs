using AniDb.Api.Models;
using AniDb.Api.ResponseReaders.Deserialized;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public class CategoryReader : ResponseReader<Category, category>
    {
        public CategoryReader(ModelMapper<Category, category> mapper) : base(mapper) {}

        public override Category ReadObject(string responseBody) {
            return null;
        }

        protected override category DeserializeXml(string responseBody) {
            throw new System.NotImplementedException();
        }
    }
}