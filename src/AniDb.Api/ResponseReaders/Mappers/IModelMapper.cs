namespace AniDb.Api.ResponseReaders.Mappers
{
    public interface IModelMapper<out T, in K>
    {
        T Map(K input);
    }
}