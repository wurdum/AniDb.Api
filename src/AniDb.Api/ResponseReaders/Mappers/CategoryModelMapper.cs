using System.Linq;
using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders.Mappers
{
    public class CategoryModelMapper : ModelMapper<Category[], categorylist>
    {
        public override Category[] Map(categorylist cat) {
            return ArrayOrEmpty(cat.category).Select(c => new Category {
                Id = c.id,
                Description = c.description,
                Name = c.name,
                IsHentai = c.ishentai,
                ParentId = c.parentid
            }).ToArray();
        }
    }
}