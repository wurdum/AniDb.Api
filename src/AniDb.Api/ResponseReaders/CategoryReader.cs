using AniDb.Api.Models;
using AniDb.Api.ResponseReaders.Mappers;

namespace AniDb.Api.ResponseReaders
{
    public class CategoryReader : ResponseReader<Category, categorylist>
    {
        private const string ResponseSchema = "ValidCategoryResponse.xsd";

        public CategoryReader() : base(new CategoryModelMapper()) {}

        protected override categorylist DeserializeXml(string responseBody) {
            return DeserializeXmlDefault(responseBody, ResponseSchema);
        }
    }
}