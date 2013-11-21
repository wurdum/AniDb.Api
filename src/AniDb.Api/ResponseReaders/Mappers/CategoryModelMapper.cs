using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders.Mappers
{
    public class CategoryModelMapper : ModelMapper<Category, categorylist>
    {
        public override Category Map(categorylist a) {
            return null;
        }
    }
}