using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Contracts.Persistence
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _services;

        public UnitOfWork(IServiceProvider services)
        {
            _services = services;
        }

        private IAsyncRepository<Guest>? guestRepository;

        public IAsyncRepository<Guest> GuestRepository
        {
            get { return guestRepository ??= _services.GetRequiredService<IAsyncRepository<Guest>>(); }
        }

        public abstract Task CommitAsync();
    }
}
