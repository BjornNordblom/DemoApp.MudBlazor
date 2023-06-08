public interface IActRepository : IRepository<Act>, IReadRepository<Act>
{
    Task<Act?> GetRelationOneToOneAsync(int id);

    Task<Act?> GetRelationOneToManyAsync(int id);

    Task<Act?> GetMultiMappingAsync(int id);

    Task<IReadOnlyList<Act>> SearchActByReferenceNumber(string text);

    Task SampleTransaction();
}