using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders
{
    public class CategoryReader : ResponseReader<Category>
    {
        public override Category ReadObject(string responseBody) {
            return null;
        }
    }
}