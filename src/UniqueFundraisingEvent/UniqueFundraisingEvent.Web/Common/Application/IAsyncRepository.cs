using System.Linq.Expressions;

namespace UniqueFundraisingEvent.Web.Common.Application
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T?> LookupEntityAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath);

        Task<IReadOnlyList<T>> LookupEntitiesAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T?> ReadEntryAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath);

        Task<IReadOnlyList<T>> ReadListAsync(Expression<Func<T, bool>>? where = null, params string[] navigationPropertiesPath);

        Task<Tuple<IReadOnlyList<T>, int>> ReadPageAsync<TKey>(int page, int size, string? navigationPropertyPath = null, Expression<Func<T, bool>>? where = null, Expression<Func<T, TKey>>? orderBy = null);
    }
}