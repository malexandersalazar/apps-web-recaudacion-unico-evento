using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UniqueFundraisingEvent.Web.Application.Contracts.Persistence;

namespace UniqueFundraisingEvent.Web.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork
    {
        private readonly IDbContextTransaction _dbContextTransaction;

        public ApplicationUnitOfWork(IServiceProvider services,
            DbContext dbContext) : base(services)
        {
            _dbContextTransaction = dbContext.Database.BeginTransaction();
        }

        public override async Task CommitAsync()
        {
            await _dbContextTransaction.CommitAsync();
        }
    }
}