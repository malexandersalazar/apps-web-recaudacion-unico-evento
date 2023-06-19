namespace UniqueFundraisingEvent.Web.Common.Application
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}