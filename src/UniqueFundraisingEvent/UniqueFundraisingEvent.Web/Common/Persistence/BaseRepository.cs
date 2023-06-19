using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniqueFundraisingEvent.Web.Common.Application;

namespace UniqueFundraisingEvent.Web.Common.Persistence
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> LookupEntityAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(where);

            foreach (var navigationPropertyPath in navigationPropertiesPath)
                query = query.Include(navigationPropertyPath);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> LookupEntitiesAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(where);

            foreach (var navigationPropertyPath in navigationPropertiesPath)
                query = query.Include(navigationPropertyPath);

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> ReadEntryAsync(Expression<Func<T, bool>> where, params string[] navigationPropertiesPath)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(where);

            foreach (var navigationPropertyPath in navigationPropertiesPath)
                query = query.Include(navigationPropertyPath);

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ReadListAsync(Expression<Func<T, bool>>? where = null, params string[] navigationPropertiesPath)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (where is object)
                query = query.Where(where);

            foreach (var navigationPropertyPath in navigationPropertiesPath)
                query = query.Include(navigationPropertyPath);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Tuple<IReadOnlyList<T>, int>> ReadPageAsync<TKey>(int page, int size,
            string? navigationPropertyPath = null,
            Expression<Func<T, bool>>? where = null,
            Expression<Func<T, TKey>>? orderBy = null)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot);

            IQueryable<T> query = _dbContext.Set<T>();

            if (where is object)
                query = query.Where(where);

            int total = await query.CountAsync();

            if (navigationPropertyPath is object)
                query = query.Include(navigationPropertyPath);

            if (orderBy is object)
                query = query.OrderBy(orderBy);

            var result = await query.Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();

            return new Tuple<IReadOnlyList<T>, int>(result, total);
        }
    }
}
