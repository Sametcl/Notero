namespace Notero.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangesAsync();
    }
}
